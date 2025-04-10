using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Viewmodels
{
    public class ToDoTaskModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsCompleted { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
    }
}
