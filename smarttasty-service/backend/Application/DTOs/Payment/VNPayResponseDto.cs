using backend.Domain.Enums;

namespace backend.Application.DTOs.Payment
{
    public class VNPayResponseDto
    {
        public string ResponseCode { get; set; } = string.Empty;
        public string TransactionRef { get; set; } = string.Empty;
        public PaymentStatus Status { get; set; }
        public string Message => Status == PaymentStatus.Success ? "Thanh toán thành công" : "Thanh toán thất bại";

        public static VNPayResponseDto FromVNPay(string responseCode, string txnRef)
        {
            var status = responseCode switch
            {
                "00" => PaymentStatus.Success,
                "07" => PaymentStatus.Failed,
                "09" => PaymentStatus.Pending,
                "10" => PaymentStatus.Failed,
                _ => PaymentStatus.Failed
            };

            return new VNPayResponseDto
            {
                ResponseCode = responseCode,
                TransactionRef = txnRef,
                Status = status
            };
        }
    }
}
