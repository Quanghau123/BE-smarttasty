using backend.Application.Interfaces;

namespace backend.Application.Jobs
{
    public class VoucherJob
    {
        private readonly IVoucherService _voucherService;

        public VoucherJob(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        // Job được Hangfire gọi định kỳ
        public async Task CleanupExpiredVouchers()
        {
            await _voucherService.RemoveExpiredVouchersAsync();
        }
    }
}
