using Microsoft.AspNetCore.Mvc;

namespace InterView.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
