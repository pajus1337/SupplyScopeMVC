using Microsoft.AspNetCore.Mvc;
using SupplyScopeMVC.Application.Interfaces;
using SupplyScopeMVC.Application.Services;
using SupplyScopeMVC.Web.Models;
using System.Diagnostics;

namespace SupplyScopeMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices _productServices;

        public HomeController(ILogger<HomeController> logger, IProductServices productService)
        {
            _logger = logger;
            _productServices = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var items = _productServices.GetAllProducts();
            return View(items);
        }
        [Route("Products/All")]
        public IActionResult ViewListOfProducts()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product() { Id = 1, Name = "Hydrochloric acid", TypeName = "Liquid product" });
            products.Add(new Product() { Id = 2, Name = "Sodium hydroxide solution", TypeName = "Liquid product" });
            products.Add(new Product() { Id = 3, Name = "Sulfuric acid", TypeName = "Liquid product" });

            return View(products);
        }

        [HttpPost]
        public IActionResult OKTest(int id, string name)
        {
            return BadRequest("Everything went fine.");
        }



        public IActionResult TestPartial()
        {
            return PartialView();
        }

        public IActionResult OKTest()
        {
            return Ok("Everything went Fine");
        }

        public IActionResult JsonResult()
        {
            return new JsonResult("JSON");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
