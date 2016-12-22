using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Helpers
{
    public static class EnumUtility
    {
        // Might want to return a named type, this is a lazy example (which does work though)
        public static object[] GetValuesAndDescriptions(Type enumType)
        {
            var values = Enum.GetValues(enumType).Cast<object>();

            var valuesAndDescriptions = values.Select(value => new
            {
                Value = value,
                Description = value.GetType()
                    .GetMember(value.ToString())[0]
                    .GetCustomAttributes(true)
                    .OfType<DescriptionAttribute>()
                    .First()
                    .Description
            });
            return valuesAndDescriptions.ToArray();
        }
    }
}
