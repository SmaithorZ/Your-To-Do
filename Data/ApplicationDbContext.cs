using Microsoft.EntityFrameworkCore;
using ToDoListMVC_1.Models;

namespace ToDoListMVC_1.Data
{
    public class ApplicationDbContext:DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ToDoItem> ToDoItems { get; set; } //Creates the table

    }
}
