using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using BatataSocial.API.Models;
using BatataSocial.Data;

namespace BatataSocial.API.Controllers
{
    [RoutePrefix("api/Perfils")]
    public class ApplicationUserInfoesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Perfils
        public IQueryable<ApplicationUserInfo> GetPerfil()
        {
            return db.ApplicationUserInfo;
        }

        // POST : api/Perfils/Perfil
        [HttpPost]
        [Route("Perfil")]
        [ResponseType(typeof(ApplicationUserInfo))]
        public IHttpActionResult GetPerfil(ApplicationUserInfo perfil)
        {
            
            var UserInfo = db.ApplicationUserInfo.Where(a => a.IdUser == perfil.IdUser);

            var Perfil = UserInfo.FirstOrDefault<ApplicationUserInfo>();

            if (Perfil != null)
            {
                return Ok(Perfil);
            }

            return BadRequest();
        }



        // POST: api/Perfils
        [HttpPost]
        [Route("Create")]
        [ResponseType(typeof(ApplicationUserInfo))]
        public IHttpActionResult PostPerfil(ApplicationUserInfo perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApplicationUserInfo.Add(perfil);
            db.SaveChanges();

            return Ok();
        }

        // POST: api/Perfils
        [Route("Update")]
        [ResponseType(typeof(ApplicationUserInfo))]
        public IHttpActionResult UpdatePerfil(ApplicationUserInfo perfil)
        {

            var PegandoPerfil = db.ApplicationUserInfo.Where(a => a.IdUser == perfil.IdUser);

            var objperfil = PegandoPerfil.FirstOrDefault<ApplicationUserInfo>();

            objperfil.IdUser = perfil.IdUser;
            objperfil.FirstName = perfil.FirstName;
            objperfil.LastName = perfil.LastName;
            objperfil.EstadoCivil = perfil.EstadoCivil;
            objperfil.BirthDate = perfil.BirthDate;
            objperfil.neighborhood = perfil.neighborhood;
            objperfil.School = perfil.School;
            objperfil.StreetName = perfil.StreetName;
            objperfil.WorkPlace = perfil.WorkPlace;
            objperfil.UserPhoto = perfil.UserPhoto;
            db.SaveChanges();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            return CreatedAtRoute("DefaultApi", new { id = perfil.IdUser }, perfil);
        }





        // Get: api/Perfils
        [Route("VerificaPerfil")]
        [ResponseType(typeof(ApplicationUserInfo))]
        public IHttpActionResult perfilExiste(string id)
        {

            var perfil = db.ApplicationUserInfo.Where(a => a.IdUser == null);

            if (perfil == null)
            {
                return BadRequest();

            }


            return Ok();
        }



        // DELETE: api/Perfils/5
        [ResponseType(typeof(ApplicationUserInfo))]
        public IHttpActionResult DeletePerfil(int id)
        {
            ApplicationUserInfo perfil = db.ApplicationUserInfo.Find(id);
            if (perfil == null)
            {
                return NotFound();
            }

            db.ApplicationUserInfo.Remove(perfil);
            db.SaveChanges();

            return Ok(perfil);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PerfilExists(int id)
        {
            return db.ApplicationUserInfo.Count(e => e.Id == id) > 0;
        }
    }
}