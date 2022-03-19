using Microsoft.AspNetCore.Mvc;

namespace VanillaJavascript.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        //Get api/values
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.CrudVanillaJsContext db = new Models.CrudVanillaJsContext())
            {
                var lst = (from d in db.Personas
                           select d).ToList();

                return Json(lst);

            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Models.Request.PersonaRequest model) 
        {
            using (Models.CrudVanillaJsContext db = new Models.CrudVanillaJsContext())
            {
                Models.Persona oPersona = new Models.Persona();
                oPersona.Nombre = model.Nombre;
                oPersona.Edad = model.Edad;
                db.Personas.Add(oPersona);
                db.SaveChanges();

            }
        
            return Ok();
        }
        [HttpPut]
        public ActionResult Put([FromBody] Models.Request.PersonaEditRequest model)
        {
                using (Models.CrudVanillaJsContext db = new Models.CrudVanillaJsContext())
                {
                    Models.Persona oPersona = db.Personas.Find(model.Id);
                    oPersona.Nombre = model.Nombre;
                    oPersona.Edad = model.Edad;
                    db.Entry(oPersona).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                }

                return Ok();



            
        }
        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            using (Models.CrudVanillaJsContext db = new Models.CrudVanillaJsContext())
            {
                Models.Persona oPersona = db.Personas.Find(Id);
                
                db.Personas.Remove(oPersona);
                db.SaveChanges();

            }

            return Ok();




        }
    }

}
