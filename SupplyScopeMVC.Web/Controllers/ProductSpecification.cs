using Microsoft.AspNetCore.Mvc;

namespace SupplyScopeMVC.Web.Controllers
{
    [Route("ProductSpecification")]
    public class ProductSpecification : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Product")]
        public IActionResult Product(string product)
        {
            return View();
        }

        [Route("ThrowMe")]
        public IActionResult ViewListOfProducts()
        {
            throw new NotImplementedException();
        }
    }
}
