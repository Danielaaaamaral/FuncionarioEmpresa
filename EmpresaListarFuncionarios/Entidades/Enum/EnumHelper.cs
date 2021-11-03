using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaListarFuncionarios.Entidades.Enum
{
    public static class EnumHelper
    {
        public static string GetDescription<T>(int itemEnum)
        {
            var itemEnumDescription = System.Enum.GetName(typeof(T), itemEnum);
            return itemEnumDescription != null ? GetAttributeOfType<DisplayAttribute>(System.Enum.Parse(typeof(T), itemEnumDescription)).Name : string.Empty;
        }
        private static T GetAttributeOfType<T>(this object enumVal) where T : Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);

            if (!attributes.Any()) return null;
            return (T)attributes[0];
        }
   

    }
}
