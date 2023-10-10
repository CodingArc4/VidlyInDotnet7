using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vidly.Utility
{
    public class Helper
    {
        public static string Admin = "Admin";
        public static string Customer = "Customer";

        public static List<SelectListItem> GetRolesForDropDown(bool isAdmin)
        {
            if (isAdmin)
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{Value = Helper.Admin,Text=Helper.Admin}
                };
            }
            else
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{Value = Helper.Admin,Text=Helper.Admin},
                    new SelectListItem{Value = Helper.Customer,Text=Helper.Customer}
                };
            }

        }
    }
}
