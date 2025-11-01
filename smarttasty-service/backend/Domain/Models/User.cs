using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Domain.Enums;
namespace backend.Domain.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string UserPassword { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Phone { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        [EnumDataType(typeof(UserRole))]
        public UserRole Role { get; set; } = UserRole.user;

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // nếu user là staff thì trường này lưu id của business quản lý (null nếu user bình thường hoặc business chính)
        public int? BusinessOwnerId { get; set; }

        [ForeignKey(nameof(BusinessOwnerId))]
        public User? BusinessOwner { get; set; }

        // nếu user là business thì đây là danh sách nhân viên của họ
        public ICollection<User> Staffs { get; set; } = new List<User>();

        public ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        public ICollection<PasswordResetToken> PasswordResetTokens { get; set; } = new List<PasswordResetToken>();
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
        public ICollection<RecipeReview> RecipeReviews { get; set; } = new List<RecipeReview>();
        public List<Review> Reviews { get; set; } = new();
        public List<Voucher> Vouchers { get; set; } = new();
    }
}
