﻿using System.Web;
using System.Web.Mvc;

namespace PSC06
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filtros.VerificaSession());
        }
    }
}
