using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Shared;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Api.Controllers
{
    [Route("todo")]
    [ApiController]
    public class TodoController : Controller
    {
        private static readonly List<TodoItem> _items = new()
        {
            new() {Id = Guid.NewGuid().ToString(), Text = "First item"},
            new() {Id = Guid.NewGuid().ToString(), Text = "Second item"},
            new() {Id = Guid.NewGuid().ToString(), Text = "Third item"},
            new() {Id = Guid.NewGuid().ToString(), Text = "Fourth item"},
            new() {Id = Guid.NewGuid().ToString(), Text = "Fifth item"},
            new() {Id = Guid.NewGuid().ToString(), Text = "Sixth item"}
        };

        [HttpPost]
        public Task<IActionResult> CreateToDo([FromBody] TodoItem todo)
        {
            try
            {
                _items.Add(todo);

                return Task.FromResult<IActionResult>(Ok(todo.Id));
            }
            catch
            {
                return Task.FromResult<IActionResult>(BadRequest());
            }

        }

        [HttpGet]
        public Task<IActionResult> GetAllToDos()
        {
            try
            {
                return Task.FromResult<IActionResult>(Ok(_items));
            }
            catch
            {
                return Task.FromResult<IActionResult>(BadRequest());
            }
        }

        [HttpGet("{id}")]
        public Task<IActionResult> GetToDo([FromQuery] string id)
        {
            try
            {
                return Task.FromResult<IActionResult>(Ok(_items.FirstOrDefault(s => s.Id == id)));
            }
            catch
            {
                return Task.FromResult<IActionResult>(BadRequest());
            }
        }

        [HttpPut("{id}")]
        public Task<IActionResult> UpdateToDo([FromRoute] string id, [FromBody] TodoItem todo)
        {
            try
            {
                var oldItem = _items.FirstOrDefault(arg => arg.Id == id);

                oldItem.IsCompleted = todo.IsCompleted;
                oldItem.Text = todo.Text;

                return Task.FromResult<IActionResult>(Ok());
            }
            catch
            {
                return Task.FromResult<IActionResult>(BadRequest());
            }
        }

        [HttpDelete]
        public Task<IActionResult> DeleteToDo([FromQuery] string id)
        {
            try
            {
                var oldItem = _items.FirstOrDefault(arg => arg.Id == id);
                _items.Remove(oldItem);

                return Task.FromResult<IActionResult>(Ok());
            }
            catch
            {
                return Task.FromResult<IActionResult>(BadRequest());
            }
        }
    }
}
