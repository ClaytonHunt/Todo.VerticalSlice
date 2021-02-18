using System.Threading.Tasks;
using ToDo.Shared;

using Microsoft.AspNetCore.Mvc;

namespace Todo.Api.Controllers
{
    [ApiController]
    public class ToDoController : Controller
    {
        public Task<IActionResult> AddToDo([FromBody] ToDoItem todo)
        {
            return Task.FromResult<IActionResult>(Ok());
        }
    }
}
