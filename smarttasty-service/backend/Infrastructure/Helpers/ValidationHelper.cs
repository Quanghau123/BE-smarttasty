using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace backend.Infrastructure.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length <= 5)
                return false;

            var hasUpper = password.Any(char.IsUpper);
            var hasLower = password.Any(char.IsLower);
            var hasDigit = password.Any(char.IsDigit);
            var hasSpecial = password.Any(ch => !char.IsLetterOrDigit(ch));

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }

        public static bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^(03|05|07|08|09)\d{8}$");
        }

        public static bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
