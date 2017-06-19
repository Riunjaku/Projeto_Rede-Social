using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BatataSocial.API.Models;
using BatataSocial.Data;

namespace BatataSocial.API.Controllers
{
    [RoutePrefix("api/Scrap")]
    public class ApplicationUserScrapsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ApplicationUserScraps
        [Route("ScrapList")]
        public IQueryable<ApplicationUserScrap> GetApplicationUserScrap()
        {
            return db.ApplicationUserScrap;
        }

        // GET: api/ApplicationUserScraps/5
        [ResponseType(typeof(ApplicationUserScrap))]
        public async Task<IHttpActionResult> GetApplicationUserScrap(int id)
        {
            ApplicationUserScrap applicationUserScrap = await db.ApplicationUserScrap.FindAsync(id);
            if (applicationUserScrap == null)
            {
                return NotFound();
            }

            return Ok(applicationUserScrap);
        }

        // PUT: api/ApplicationUserScraps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutApplicationUserScrap(int id, ApplicationUserScrap applicationUserScrap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicationUserScrap.Id)
            {
                return BadRequest();
            }

            db.Entry(applicationUserScrap).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserScrapExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ApplicationUserScraps
        [Route("ScrapCreate")]
        [ResponseType(typeof(ApplicationUserScrap))]
        public async Task<IHttpActionResult> PostApplicationUserScrap(ApplicationUserScrap applicationUserScrap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApplicationUserScrap.Add(applicationUserScrap);
            await db.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/ApplicationUserScraps/5
        [Route("ScrapDeletar")]
        [ResponseType(typeof(ApplicationUserScrap))]
        public async Task<IHttpActionResult> DeleteApplicationUserScrap(int id)
        {
            ApplicationUserScrap applicationUserScrap = await db.ApplicationUserScrap.FindAsync(id);
            if (applicationUserScrap == null)
            {
                return NotFound();
            }

            db.ApplicationUserScrap.Remove(applicationUserScrap);
            await db.SaveChangesAsync();

            return Ok(applicationUserScrap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationUserScrapExists(int id)
        {
            return db.ApplicationUserScrap.Count(e => e.Id == id) > 0;
        }
    }
}