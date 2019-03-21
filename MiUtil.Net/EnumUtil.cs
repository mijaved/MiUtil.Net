using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace MiUtil.Net
{
    public static class EnumUtil
    {
        public static int GetKey<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                return e.ToInt32(CultureInfo.InvariantCulture);
            }

            return -1;
        }

        public static string GetValue<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                return e.ToString();
            }

            return string.Empty;
        }

        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }

            return string.Empty;
        }
    }
}
