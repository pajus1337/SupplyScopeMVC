using Microsoft.AspNetCore.Mvc;
using SupplyScopeMVC.Domain.Model;

namespace SupplyScopeMVC.Web.Controllers
{
    public class RecipientController : Controller
    {
        public IActionResult Index()
        {
            var model = recipientService.GetAllRecipientsForList();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddRecipient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRecipient(RecipientModel model)
        {
            var id = recipientService.AddRecipient(model);
            return View();
        }

        [HttpGet]
        public IActionResult AddNewAddressForRecipient(int recipientId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewAdressForRecipient(AddressModel model)
        {
            return View();
        }

        public IActionResult ViewRecipient(int recipientId)
        {
            var recipientModel = recipientService.GetReciepientById(recipientId);
            return View(recipientModel);
        }
    }
}
