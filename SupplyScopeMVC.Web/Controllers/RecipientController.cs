using Microsoft.AspNetCore.Mvc;
using SupplyScopeMVC.Application.Interfaces;
using SupplyScopeMVC.Application.ViewModels.Recipient;
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
        [HttpGet]
        public IActionResult Index()
        {
            var model = _recipientService.GetAllRecipientsForList(2, 1, "");
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNumber, string searchString)
        {
            if (!pageNumber.HasValue)
            {
                pageNumber = 1;

            }
            if (searchString is null)
            {
                searchString = string.Empty;
            }
            var model = _recipientService.GetAllRecipientsForList(pageSize, pageNumber.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddRecipient()
        {
            return View(new NewRecipientVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRecipient(NewRecipientVm model)
        {
            if (ModelState.IsValid)
            {
                var id = _recipientService.AddRecipient(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditRecipient(int id)
        {
            var recipient = _recipientService.GetRecipientForEdit(id);
            return View(recipient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRecipient(NewRecipientVm model)
        {
            if (ModelState.IsValid)
            { 
                _recipientService.UpdateRecipient(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddNewAddressForRecipient(int recipientId)
        {
            return View();
        }

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
