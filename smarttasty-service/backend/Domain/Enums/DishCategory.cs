using System.ComponentModel.DataAnnotations;

namespace backend.Domain.Enums
{
    public enum DishCategory
    {
        [Display(Name = "Thức ăn")] ThucAn,
        [Display(Name = "Nước uống")] NuocUong,
        [Display(Name = "Thức ăn thêm")] ThucAnThem
    }
}
