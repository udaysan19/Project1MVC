using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using Project1MVC.Models;
using System.Collections.Generic;
using System;

namespace Project1MVC.Controllers
{
    public class SlotController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44321/api");
        //In asp.net MVC httpclient is available to consume Web API
        //Take reference of httpclient
        //Click on reference and add reference
        // GET: Port
        HttpClient client;

        public SlotController()
        {  //intialize http client object 
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        public IActionResult Index()
        {//Using this http client obj call port web API
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/port").Result;
            List<Portslot> slotModel = new List<Portslot>();
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                //Deserialise json data into slotModel for
                //this newton soft
                //for serialization and desserialization
                //Install from nuget -Newton soft package - Newtonsoft.Json
                slotModel = JsonConvert.DeserializeObject<List<Portslot>>(data);
            }
            return View(slotModel);
        }
    }
}
