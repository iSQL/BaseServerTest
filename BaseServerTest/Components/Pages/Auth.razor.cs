
using BaseServerTest.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BaseServerTest.Components.Pages
{
    public partial class Auth
    {
        [Inject]
        public UserManager<ApplicationUser> UserManager { get; set; }
        [Inject]
        public RoleManager<IdentityRole> RoleManager { get; set; }

        public string rolename { get; set; } = "Admin";
        protected async override Task OnInitializedAsync()
        {
            //bool success = await AssignRoleToUserAsync("060464a6-52d3-4700-91f0-efd842b87348", "Admin");
            //if (success)
            //{
            //}
            //else
            //{
            //}

        }
        public async Task<bool> AssignRoleToUserAsync(string userId, string roleName)
        {
            // Check if the role exists
            if (!await RoleManager.RoleExistsAsync(roleName))
            {
                // Create the role if it doesn't exist
                await RoleManager.CreateAsync(new IdentityRole(roleName));
            }

            // Get the user
            var user = await UserManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false; // User not found
            }

            // Check if the user is already in the role
            if (await UserManager.IsInRoleAsync(user, roleName))
            {
                return true;
            }

            // Assign the role to the user
            var result = await UserManager.AddToRoleAsync(user, roleName);

            return result.Succeeded;
        }
        //todo: add a form to assign selected role to selected user

    }
}
