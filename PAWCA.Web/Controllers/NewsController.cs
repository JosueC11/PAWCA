using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAWCA.Models.Converters;
using PAWCA.Models.ViewModels;
using PAWCA.Service.Services.Interfaces;

namespace PAWCA.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _service;
        public NewsController(INewsService service) 
        {
            _service = service;
        }

        public async Task<ActionResult> Index()
        {
            var news = await _service.ValidateFavorite();
            return View(news.Select(NewsConverter.NewsToNewsViewModel));
        }

        public async Task<ActionResult> Favorites()
        {
            var news = await _service.GetAllNewsAsync();
            return View(news.Select(NewsConverter.NewsToNewsViewModel));
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(string articleId)
        {           
            var newx = await _service.GetNewByIdAsync(articleId);
            if (newx == null)
            {
                return NotFound();
            }
            return View(NewsConverter.NewsToNewsViewModel(newx));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NewsViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                var entity = NewsConverter.NewsViewModelToNews(model);
                await _service.SaveNewAsync([entity]);
                return RedirectToAction(nameof(Favorites));
            }
            catch
            {
                ModelState.AddModelError("", "Error saving the comment");
                return View(model);
            }
        }

        public async Task<IActionResult> FavoriteEdit(string id, string page)
        {
            try
            {
                if (page == "Index") 
                {
                    var newsService = await _service.GetAllNewsServiceAsync(false);
                    var newx = newsService.FirstOrDefault(n => n.ArticleId == id)!;
                    await _service.FavoriteEdit([newx]);
                    return RedirectToAction(nameof(Index));
                }   
                else
                {
                    var news = await _service.GetAllNewsAsync();
                    var newx = news.FirstOrDefault(n => n.ArticleId == id)!;
                    await _service.FavoriteEdit([newx]);
                    return RedirectToAction(nameof(Favorites));
                }            
            }
            catch
            {
                ModelState.AddModelError("", "Error saving the comment");
                return RedirectToAction(nameof(Index));
            }
        }    

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            try
            {
                _service.DeleteNewAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
