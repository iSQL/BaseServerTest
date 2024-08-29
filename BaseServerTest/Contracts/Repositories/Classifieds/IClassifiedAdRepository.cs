using BaseServerTest.Shared.Domain.Classifieds;

namespace BaseServerTest.Contracts.Repositories.Classifieds
{
    public interface IClassifiedAdRepository : IRepositoryBase<ClassifiedAd>
    {
        Task<List<ClassifiedAd>> GetAdsByCategoryAsync(string category);
        Task<List<ClassifiedAd>> SearchAdsAsync(string searchTerm);
    }
}
