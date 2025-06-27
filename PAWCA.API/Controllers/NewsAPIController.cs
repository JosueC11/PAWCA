using Microsoft.AspNetCore.Mvc;
using PAWCA.Manager.Managers;
using PAWCA.Manager.Managers.Interfaces;
using PAWCA.Models;

namespace PAWCA.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsAPIController : Controller
    {
        private readonly INewsManager _manager;
        public NewsAPIController(INewsManager manager)
        {
            _manager = manager;
        }

        [HttpGet(Name = "GetNews")]
        public async Task<IEnumerable<News>> GetAll()
        {
            return await _manager.GetAllNewsAsync();
        }

        [HttpGet("{id}", Name = "GetNewById")]
        public async Task<ActionResult<News?>> GetById(string id)
        {
            var model = await _manager.GetNewByIdAsync(id);
            return model;
        }

        [Route("/NewsAPI/Favorite")]
        [HttpPost]
        public async Task<bool> FavoriteEdit([FromBody] IEnumerable<News> entities)
        {
            foreach (var item in entities)
            {
                await _manager.FavoriteEdit(item);
            }
            return true;
        }

        [HttpPost]
        public async Task<bool> Save([FromBody] IEnumerable<News> entity)
        {
            foreach (var item in entity)
            {
                await _manager.SaveNewAsync(item);
            }
            return true;
        }

        [HttpDelete("{id}", Name = "DeleteNew")]
        public async Task<bool> Delete(string id)
        {
            return await _manager.DeleteNewAsync(id);
        }
    }
}
