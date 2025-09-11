using System.ComponentModel.DataAnnotations;

namespace backend.Domain.Enums
{
    public enum RecipeCategory
    {
        [Display(Name = "Thức ăn")] ThucAn,
        [Display(Name = "Nước uống")] NuocUong,
        [Display(Name = "Món khai vị")] KhaiVi,
        [Display(Name = "Món chính")] MonChinh,
        [Display(Name = "Món tráng miệng")] TrangMieng,
        [Display(Name = "Ăn vặt")] AnVat,
        [Display(Name = "Ăn chay")] AnChay,
        [Display(Name = "Món nướng")] MonNuong,
        [Display(Name = "Món chiên/xào")] MonChienXao,
        [Display(Name = "Món luộc/hấp")] MonLuocHap,
        [Display(Name = "Món canh/súp")] MonCanhSup,
        [Display(Name = "Món cuốn/gỏi")] MonCuonGoi,
        [Display(Name = "Bánh ngọt")] BanhNgot,
        [Display(Name = "Bánh mặn")] BanhMan,
        [Display(Name = "Món cho bé")] MonChoBe,
        [Display(Name = "Món ăn kiêng/healthy")] MonAnKieng,
        [Display(Name = "Món truyền thống")] MonTruyenThong,
        [Display(Name = "Món theo mùa")] MonTheoMua,
        [Display(Name = "Món quốc tế")] MonQuocTe
    }
}
