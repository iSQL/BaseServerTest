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

        [Parameter] 
        public string SellerId { get; set; }
        [Parameter] 
        public string AdId { get; set; }
        [SupplyParameterFromForm]
        public ClassifiedMessage ClassifiedMessage {  get; set; }

        protected override void OnInitialized()
        {
            ClassifiedMessage ??= new();
            //ToDo: Add navigational items
            // Get sendId
        }

        private async Task SendMessage()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var currentUser = await UserManager.GetUserAsync(authState.User);

            ClassifiedMessage.Id = Guid.NewGuid().ToString();
            ClassifiedMessage.ReceiverId = SellerId;
            ClassifiedMessage.ClassifiedAdId = AdId;
            ClassifiedMessage.DateSent = DateTime.UtcNow;
            
            ClassifiedMessage.SenderId = currentUser?.Id;
            await ClassifiedMessageService.SendMessageAsync(ClassifiedMessage);
            // Navigate back to classifieds or to the conversation
        }
    }
}
