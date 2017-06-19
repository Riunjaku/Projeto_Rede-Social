using BatataSocial.Models;
using BatataSocial.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BatataSocial.Controllers
{
    public class ScrapController : Controller
    {
        private HttpClient _client;


        public ScrapController()
        {
            _client = new HttpClient();
            //_client.BaseAddress = new Uri("https://localhost:44399/");
            _client.BaseAddress = new Uri("http://localhost:10195/");
            _client.DefaultRequestHeaders.Accept.Clear();

            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(mediaType);
        }

        ImageService imageService = new ImageService();


        [AllowAnonymous]
        public async Task<ActionResult> ScrapList()
        {

            var response = await _client.GetAsync("api/Scrap/ScrapList");

            if (response.IsSuccessStatusCode)
            {
                var JsonString = await response.Content.ReadAsStringAsync();

                var ScrapList = JsonConvert.DeserializeObject<List<ScrapViewModel>>(JsonString);


                return PartialView(ScrapList);

            }
            else
            {
                return View();

            }


        }

        // GET: Postagem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Postagem/Create
        [Authorize]
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Postagem/Create
        //
        // POST: /Postagem/Register
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ScrapViewModel model, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                model.IdUser = Session["idUsuario"].ToString();
                model.UserName = Session["Usuario"].ToString();

                if (photo != null)
                {
                    var uploadImagem = await imageService.UploadImageAsync(photo);
                    model.Image = uploadImagem.ToString();
                }
                var response = await _client.PostAsJsonAsync("api/Scrap/ScrapCreate", model);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View();


            }
            return View("Error");
        }

        [Authorize]
        public ActionResult PostarImagem()
        {
            return View();
        }

       

        [HttpPost]
        public async Task<ActionResult> Upload(HttpPostedFileBase photo)
        {
            var imageUrl = await imageService.UploadImageAsync(photo);


            var idusuario = Session["idUsuario"].ToString();
            var Usuario = Session["Usuario"].ToString();
            var foto = imageUrl.ToString();

            var uri = "api/Imagems/Create?idUsuario=" + idusuario + "&emailUsuario=" + Usuario + "&foto=" + foto;

            var response = await _client.GetAsync(uri);




            return RedirectToAction("LatestImage");
        }

        // GET: Postagem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Postagem/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Postagem/Delete/5
        //public ActionResult Delete()
        //{

        //    return View();
        //}


        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {

            var response = await _client.DeleteAsync("api/Scrap/ScrapDeletar?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Principal", "Home");
            }


            return View();






        }
    }
}
