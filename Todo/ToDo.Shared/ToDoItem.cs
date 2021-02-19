using System.ComponentModel.DataAnnotations;

namespace ToDo.Shared
{
    public class ToDoItem
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Task { get; set; }

        public bool IsCompleted { get; set; }
    }
}
