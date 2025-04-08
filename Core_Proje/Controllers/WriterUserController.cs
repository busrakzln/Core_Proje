using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Core_Proje.Controllers
{
    public class WriterUserController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult ListWriter()
        {
            //SerializeObject : listeleme işlemleri için kullanılır.
            var values = JsonConvert.SerializeObject(writerManager.TGetList());
            return Json(values);
        }

        [HttpPost]

        public IActionResult AddWriter(WriterUser p)
        {
            writerManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
    }
}
