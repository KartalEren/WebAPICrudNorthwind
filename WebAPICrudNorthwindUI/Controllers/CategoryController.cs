using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICrudNorthwindUI.ViewModels;

namespace WebAPICrudNorthwindUI.Controllers
{
    public class CategoryController : Controller
    {
        private static HttpClient _httpClient;
        public CategoryController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7262/");
        }

        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            var responseTask = await _httpClient.GetAsync("api/category");
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = responseTask.Content.ReadAsAsync<List<CategoryVM>>();
                return View(readTask.Result);
            }
            return View();
        }

        // GET: CategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var getTask = await _httpClient.GetAsync("api/category" + id.ToString());
            if (getTask.IsSuccessStatusCode)
            {
                var readTask = await getTask.Content.ReadAsAsync<CategoryVM>();
                return View(readTask);
            }
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoryVM categoryVM)
        {
            var postTask = await _httpClient.PostAsJsonAsync<CategoryVM>("api/category", categoryVM);
            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Error = postTask.Content;
                return View(categoryVM);
            }
        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var getTask = await _httpClient.GetAsync("api/category");
            var readTask = await getTask.Content.ReadAsAsync<List<CategoryVM>>();
            CategoryVM categoryVM = readTask.FirstOrDefault(x => x.CategoryId == id);
            return View(categoryVM);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CategoryVM categoryVM)
        {
            var postTask = await _httpClient.PutAsJsonAsync<CategoryVM>("api/category", categoryVM);

            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Error = postTask.Content;
                return View(categoryVM);
            }
        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var getTask = await _httpClient.GetAsync("api/category");
            var readTask = await getTask.Content.ReadAsAsync<List<CategoryVM>>();
            CategoryVM categoryVM = readTask.FirstOrDefault(x => x.CategoryId == id);
            return View(categoryVM);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, CategoryVM categoryVM)
        {
            var postTask = await _httpClient.DeleteAsync("api/category/" + id.ToString());

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
