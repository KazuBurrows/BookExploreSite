using BookExploreSite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace BookExploreSite.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        //public ActionResult Index()
        //{
        //    return View();
        //}


        /// <summary>
        /// "Starts the send and gets and outputs db response."
        /// </summary>
        /// <param name="param_search">"User search query input."</param>
        /// <returns>"Table of book records from db."</returns>
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        //[OutputCache(NoStore = true, Duration = 0)]
        [HttpGet]
        public ActionResult Search(string param_search)
        {


            CommandHandler command_handler = new CommandHandler();
            Query server_response = command_handler.Search(param_search);


            string returned_rows = JsonConvert.SerializeObject(server_response.Payload);
            //return Content(returned_rows, "application / json");


            //string a = JsonConvert.SerializeObject(param_search);

            return Json(returned_rows, JsonRequestBehavior.AllowGet);
        }
    }
}