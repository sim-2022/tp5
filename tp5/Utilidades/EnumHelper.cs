using System;
using System.ComponentModel;

namespace tp5.Utilidades
{
    public static class EnumHelper
    {
        private static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
        
        public static string ObtenerDescripcion(this Enum enumValue)
        {
            var attribute = enumValue.GetAttributeOfType<DescriptionAttribute>();
            return attribute == null ? string.Empty : attribute.Description;
        } 
    }
}