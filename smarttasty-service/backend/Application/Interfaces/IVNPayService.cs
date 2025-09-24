using Microsoft.AspNetCore.Http;

namespace backend.Application.Interfaces
{
    public interface IVNPayService
    {
        string CreatePaymentUrl(HttpContext context, decimal amount, string orderId, string orderInfo);

        bool ValidateSignature(IQueryCollection query);
    }
}
