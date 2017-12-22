﻿using System.Web.Mvc;

namespace Website_BĐS.Areas.Agency
{
    public class AgencyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Agency";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Agency_default",
                "Agency/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
                //namespaces: new[] { "Website_BĐS.Controllers" }
            );
        }

    }
}