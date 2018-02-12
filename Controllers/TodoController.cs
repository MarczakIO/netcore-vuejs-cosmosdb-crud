using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarczakIO.VueSPA.Web.Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Newtonsoft.Json;

namespace MarczakIO.VueSPA.Web.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private DocumentDBRepository<Todo> todoRepo;
        private string CollectionId = "Todo";
        public TodoController(DocumentDBRepository<Todo> _todoRepo)
        {
            todoRepo = _todoRepo;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Todo>> GetAll([FromBody] Todo todo)
        {
            return await todoRepo.GetItemsAsync(CollectionId, e => true);
        }

        [HttpPost("[action]")]
        public async Task<Todo> Create([FromBody] Todo todo)
        {
            return await todoRepo.CreateItemAsync(CollectionId, todo);
        }

        [HttpPost("[action]")]
        public async Task Delete([FromBody] Todo todo)
        {
            await todoRepo.DeleteItemAsync(CollectionId, todo.Id);
        }

        public class Todo
        {
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
        }
    }
}