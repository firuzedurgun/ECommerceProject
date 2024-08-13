using ECommerce.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.UI.Controllers
{
    public class CategoriesController : Controller
    {
        private HttpClient _httpClient;

        public CategoriesController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7240/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Category>>(jsonString);
                return View(values);
            }
            return NotFound("Category list could not be retrieved...");
        }
        public async Task<IActionResult> Details(int? id)
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7240/api/Categories/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Category>(jsonString);
                return View(value);
            }
            return NotFound("Category is not found");
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Category category)
        {
            var jsonCategory = JsonConvert.SerializeObject(category);
            var stringContent = new StringContent(jsonCategory, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:7240/api/Categories", stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View(category);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7240/api/Categories/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Category>(jsonString);
                return View(value);
            }
            return NotFound("Category is not found!!!");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Category category)
        {
            var jsonCategory = JsonConvert.SerializeObject(category);
            var stringContent = new StringContent(jsonCategory, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync("https://localhost:7240/api/Categories", stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View(category);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7240/api/Categories/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Category>(jsonString);
                return View(value);
            }
            return NotFound("Categories is Not Found!!!");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var responseMessage = await _httpClient.DeleteAsync("https://localhost:7240/api/Categories?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return NotFound("Categories is Not Found!!!");
        }
    }
}
