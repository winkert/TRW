using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Core
{
    public static class EnumExtensions
    {
        public static string GetDescription(Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                    {
                        return attr.Description;
                    }
                }
            }
            return value.ToString();
        }

        public static E GetEnumValue<E>(string value) where E : struct, IConvertible
        {
            if (!typeof(E).IsEnum)
                throw new InvalidOperationException();

            if (!Enum.TryParse(value, true, out E result))
            {
                foreach (FieldInfo field in typeof(E).GetFields())
                {
                    if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                    {
                        if (attribute.Description == value)
                        {
                            result = (E)field.GetValue(null);
                            break;
                        }
                    }
                }
            }

            return result;
        }

        public static E GetEnumValue<E>(int value) where E : struct, IConvertible
        {
            if (!typeof(E).IsEnum)
                throw new InvalidOperationException();

            if (Enum.IsDefined(typeof(E), value))
            {
                foreach(E potentialValue in Enum.GetValues(typeof(E)))
                {
                    if (value.Equals(potentialValue.ToInt32(NumberFormatInfo.CurrentInfo)))
                        return potentialValue;
                }
            }

            return default;
        }

        public static IEnumerable<E> GetAllValues<E>()
        {
            return Enum.GetValues(typeof(E)).Cast<E>();
        }
    }
}
