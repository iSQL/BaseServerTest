using BaseServerTest.Shared.Domain.Classifieds;

namespace BaseServerTest.Contracts.Services.Classifieds
{
    public interface IClassifiedAdService
    {
        Task<List<ClassifiedAd>> GetAllAdsAsync();
        Task<ClassifiedAd> GetAdByIdAsync(string adId);
        Task<List<ClassifiedAd>> GetAdsByCategoryAsync(string category);
        Task<List<ClassifiedAd>> SearchAdsAsync(string searchTerm);
        Task CreateAdAsync(ClassifiedAd ad);
        Task UpdateAdAsync(ClassifiedAd ad);
        Task DeleteAdAsync(string adId);
    }
}
