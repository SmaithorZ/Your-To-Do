namespace ToDoListMVC_1.Models
{
    public class ToDoItem
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsCompleted { get; set; }


        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
