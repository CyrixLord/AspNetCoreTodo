using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService // this service interface will allow us to get information from the database regarding to-do items.
        // dont forget the 'public' interface or you'll get 'scope issues
    {
        Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync(); // requires no parameters and returns a Task<IEnumerable<TodoItem>>
    }   // use tasks and async because we will have to wait on the results of this item. this is similar to a 'future' or 'promise'

}
