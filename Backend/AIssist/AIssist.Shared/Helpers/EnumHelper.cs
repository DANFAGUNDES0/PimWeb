using System.ComponentModel;
using System.Reflection;

namespace AIssist.Shared.Helpers
{
	public static class EnumHelper
	{
        public static string GetDescriptionFromValue<TEnum>(long value) where TEnum : Enum
        {
            if (!Enum.IsDefined(typeof(TEnum), (int)value))
                return string.Empty;

            var enumValue = (TEnum)Enum.ToObject(typeof(TEnum), value);

            FieldInfo field = typeof(TEnum).GetField(enumValue.ToString());

            DescriptionAttribute? attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attribute == null ? enumValue.ToString() : attribute.Description;
        }
    }
}

