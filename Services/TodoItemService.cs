using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;

// now that we have a real database, we can use this instead of the 'faketodoitemservice' class
namespace AspNetCoreTodo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context; // our friend dependency injection plugging into the sql lite database context

        public TodoItemService(ApplicationDbContext context) // remember to register your ApplicationDbContgext with configureservices so it an be 
            // available for injection. this was done automatically when we created this project
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync()
        {
            var items = await _context.Items
                .Where(x => x.IsDone == false)
                .ToArrayAsync();

            return items; // or you can just return the query directly and remove 'items'
        }

    }
}
