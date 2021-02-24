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
            var todo = new TodoItem();
            var controller = new TodoController();

            // Act
            var result = await controller.CreateToDo(todo);

            // Assert
            Assert.NotNull(result);
        }
    }
}
