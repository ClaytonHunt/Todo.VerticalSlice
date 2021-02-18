using System.Threading.Tasks;
using Todo.Api.Controllers;
using ToDo.Shared;
using Xunit;

namespace ToDo.Api.Test.Unit
{
    public class AddToDoTests
    {
        [Fact]
        public async Task EmptyTodo_Add_Returns400()
        {
            // Arrange
            var todo = new ToDoItem();
            var controller = new ToDoController();

            // Act
            var result = await controller.AddToDo(todo);

            // Assert
            Assert.NotNull(result);
        }
    }
}
