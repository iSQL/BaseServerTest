using BaseServerTest.Contracts.Repositories.Classifieds;
using BaseServerTest.Data;
using BaseServerTest.Shared.Domain.Classifieds;
using Microsoft.EntityFrameworkCore;

namespace BaseServerTest.Repositories.Classifieds
{
    public class ClassifiedAdRepository : RepositoryBase<ClassifiedAd>, IClassifiedAdRepository
    {
        public ClassifiedAdRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<ClassifiedAd>> GetAdsByCategoryAsync(string category)
        {
            return await _context.ClassifiedAds
                .Where(ad => ad.Category == category && ad.IsActive)
                .ToListAsync();
        }

        public async Task<List<ClassifiedAd>> SearchAdsAsync(string searchTerm)
        {
            return await _context.ClassifiedAds
                .Where(ad => (ad.Title.Contains(searchTerm) || ad.Description.Contains(searchTerm)) && ad.IsActive)
                .ToListAsync();
        }
    }

}
