using BaseServerTest.Contracts.Services.Classifieds;
using BaseServerTest.Data;
using BaseServerTest.Services.Classifieds;
using BaseServerTest.Shared.Domain.Classifieds;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BaseServerTest.Components.Pages.Classifieds
{
    public partial class AddMessages
    {
        [Inject]
        UserManager<ApplicationUser> UserManager { get; set; }
        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        public IClassifiedMessageService ClassifiedMessageService { get; set; }

        public List<ClassifiedMessage> Messages;

        protected override async Task OnInitializedAsync()
        {
            // ToDo: Add navigational properties for ad, users
            // Add message details
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var currentUser = await UserManager.GetUserAsync(authState.User);

            var userId = currentUser?.Id;
            var anotherUserId = currentUser?.Id;
            Messages = await ClassifiedMessageService.GetMessagesBetweenUsersAsync(userId, anotherUserId);
        }
    }
}
