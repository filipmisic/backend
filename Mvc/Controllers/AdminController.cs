using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Service.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mvc.Controllers
{
    
    public class AdminController : Controller
    {
        static HttpClient client = new HttpClient();
        // GET: /<controller>/
        public async Task<IActionResult> Make(SearchMake search)
        {
            if (search.Name is null)
            {
                search.Name = string.Empty;
            }
            HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7168/api/vehicle/getmake",search);
            var make = await response.Content.ReadAsAsync<ServiceResponse<List<Make>>>();
            ViewBag.make = make;
            return View();
        }
        public async Task<IActionResult> CreateMake(Make newMake)
        {
            var make = newMake;
            HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7168/api/vehicle", make);
            return RedirectToAction("Make");
        }
        public async Task<IActionResult> EditMake(int id)
        {
            HttpResponseMessage response = await client.GetAsync("https://localhost:7168/api/vehicle/"+id);
            var makeSingle = await response.Content.ReadAsAsync<ServiceResponse<Make>>();
            ViewBag.make = makeSingle;
            return View();
        }
        public async Task<IActionResult> UpdateMake(Make updatedMake)
        {
            var make = updatedMake;
            HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:7168/api/vehicle", make);
            return RedirectToAction("Make");
        }
        public async Task<IActionResult> DeleteMake(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:7168/api/vehicle/" +id);
            return RedirectToAction("Make");
        }


        public async Task<IActionResult> Model(SearchModel search,SearchMake searchMake)
        {
            if (search.Name is null)
            {
                search.Name = string.Empty;
            }
            HttpResponseMessage responseModel = await client.PostAsJsonAsync("https://localhost:7168/api/vehicle/model/getall", search);
            var model = await responseModel.Content.ReadAsAsync<ServiceResponse<List<Model>>>();
            if (searchMake.Name is null)
            {
                searchMake.Name = string.Empty;
            }
            HttpResponseMessage responseMake = await client.PostAsJsonAsync("https://localhost:7168/api/vehicle/getmake", searchMake);
            var make = await responseMake.Content.ReadAsAsync<ServiceResponse<List<Make>>>();

            ViewBag.make = make;
            ViewBag.model = model;
            return View();
        }
        public async Task<IActionResult> CreateModel(Model newModel)
        {
            var model = newModel;
            HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7168/api/vehicle/model", model);
            return RedirectToAction("Model");
        }
        public async Task<IActionResult> EditModel(int id , SearchMake searchMake)
        {
            HttpResponseMessage responseModel = await client.GetAsync("https://localhost:7168/api/vehicle/model/" + id);
            var ModelSingle = await responseModel.Content.ReadAsAsync<ServiceResponse<Model>>();
            HttpResponseMessage responseMake = await client.PostAsJsonAsync("https://localhost:7168/api/vehicle/getmake", searchMake);
            var make = await responseMake.Content.ReadAsAsync<ServiceResponse<List<Make>>>();

            ViewBag.make = make;
            ViewBag.model = ModelSingle;
            return View();
        }
        public async Task<IActionResult> UpdateModel(Model updateModel)
        {
            var model = updateModel;
            HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:7168/api/vehicle/model", model);
            return RedirectToAction("Model");
        }
        public async Task<IActionResult> DeleteModel(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:7168/api/vehicle/model/" + id);
            return RedirectToAction("Model");
        }

    }
}

