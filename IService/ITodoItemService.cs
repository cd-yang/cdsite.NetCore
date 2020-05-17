using System;
using System.Threading.Tasks;
using AspNetCoreTodo.Model.Model;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.IService
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync(IdentityUser user);
        Task<bool> AddItemAsync(TodoItem newItem, IdentityUser currentUser);
        Task<bool> MarkDoneAsync(Guid id, IdentityUser currentUser);
    }
}