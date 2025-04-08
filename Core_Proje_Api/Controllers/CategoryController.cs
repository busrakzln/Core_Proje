using Core_Proje_Api.DAL.ApiContext;
using Core_Proje_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Api.Controllers
{
    [Route("api/[controller]")] //actionlara istek atarken önce api yazar sonra da controller ismi
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //Get isteği
        [HttpGet]
        public IActionResult CategoryList()
        {
            using var c = new Context();
            return Ok(c.Categories.ToList()); // return ok apilerde  sonucun başarılı olduğunu gösteren mettot 200  kodu ile beraber dönüyor.
        }

        [HttpGet("{id}")] // ideye göre get işlemi

        public IActionResult CategoryGet(int id)
        {
            using var c=new Context();
            var value = c.Categories.Find(id);

            if (value==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }

        [HttpPost]

        public IActionResult CategoryAdd(Category p)
        {
            using var c = new Context();
            c.Add(p);
            c.SaveChanges();
            return Created("",p); //201 koduyla döner
        }

        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            using var c = new Context();
            var value = c.Categories.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(value);
                c.SaveChanges();
                return NoContent();
            }
            
        }

        [HttpPut]
        public IActionResult CategoryUpdate(Category p)
        {
            using var c = new Context();
            var value=c.Find<Category>(p.CategoryID);
            if(value == null)
            {
                return NotFound();
            }
            else
            {
                value.CategoryName= p.CategoryName;
                c.Update(value);
                c.SaveChanges();
                return NoContent();
            }
        }
    }
}
