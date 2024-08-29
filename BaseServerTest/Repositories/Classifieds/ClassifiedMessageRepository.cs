using BaseServerTest.Contracts.Repositories.Classifieds;
using BaseServerTest.Data;
using BaseServerTest.Shared.Domain.Classifieds;
using Microsoft.EntityFrameworkCore;

namespace BaseServerTest.Repositories.Classifieds
{
    public class ClassifiedMessageRepository : RepositoryBase<ClassifiedMessage>, IClassifiedMessageRepository
    {
        public ClassifiedMessageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<ClassifiedMessage>> GetMessagesForAdAsync(string adId)
        {
            return await _context.ClassifiedMessages
                .Where(m => m.ClassifiedAdId == adId)
                .OrderBy(m => m.DateSent)
                .ToListAsync();
        }

        public async Task<List<ClassifiedMessage>> GetMessagesBetweenUsersAsync(string senderId, string receiverId)
        {
            return await _context.ClassifiedMessages
                .Where(m => (m.SenderId == senderId && m.ReceiverId == receiverId) ||
                            (m.SenderId == receiverId && m.ReceiverId == senderId))
                .OrderBy(m => m.DateSent)
                .ToListAsync();
        }
    }

}
