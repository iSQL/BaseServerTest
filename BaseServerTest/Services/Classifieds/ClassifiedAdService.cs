using BaseServerTest.Contracts.Repositories.Classifieds;
using BaseServerTest.Contracts.Services.Classifieds;
using BaseServerTest.Shared.Domain.Classifieds;

namespace BaseServerTest.Services.Classifieds
{
    public class ClassifiedAdService : IClassifiedAdService
    {
        private readonly IClassifiedAdRepository _repository;

        public ClassifiedAdService(IClassifiedAdRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClassifiedAd>> GetAllAdsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ClassifiedAd> GetAdByIdAsync(string adId)
        {
            return await _repository.GetByIdAsync(adId);
        }

        public async Task<List<ClassifiedAd>> GetAdsByCategoryAsync(string category)
        {
            return await _repository.GetAdsByCategoryAsync(category);
        }

        public async Task<List<ClassifiedAd>> SearchAdsAsync(string searchTerm)
        {
            return await _repository.SearchAdsAsync(searchTerm);
        }

        public async Task CreateAdAsync(ClassifiedAd ad)
        {
            await _repository.CreateAsync(ad);
        }

        public async Task UpdateAdAsync(ClassifiedAd ad)
        {
            await _repository.UpdateAsync(ad);
        }

        public async Task DeleteAdAsync(string adId)
        {
            var ad = await _repository.GetByIdAsync(adId);
            if (ad != null)
            {
                ad.IsActive = false;
                await _repository.UpdateAsync(ad);
            }
        }
    }

}
