using System.Web;
using System.Web.Mvc;

namespace Networking312190796_318855038
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
