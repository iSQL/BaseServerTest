using BaseServerTest.Contracts.Services.Classifieds;
using BaseServerTest.Data;
using BaseServerTest.Services.Classifieds;
using BaseServerTest.Shared.Domain.Classifieds;
using BaseServerTest.State;
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
        ApplicationState ApplicationState { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

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
            var currentUser = ApplicationState.CurrentUser;

            ClassifiedMessage.Id = Guid.NewGuid().ToString();
            ClassifiedMessage.ReceiverId = SellerId;
            ClassifiedMessage.ClassifiedAdId = AdId;
            ClassifiedMessage.DateSent = DateTime.UtcNow;
            
            ClassifiedMessage.SenderId = currentUser?.Id;
            await ClassifiedMessageService.SendMessageAsync(ClassifiedMessage);
            
            NavigationManager.NavigateTo("/classifieds/messages");

        }
    }
}
