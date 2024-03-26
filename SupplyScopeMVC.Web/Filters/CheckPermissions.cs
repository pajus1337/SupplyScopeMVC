using Microsoft.AspNetCore.Mvc.Filters;

namespace SupplyScopeMVC.Web.Filters
{
    public class CheckPermissions : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}
