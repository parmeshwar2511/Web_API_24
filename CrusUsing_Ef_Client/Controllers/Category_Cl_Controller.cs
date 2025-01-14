using CrusUsing_Ef_Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CrusUsing_Ef_Client.Controllers
{
    public class AB : Controller
    {
        // GET: Category

        public ActionResult Index()
        {
            List<Category>categories= new List<Category>();

            HttpClient client= new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44336/api/");

            HttpResponseMessage response = client.GetAsync("category").Result;

            if (response.IsSuccessStatusCode)
            {
               string result = response.Content.ReadAsStringAsync().Result;
                categories = JsonConvert.DeserializeObject<List<Category>>(result);
            }

            return View(categories);


        }
    }
}