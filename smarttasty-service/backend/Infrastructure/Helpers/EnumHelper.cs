using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace backend.Infrastructure.Helpers
{
    public static class EnumHelper
    {
        public static string GetDisplayName<T>(T enumValue) where T : Enum
        {
            return enumValue
                .GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()?
                .Name ?? enumValue.ToString();
        }
    }
}
