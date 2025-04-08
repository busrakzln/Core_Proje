using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Proje.Controllers
{
    public class Experience2Controller : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult ListExperience()
        {
            //SerializeObject : listeleme işlemleri için kullanılır.
            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience([FromBody] Experience p)
        {
            experienceManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
            //if (ModelState.IsValid)
            //{
            //    experienceManager.TAdd(p);
            //    var values = JsonConvert.SerializeObject(p);
            //    return Json(values);
            //}
            //else
            //{
            //    // Model geçerli değilse, hata mesajı döndür
            //    return BadRequest("Gönderilen veri geçersiz. Lütfen tüm zorunlu alanları doldurduğunuzdan emin olun.");
            //}
        }
        public IActionResult GetById(int ExperienceID)
        {
            var v=experienceManager.TGetByID(ExperienceID);
            var values = JsonConvert.SerializeObject(v);
            return Json(values);
        }

        public IActionResult DeleteExperience(int id)
        {
            var v = experienceManager.TGetByID(id);
            experienceManager.TDelete(v);
            return NoContent();// geriye bir şey döndürmesine gerek olmadığından nocontent diyebiliriz.
        }

        [HttpPost]
        public IActionResult UpdateExperience([FromBody] Experience updatedExperience)
        {
            // ID ile mevcut kaydı bul
            var experience = experienceManager.TGetByID(updatedExperience.ExperienceID);

            if (experience == null)
            {
                return NotFound(new { message = "Kayıt bulunamadı" });
            }

            // Değerleri güncelle
            experience.Name = updatedExperience.Name;
            experience.Date = updatedExperience.Date;
            experience.Description = updatedExperience.Description;
            experience.ImageUrl = updatedExperience.ImageUrl;

            // Veritabanına güncellemeyi kaydet
            experienceManager.TUpdate(experience);

            return Ok(new { message = "Güncelleme başarılı" });
        }


    }
}
