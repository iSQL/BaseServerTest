using BaseServerTest.Contracts.Services.Classifieds;
using BaseServerTest.Shared.Domain.Classifieds;
using Microsoft.AspNetCore.Components;


namespace BaseServerTest.Components.Pages.Classifieds
{
    public partial class AdDetail
    {
        [Inject]
        public IClassifiedAdService ClassifiedAdService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter] public string AdId { get; set; }
        private ClassifiedAd Ad;

        protected override async Task OnInitializedAsync()
        {
            Ad = await ClassifiedAdService.GetAdByIdAsync(AdId);
        }

        private void ContactSeller()
        {
            NavigationManager.NavigateTo($"/classifieds/contact/{Ad.UserId}/{AdId}");
        }
        private void EditAd()
        {
            NavigationManager.NavigateTo($"/classifieds/post/{AdId}?IsEditing=true");
        }
    }
}
