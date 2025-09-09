using System.ComponentModel.DataAnnotations;

namespace backend.Domain.Enums
{
    public enum RestaurantCategory
    {
        Buffet,
        [Display(Name = "Nhà hàng")] NhaHang,
        [Display(Name = "Ăn vặt/vỉa hè")] AnVatViaHe,
        [Display(Name = "Ăn chay")] AnChay,
        [Display(Name = "Cafe/nước uống")] CafeNuocUong,
        [Display(Name = "Quán ăn")] QuanAn,
        Bar,
        [Display(Name = "Quán nhậu")] QuanNhau
    }
}
