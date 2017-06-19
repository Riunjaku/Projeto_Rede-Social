using BatataSocial.Models;
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
    public class PrincipalController : Controller
    {




        // GET: Principal
        public ActionResult Index()
        {
            var scrap = new ScrapViewModel();

            return View(scrap);
        }
    }
}