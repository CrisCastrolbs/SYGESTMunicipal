using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Extensions
{
    public static class IEnumerableExtension2
    {
        public static IEnumerable<SelectListItem>
            ToSelectListItem<T>(this IEnumerable<T> items, string selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("NombreTipoConsulta"),
                       Value = item.GetPropertyValue("TipoConsultaId"),
                       Selected = item.GetPropertyValue("TipoConsultaId").Equals(selectedValue.ToString())
                   };
        }
    }
}