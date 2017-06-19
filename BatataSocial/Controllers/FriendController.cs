using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BatataSocial.Controllers
{
    public class FriendController : Controller
    {
        // GET: Friend
        public ActionResult Friend()
        {
            return PartialView();
        }
    }
}