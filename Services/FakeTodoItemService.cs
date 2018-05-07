using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Models; // dont forget the todo model classes we are using. the data will be placed in these classes through the interface

namespace AspNetCoreTodo.Services // 34
{
    public class FakeTodoItemService : ITodoItemService //this class provides a service to data that woudl normally come from a database, but we fake it with hard
                                     // coded data here in the interrum.  the interface can use either this or the database once we get the database up
    {
        public Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync()
        {
            // return the array of TodoItems
            IEnumerable<TodoItem> items = new[]
            {
                new TodoItem
                {
                    Title = "Learn ASP.NET Core",
                    DueAt = DateTimeOffset.Now.AddDays(1)
                },
                new TodoItem
                {
                    Title = "Build Awesome Apps",
                    DueAt = DateTimeOffset.Now.AddDays(2)
                }
            };
            return Task.FromResult(items);
        }
    }
}
