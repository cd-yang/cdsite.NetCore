using System;
using System.Threading.Tasks;
using CdSite.Model.Model;
using Microsoft.AspNetCore.Identity;

namespace CdSite.IService
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync(IdentityUser user);
        Task<bool> AddItemAsync(TodoItem newItem, IdentityUser currentUser);
        Task<bool> MarkDoneAsync(Guid id, IdentityUser currentUser);
    }
}