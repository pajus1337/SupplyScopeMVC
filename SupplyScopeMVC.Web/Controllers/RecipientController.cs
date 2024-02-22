using Microsoft.AspNetCore.Mvc;
using SupplyScopeMVC.Application.Interfaces;
using SupplyScopeMVC.Domain.Model;

namespace SupplyScopeMVC.Web.Controllers
{
    public class RecipientController : Controller
    {
        private readonly IRecipientService _recipientService;
   
        public RecipientController(IRecipientService recipientService)
        {
            _recipientService = recipientService;
        }

        public IActionResult Index()
        {
            var model = _recipientService.GetAllRecipientsForList();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddRecipient()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddRecipient(RecipientModel model)
        //{
        //    var id = _recipientService.AddRecipient(model);
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult AddNewAddressForRecipient(int recipientId)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddNewAddressForRecipient(AddressModel model)
        //{
        //    return View();
        //}

        public IActionResult ViewRecipient(int recipientId)
        {
            var recipientModel = _recipientService.GetRecipientDetails(recipientId);
            return View(recipientModel);
        }
    }
}
