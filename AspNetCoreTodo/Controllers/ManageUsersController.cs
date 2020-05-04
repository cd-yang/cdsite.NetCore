using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Controllers
{
    [Authorize(Roles = Constants.AdministratorRole)]
    public class ManageUsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ManageUsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var admins = (await _userManager.GetUsersInRoleAsync(Constants.AdministratorRole))
            .ToArray();

            var everyone = await _userManager.Users.ToArrayAsync();

            var model = new ManageUsersViewModel
            {
                Administrators = admins,
                Everyone = everyone
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)  // param name "id" must be the same with POST
        {
            var user = await _userManager.FindByIdAsync(id);

            var isAdmin = user != null && await _userManager.IsInRoleAsync(user, Constants.AdministratorRole);
            if (isAdmin)
                return RedirectToAction("Index");

            var r = await _userManager.DeleteAsync(user);
            if (r.Succeeded)
                return RedirectToAction("Index");
            else
                return BadRequest("Delete user failed.");
        }
    }
}