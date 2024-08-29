using BaseServerTest.Data;
using BaseServerTest.State;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using BaseServerTest.Services.Classifieds;

namespace BaseServerTest.Components.Pages
{
    public partial class Home
    {
        [Inject]
        UserManager<ApplicationUser> UserManager { get; set; }
        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        ApplicationState ApplicationState { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity != null && user.Identity.IsAuthenticated)
            {
                ApplicationState.CurrentUser = await UserManager.GetUserAsync(authState.User);
            }
        }
    }
}
