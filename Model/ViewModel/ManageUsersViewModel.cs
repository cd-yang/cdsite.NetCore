using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.Model.ViewModel
{
    public class ManageUsersViewModel
    {
        public IdentityUser[] Administrators { get; set; }

        public IdentityUser[] Everyone { get; set; }
    }
}