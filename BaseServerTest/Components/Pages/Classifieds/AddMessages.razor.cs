using BaseServerTest.Contracts.Services.Classifieds;
using BaseServerTest.Services.Classifieds;
using BaseServerTest.Shared.Domain.Classifieds;
using Microsoft.AspNetCore.Components;

namespace BaseServerTest.Components.Pages.Classifieds
{
    public partial class AddMessages
    {
        [Inject]
        public IClassifiedMessageService ClassifiedMessageService { get; set; }
        public List<ClassifiedMessage> Messages;

        protected override async Task OnInitializedAsync()
        {
            // Replace with logic to get the logged-in user's ID
            var userId = new Guid().ToString();
            var anotherUserId = new Guid().ToString();
            Messages = await ClassifiedMessageService.GetMessagesBetweenUsersAsync(userId, anotherUserId);
        }
    }
}
