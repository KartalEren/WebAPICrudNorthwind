using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using WebAPICrudNorthwindUI.ViewModels;

namespace WebAPICrudNorthwindUI.Controllers
{
    public class ProductController : Controller
    {
        private static HttpClient _httpClient;
        public ProductController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7262/");
        }
        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            var responseTask = await _httpClient.GetAsync("api/product");
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = responseTask.Content.ReadAsAsync<List<ProductVM>>();
                return View(readTask.Result);
            }
            return View();
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var getTask = await _httpClient.GetAsync("api/product/" + id.ToString());
            if (getTask.IsSuccessStatusCode)
            {
                var readTask = await getTask.Content.ReadAsAsync<ProductVM>();
                return View(readTask);
            }
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductVM productVM)
        {
            var postTask = await _httpClient.PostAsJsonAsync<ProductVM>("api/product", productVM);

            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Error = postTask.Content;
                return View(productVM);
            }
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var getTask = await _httpClient.GetAsync("api/product");
            var readTask = await getTask.Content.ReadAsAsync< List < ProductVM >>();
            ProductVM productVM = readTask.FirstOrDefault(x => x.ProductId == id);
            return View(productVM);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductVM productVM)
        {
            var postTask = await _httpClient.PutAsJsonAsync<ProductVM>("api/product", productVM);

            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Error = postTask.Content;
                return View(productVM);
            }
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var getTask = await _httpClient.GetAsync("api/product");
            var readTask = await getTask.Content.ReadAsAsync<List<ProductVM>>();
            ProductVM productVM = readTask.FirstOrDefault(x => x.ProductId == id);
            return View(productVM);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id,ProductVM productVM)
        {
            var postTask = await _httpClient.DeleteAsync("api/product/" + id.ToString());
            
            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Error = postTask.Content;
                return View();
            }
        }
    }
}
