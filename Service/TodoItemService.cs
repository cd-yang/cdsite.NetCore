using System;
using System.Linq;
using System.Threading.Tasks;
using CdSite.Repository.Data;
using CdSite.IService;
using CdSite.Model.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CdSite.Service
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TodoItem[]> GetIncompleteItemsAsync(IdentityUser user)
        {
            return await _context.Items
                .Where(x => x.IsDone == false && x.UserId == user.Id)
                .ToArrayAsync();
        }

        public async Task<bool> AddItemAsync(TodoItem newItem, IdentityUser currentUser)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = newItem.DueAt ?? DateTimeOffset.Now.AddDays(3);
            newItem.UserId = currentUser.Id;

            _context.Items.Add(newItem);

            var r = await _context.SaveChangesAsync();
            return r == 1;
        }

        public async Task<bool> MarkDoneAsync(Guid id, IdentityUser currentUser)
        {
            var item = await _context.Items.Where(n => n.Id == id).SingleOrDefaultAsync();

            if (item == null)
                return false;

            item.IsDone = true;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}