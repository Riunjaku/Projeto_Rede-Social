using Newtonsoft.Json;
using BatataSocial.Models;
using BatataSocial.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BatataSocial.Data;

namespace BatataSocial.Controllers
{
    public class PerfilController : Controller
    {
        //private ApplicationSignInManager _signInManager;
        //private ApplicationUserManager _userManager;
        private HttpClient _client;

        public PerfilController()
        {
            _client = new HttpClient();
            //_client.BaseAddress = new Uri("https://localhost:44399/");
            _client.BaseAddress = new Uri("http://localhost:10195/");
            _client.DefaultRequestHeaders.Accept.Clear();

            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(mediaType);
        }

        ImageService imageService = new ImageService();


        //GET : Perfil View
        public async Task<ActionResult> Perfil()
        {
            var perfil = new PerfilViewModel();
            perfil.IdUser = Session["idUsuario"].ToString();
            var response = await _client.PostAsJsonAsync("api/Perfils/Perfil", perfil);
            if (response.IsSuccessStatusCode)
            {
                var JsonString = await response.Content.ReadAsStringAsync();

                var Perfil = JsonConvert.DeserializeObject<PerfilViewModel>(JsonString);
                if (Perfil != null)
                {

                    return View(Perfil);


                }
                else
                {

                }
            }
            return View();
            }
        //POST : Perfil View
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Perfil(PerfilViewModel perfil)
        {

            var response = await _client.PostAsJsonAsync("api/Perfils/Perfil", perfil);

            if (response.IsSuccessStatusCode)
            {
                var JsonString = await response.Content.ReadAsStringAsync();

                var Perfil = JsonConvert.DeserializeObject<PerfilViewModel>(JsonString);
                if (Perfil != null)
                {

                    return View(Perfil);


                }
                else
                {

                }
            }
            return View("Error", "Shared");
        }


        // GET: Perfil/Create
        public ActionResult PerfilCreate()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> PerfilCreate(PerfilViewModel model, HttpPostedFileBase photo)

        {

            model.IdUser = Session["idUsuario"].ToString();
            model.UserName = Session["Usuario"].ToString();

            if (photo != null)
            {
                var uploadImagem = await imageService.UploadImageAsync(photo);
                model.UserPhoto = uploadImagem.ToString();
            }
            else
            {
                model.UserPhoto = "SemFotoPerfil";
            }



            if (model != null)
            {

                var response = await _client.PostAsJsonAsync("api/Perfils/Create", model);

                if (response.IsSuccessStatusCode)
                {
                    
                    return RedirectToAction("Perfil", "Perfil");
                }
                else
                {
                    // TO do
                }
            }


            return View();


        }





        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> PerfilEdit(PerfilViewModel model, HttpPostedFileBase photo)
        {
            var uploadImagem = await imageService.UploadImageAsync(photo);

            model.UserPhoto = uploadImagem.ToString();

            var response = await _client.PostAsJsonAsync("api/Perfils/Update", model);

            return RedirectToAction("Index", "Home");

        }

        // GET: Perfil/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Perfil/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

