using AspNetCoreTodo.Services;
using System;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;
        private readonly UserManager<IdentityUser> _userManager;

        public TodoController(ITodoItemService todoItemService, UserManager<IdentityUser> userManager)
        {
            _todoItemService = todoItemService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Challenge();

            var items = await _todoItemService.GetIncompleteItemsAsync(currentUser);

            var model = new TodoViewModel()
            {
                Items = items
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Challenge();

            // newItem.UserId = currentUser.Id;
            var success = await _todoItemService.AddItemAsync(newItem, currentUser);
            if (!success)
                return BadRequest("Could not add item.");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
                return RedirectToAction("Index");

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return Challenge();

            var success = await _todoItemService.MarkDoneAsync(id, currentUser);
            if (!success)
                return BadRequest("Could not mark item as done.");

            return RedirectToAction("Index");
        }
    }
}