using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace NotificationService.Application.Commons.Utils
{
    public static class NotificationFormatter { }

    public static class NotificationUtils
    {
        public static string FormatNotificationContent(string content, IDictionary<string, object> parameters)
        {
            if (string.IsNullOrEmpty(content)) return content;

            const string replaceChar = "__COLON__";
            content = content.Replace(":", replaceChar);

            if (parameters != null)
            {
                foreach (var kv in parameters)
                {
                    // ✅ Thống nhất dùng {{key}}
                    content = content.Replace($"{{{{{kv.Key}}}}}", kv.Value?.ToString());
                }
            }

            content = content.Replace("\\n", "\n");
            content = content.Replace(replaceChar, ":");
            return content;
        }

        public static IDictionary<string, object> FormatPushNotificationParams(IDictionary<string, object>? parameters)
        {
            if (parameters == null) return new Dictionary<string, object>();

            var formatted = new Dictionary<string, object>();
            foreach (var kv in parameters)
            {
                if (kv.Value is string)
                {
                    formatted[kv.Key] = kv.Value;
                }
                else
                {
                    formatted[kv.Key] = JsonSerializer.Serialize(kv.Value);
                }
            }
            return formatted;
        }

        public static int ParseNumber(object input, int defaultValue = 0, ILogger? logger = null)
        {
            if (input == null) return defaultValue;

            if (!int.TryParse(input.ToString(), out var result))
            {
                logger?.LogWarning("ParseNumber failed for input={Input}, using default={DefaultValue}", input, defaultValue);
                return defaultValue;
            }

            return result;
        }

        public static bool ParseBoolean(object input)
        {
            if (input is bool b) return b;
            return string.Equals(input?.ToString(), "true", StringComparison.OrdinalIgnoreCase);
        }
    }
}
