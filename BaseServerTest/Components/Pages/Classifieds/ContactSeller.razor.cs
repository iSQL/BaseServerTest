using BaseServerTest.Contracts.Services.Classifieds;
using BaseServerTest.Data;
using BaseServerTest.Services.Classifieds;
using BaseServerTest.Shared.Domain.Classifieds;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.ServiceModel.Channels;

namespace BaseServerTest.Components.Pages.Classifieds
{
    public partial class ContactSeller
    {
        [Inject]
        public IClassifiedMessageService ClassifiedMessageService { get; set; }
        [Inject]
        UserManager<ApplicationUser> UserManager { get; set; }
        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Parameter] public string SellerId { get; set; }
        [Parameter] public string AdId { get; set; }
        public ClassifiedMessage Message = new ClassifiedMessage();

        protected async override void OnInitialized()
        {
            Message.Id = Guid.NewGuid().ToString();
            Message.ReceiverId = SellerId;
            Message.ClassifiedAdId = AdId;
            Message.DateSent = DateTime.UtcNow;
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var currentUser = await UserManager.GetUserAsync(authState.User);
            Message.SenderId = currentUser?.Id;

            //ToDo: Add navigational items
            // Get sendId
        }

        private async Task SendMessage()
        {
            await ClassifiedMessageService.SendMessageAsync(Message);
            // Navigate back to classifieds or to the conversation
        }
    }
}
