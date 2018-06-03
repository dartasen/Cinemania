using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [AttributeUsageAttribute(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class EnumAttr : Attribute
    {
        public EnumAttr() { }
    }

    public static class EnumExtension
    {
        public static EnumAttr GetAttr(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            var atts = (EnumAttr[])fieldInfo.GetCustomAttributes(typeof(EnumAttr), false);
            return atts.Length > 0 ? atts[0] : null;
        }
    }
}
