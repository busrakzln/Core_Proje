using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager =new WriterMessageManager(new EfWriterMessageDal());

        public IActionResult ReceiverMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = writerMessageManager.GetListReceiverMessage(p);
            return View(values);
        }

        public IActionResult SenderMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = writerMessageManager.GetListSenderMessage(p);
            return View(values);
        }

        public IActionResult AdminMessageDetails(int id)
        {
            var values=writerMessageManager.TGetByID(id);
            return View(values);    
        }
        //public IActionResult AdminMessageDelete(int id)
        //{
        //    var values = writerMessageManager.TGetByID(id);
        //    writerMessageManager.TDelete(values);
        //    return RedirectToAction("SenderMessageList");
        //}

        public IActionResult AdminMessageDelete(int id, string source)
        {
            var values = writerMessageManager.TGetByID(id);
            writerMessageManager.TDelete(values);

            if (source == "Sender")
            {
                return RedirectToAction("SenderMessageList");
            }
            else if (source == "Receiver")
            {
                return RedirectToAction("ReceiverMessageList");
            }

            // Eğer source parametresi beklenmedik bir değer alırsa varsayılan olarak bir sayfaya yönlendirin
            return RedirectToAction("SenderMessageList");
        }

        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage p)
        {
            p.Sender = "admin@gmail.com";
            p.SenderName = "Admin";
            p.Date = DateTime.Parse(DateTime.Now.ToLongDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }

    }
}
