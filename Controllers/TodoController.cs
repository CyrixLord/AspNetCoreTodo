using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Services; // since ITodoItemService is in the services namespace, we need this using to access the interface
using AspNetCoreTodo.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {                                                       // hold a reference to the ITodoItemService we can use the service from Index later
        private readonly ITodoItemService _todoItemService; // dependency injection we want to read only and keep the information int he controller
        // because the serices the controller depends on are injected rom teh service container, this pattern is called dependency injection
        
        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }


        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            // get to-do items from database
            var tododItems = await _todoItemService.GetIncompleteItemsAsync();

            // put items into a model
            var model = new TodoViewModel()
            {
                Items = tododItems
            };
            
            // render view using the model

            return View(model); // dont pass an empty view, you must pass the data from the database to the cshtml page by adding 'model'
            // otherwise you'll get a null object found in a foreach :)
        }
    }
}
