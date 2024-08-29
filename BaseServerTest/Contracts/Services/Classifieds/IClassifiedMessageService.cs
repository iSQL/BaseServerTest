
using BaseServerTest.Shared.Domain.Classifieds;

namespace BaseServerTest.Contracts.Services.Classifieds
{
    public interface IClassifiedMessageService
    {
        Task<List<ClassifiedMessage>> GetMessagesForAdAsync(string adId);
        Task<List<ClassifiedMessage>> GetMessagesBetweenUsersAsync(string senderId, string receiverId);
        Task SendMessageAsync(ClassifiedMessage message);
    }
}
