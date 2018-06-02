using ScrumWare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrumWare.Controllers
{
    public class ProductOwnerController : Controller
    {
        ProjetScrumEntities db = new ProjetScrumEntities();
        // GET: ProductOwner
        public ActionResult Index()
        {

            return View();
        }
       
    }
}