using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Mobile.Business.DataAbstraction;
using ToDo.Shared;

namespace ToDo.Mobile.Data
{
    public class DataStore : IDataStore<ToDoItem>
    {
        private readonly List<ToDoItem> _items;

        public DataStore()
        {
            _items = new List<ToDoItem>
            {
                new ToDoItem { Id = Guid.NewGuid().ToString(), Task = "First item" },
                new ToDoItem { Id = Guid.NewGuid().ToString(), Task = "Second item" },
                new ToDoItem { Id = Guid.NewGuid().ToString(), Task = "Third item" },
                new ToDoItem { Id = Guid.NewGuid().ToString(), Task = "Fourth item" },
                new ToDoItem { Id = Guid.NewGuid().ToString(), Task = "Fifth item" },
                new ToDoItem { Id = Guid.NewGuid().ToString(), Task = "Sixth item" }
            };
        }

        public async Task<bool> AddItemAsync(ToDoItem item)
        {
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ToDoItem item)
        {
            var oldItem = _items.FirstOrDefault(arg => arg.Id == item.Id);

            _items.Remove(oldItem);
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = _items.FirstOrDefault(arg => arg.Id == id);
            _items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ToDoItem> GetItemAsync(string id)
        {
            return await Task.FromResult(_items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ToDoItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_items);
        }
    }
}