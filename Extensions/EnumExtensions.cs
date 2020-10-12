using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebAPI.API.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString<TEnum>(this TEnum @enum)
        {
            var info = @enum.GetType().GetField(@enum.ToString());
            var attributes = (DescriptionAttribute[]) info?.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes == null || attributes.Length == 0)
                return @enum.ToString();

            return attributes[0].Description;
        }
    }
}
