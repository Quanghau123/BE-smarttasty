using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using backend.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace backend.Application.Services
{
    public class VNPayService : IVNPayService
    {
        private readonly string _vnp_TmnCode;
        private readonly string _vnp_HashSecret;
        private readonly string _vnp_Url;
        private readonly string _vnp_ReturnUrl;
        private readonly ILogger<VNPayService> _logger;

        public VNPayService(IConfiguration config, ILogger<VNPayService> logger)
        {
            _vnp_TmnCode = config["VNPay:TmnCode"]?.Trim() ?? throw new ArgumentNullException("VNPay:TmnCode");
            _vnp_HashSecret = config["VNPay:HashSecret"]?.Trim() ?? throw new ArgumentNullException("VNPay:HashSecret");
            _vnp_Url = config["VNPay:Url"]?.Trim() ?? throw new ArgumentNullException("VNPay:Url");
            _vnp_ReturnUrl = config["VNPay:ReturnUrl"]?.Trim() ?? throw new ArgumentNullException("VNPay:ReturnUrl");
            _logger = logger;
        }

        // Tạo payment url theo spec VNPay
        public string CreatePaymentUrl(HttpContext context, decimal amount, string orderId, string orderInfo)
        {
            var vnpayData = new SortedDictionary<string, string>(StringComparer.Ordinal)
            {
                {"vnp_Version", "2.1.0"},
                {"vnp_Command", "pay"},
                {"vnp_TmnCode", _vnp_TmnCode},
                {"vnp_Amount", ((long)amount * 100).ToString()},
                {"vnp_CurrCode", "VND"},
                {"vnp_TxnRef", orderId},
                {"vnp_OrderInfo", orderInfo},
                {"vnp_OrderType", "other"},
                {"vnp_Locale", "vn"},
                {"vnp_ReturnUrl", _vnp_ReturnUrl},
                {"vnp_IpAddr", context.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1"},
                {"vnp_CreateDate", DateTime.UtcNow.AddHours(7).ToString("yyyyMMddHHmmss")},
                {"vnp_ExpireDate", DateTime.UtcNow.AddHours(7).AddMinutes(15).ToString("yyyyMMddHHmmss")}
            };

            // Loại bỏ các trường rỗng
            var kvs = vnpayData.Where(kv => !string.IsNullOrEmpty(kv.Value)).ToList();

            // Build raw data for hash: encode both key & value using UrlEncode (so spaces -> '+')
            // IMPORTANT: use WebUtility.UrlEncode (query-style encoding)
            var hashDataParts = kvs
                .OrderBy(kv => kv.Key, StringComparer.Ordinal)
                .Select(kv => $"{WebUtility.UrlEncode(kv.Key)}={WebUtility.UrlEncode(kv.Value)}");

            var hashData = string.Join("&", hashDataParts);

            var secureHash = CreateSecureHash(hashData);

            // Build query string exactly the same way (encode key & value)
            var queryString = hashData + "&vnp_SecureHash=" + secureHash;

            var paymentUrl = _vnp_Url.TrimEnd('?') + "?" + queryString;

            _logger.LogInformation("VNPay CreatePaymentUrl - RawDataForHash: {RawData}", hashData);
            _logger.LogInformation("VNPay CreatePaymentUrl - SecureHash: {Hash}", secureHash);
            _logger.LogInformation("VNPay CreatePaymentUrl - PaymentUrl: {Url}", paymentUrl);

            return paymentUrl;
        }

        // Validate callback (IPN / Return): rebuild rawData same cách và so hash
        public bool ValidateSignature(IQueryCollection query)
        {
            _logger.LogInformation("VNPay ValidateSignature - Incoming query: {Query}", query.ToString());

            // Lấy tất cả param bắt đầu bằng "vnp_" (hoặc lấy tất cả rồi lọc vnp_SecureHash)
            var dict = new Dictionary<string, string>(StringComparer.Ordinal);
            foreach (var k in query.Keys)
            {
                dict[k] = query[k].ToString();
                _logger.LogDebug("Param: {Key} = {Value}", k, dict[k]);
            }

            // Remove secure hash fields
            dict.Remove("vnp_SecureHash");
            dict.Remove("vnp_SecureHashType");

            // Build raw data same cách: sort by key asc, UrlEncode key & value, join with &
            var hashDataParts = dict
                .Where(kv => !string.IsNullOrEmpty(kv.Value))
                .OrderBy(kv => kv.Key, StringComparer.Ordinal)
                .Select(kv => $"{WebUtility.UrlEncode(kv.Key)}={WebUtility.UrlEncode(kv.Value)}");

            var hashData = string.Join("&", hashDataParts);

            var recomputedHash = CreateSecureHash(hashData);
            var incomingHash = query["vnp_SecureHash"].ToString();

            _logger.LogInformation("VNPay ValidateSignature - RawDataForHash: {RawData}", hashData);
            _logger.LogInformation("VNPay ValidateSignature - IncomingHash: {Incoming}", incomingHash);
            _logger.LogInformation("VNPay ValidateSignature - RecomputedHash: {Recomputed}", recomputedHash);

            var valid = string.Equals(recomputedHash, incomingHash, StringComparison.OrdinalIgnoreCase);

            if (!valid)
            {
                _logger.LogWarning("VNPay ValidateSignature - HASH MISMATCH");
            }

            return valid;
        }

        private string CreateSecureHash(string data)
        {
            // VNPay dùng HMACSHA512 (theo spec). Dùng UTF8 bytes của data.
            var keyBytes = Encoding.UTF8.GetBytes(_vnp_HashSecret);
            var inputBytes = Encoding.UTF8.GetBytes(data);

            using var hmac = new HMACSHA512(keyBytes);
            var hashBytes = hmac.ComputeHash(inputBytes);

            // Hex to uppercase (VNPay không phân biệt hoa/thường khi so sánh, nhưng chuẩn hóa)
            return BitConverter.ToString(hashBytes).Replace("-", "").ToUpperInvariant();
        }

        // Helper test: truyền vào phần query (không có ?), ví dụ "vnp_Amount=...&vnp_TxnRef=...&vnp_SecureHash=..."
        public bool TestValidateQueryString(string queryString)
        {
            var parsed = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(queryString);

            var dict = parsed
                .Where(x => x.Key != "vnp_SecureHash" && x.Key != "vnp_SecureHashType")
                .ToDictionary(x => x.Key, x => x.Value.ToString(), StringComparer.Ordinal);

            var hashDataParts = dict
                .Where(kv => !string.IsNullOrEmpty(kv.Value))
                .OrderBy(kv => kv.Key, StringComparer.Ordinal)
                .Select(kv => $"{WebUtility.UrlEncode(kv.Key)}={WebUtility.UrlEncode(kv.Value)}");

            var rawData = string.Join("&", hashDataParts);
            var recomputed = CreateSecureHash(rawData);

            Console.WriteLine("RawData: " + rawData);
            Console.WriteLine("RecomputedHash: " + recomputed);
            parsed.TryGetValue("vnp_SecureHash", out var incoming);
            Console.WriteLine("IncomingHash: " + incoming);

            return string.Equals(recomputed, incoming.ToString(), StringComparison.OrdinalIgnoreCase);
        }
    }
}
