using BaseServerTest.Contracts.Services.Classifieds;
using BaseServerTest.Data;
using BaseServerTest.Services.Classifieds;
using BaseServerTest.Shared.Domain.Classifieds;
using BaseServerTest.State;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BaseServerTest.Components.Pages.Classifieds
{
    public partial class ClassifiedsMain
    {
        [Inject]
        public IClassifiedAdService ClassifiedAdService { get; set; }
        [Inject]
        UserManager<ApplicationUser> UserManager { get; set; }
        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        ApplicationState ApplicationState { get; set; }

        public List<ClassifiedAd> Ads;

        public string SearchTerm;

        public string SelectedCategory;
        //ToDo Put categories in persistent storage
        public List<string> Categories = new List<string> { "Electronics", "Furniture", "Vehicles", "Services", "Other" };

        protected override async Task OnInitializedAsync()
        {
            Ads = await ClassifiedAdService.GetAllAdsAsync();
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            ApplicationState.CurrentUser = await UserManager.GetUserAsync(authState.User);
        }

        public async Task SearchAds()
        {
            Ads = await ClassifiedAdService.SearchAdsAsync(SearchTerm);
        }

        public async Task FilterByCategory(ChangeEventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedCategory))
            {
                Ads = await ClassifiedAdService.GetAllAdsAsync();
            }
            else
            {
                Ads = await ClassifiedAdService.GetAdsByCategoryAsync(SelectedCategory);
            }
        }
    }
}

