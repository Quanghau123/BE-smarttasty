using backend.Application.Interfaces;
using backend.Domain.Enums;

namespace backend.Application.Jobs
{
    public class PaymentJob
    {
        private readonly IPaymentService _paymentService;

        public PaymentJob(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task CheckPendingPayments()
        {
            var pendingPayments = await _paymentService.GetPendingPayments();
            foreach (var payment in pendingPayments)
            {
                if (payment.Method != PaymentMethod.VNPay)
                    continue;

                var result = await _paymentService.VerifyWithVNPay(payment);

                if (result.IsSuccess && !string.IsNullOrEmpty(result.TransactionNo))
                    await _paymentService.UpdatePaymentSuccess(payment, result.TransactionNo);
                else if (result.IsFailed)
                    await _paymentService.UpdatePaymentFail(payment, result.Message);
            }
        }
    }
}
