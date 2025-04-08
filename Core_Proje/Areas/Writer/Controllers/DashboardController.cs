using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Core_Proje.Areas.Writer.Controllers
{
    
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v=values.Name + " " + values.Surname;

            
            // Weather API'si
            string api = "4d19df6abd94095ea145751e1aae1221";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=sanliurfa&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            //statistics
            Context c=new Context();
            ViewBag.v1 = c.WriterMessages.Where(x=>x.Receiver==values.Email).Count();
            ViewBag.v2 = c.Announcements.Count();
            ViewBag.v3 = c.Users.Count();
            ViewBag.v4 = c.Skills.Count();
            return View();
        }
    }
}
/*4d19df6abd94095ea145751e1aae1221*/
/*https://api.openweathermap.org/data/2.5/weather?q=sanliurfa&mode=xml&lang=tr&units=metric&appid=4d19df6abd94095ea145751e1aae1221*/