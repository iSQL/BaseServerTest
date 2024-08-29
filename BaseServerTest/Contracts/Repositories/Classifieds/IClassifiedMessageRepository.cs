using BaseServerTest.Shared.Domain.Classifieds;

namespace BaseServerTest.Contracts.Repositories.Classifieds
{
    public interface IClassifiedMessageRepository : IRepositoryBase<ClassifiedMessage>
    {
        Task<List<ClassifiedMessage>> GetMessagesForAdAsync(string adId);
        Task<List<ClassifiedMessage>> GetMessagesBetweenUsersAsync(string senderId, string receiverId);
    }
}
