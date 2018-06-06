using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Permet de créer des attributes custom
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class EnumAttr : Attribute
    {
        public EnumAttr() { }
    }

    /// <summary>
    /// Classe statique qui étend les <see cref="Enum"/> et qui nous permettra de recevoir sous forme
    /// de tableau les différentes propriétes de l'attributs
    /// </summary>
    public static class EnumExtension
    {
        public static EnumAttr GetAttr(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            var atts = fieldInfo.GetCustomAttributes(typeof(EnumAttr), false) as EnumAttr[];

            return atts.Length > 0 ? atts[0] : null;
        }
    }
}
