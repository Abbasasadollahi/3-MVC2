using DevCard.Data;
using DevCard.Models;
using DevCard_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DevCard.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Service> _services = new List<Service>
        {
            new Service(1, "نقره ای"),
            new Service(2, "طلایی"),
            new Service(3, "پلاتین"),
            new Service(4, "الماس"),
        };
        public HomeController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProjectDetails(long id)
        {
            var project = ProjectStore.GetProjectBy(id);
            return View(project);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            var model = new Contact()
            {
                Services = new SelectList(_services, "Id", "Name")
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Contact(Contact model)
        {
            model.Services = new SelectList(_services, "Id", "Name");
            if (!ModelState.IsValid == false)
            {
                ViewBag.error = "اطلاعات وارد شده صحیح نیست. لطفا دوباره تلاش کنید";
                return View(model);
            }
            else
            {
                ModelState.Clear();
                model = new Contact
                {
                    Services = new SelectList(_services, "Id", "Name")
                };
                ViewBag.success = "پیغام شما با موفقیت ارسال شد. باتشکر";
                return View(model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}