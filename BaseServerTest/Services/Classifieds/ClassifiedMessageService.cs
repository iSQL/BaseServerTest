using BaseServerTest.Contracts.Repositories.Classifieds;
using BaseServerTest.Contracts.Services.Classifieds;
using BaseServerTest.Shared.Domain.Classifieds;

namespace BaseServerTest.Services.Classifieds
{
    public class ClassifiedMessageService : IClassifiedMessageService
    {
        private readonly IClassifiedMessageRepository _repository;

        public ClassifiedMessageService(IClassifiedMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClassifiedMessage>> GetMessagesForAdAsync(string adId)
        {
            return await _repository.GetMessagesForAdAsync(adId);
        }

        public async Task<List<ClassifiedMessage>> GetMessagesBetweenUsersAsync(string senderId, string receiverId)
        {
            return await _repository.GetMessagesBetweenUsersAsync(senderId, receiverId);
        }

        public async Task SendMessageAsync(ClassifiedMessage message)
        {
            await _repository.CreateAsync(message);
        }
    }

}
