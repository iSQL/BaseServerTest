using BaseServerTest.Contracts.Services.Classifieds;
using BaseServerTest.Services.Classifieds;
using BaseServerTest.Shared.Domain.Classifieds;
using Microsoft.AspNetCore.Components;

namespace BaseServerTest.Components.Pages.Classifieds
{
    public partial class ClassifiedsMain
    {
        [Inject]
        public IClassifiedAdService ClassifiedAdService { get; set; }
        public List<ClassifiedAd> Ads;
        public string SearchTerm;
        public string SelectedCategory;
        public List<string> Categories = new List<string> { "Electronics", "Furniture", "Vehicles", "Services", "Other" };

        protected override async Task OnInitializedAsync()
        {
            Ads = await ClassifiedAdService.GetAllAdsAsync();
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

