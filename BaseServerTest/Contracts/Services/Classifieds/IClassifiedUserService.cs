using BaseServerTest.Shared.Domain.Classifieds;

namespace BaseServerTest.Contracts.Services.Classifieds
{
    public interface IClassifiedUserService
    {
        Task<ClassifiedUser> GetUserByIdAsync(string userId);
        Task<ClassifiedUser> GetUserByUsernameAsync(string username);
        Task CreateUserAsync(ClassifiedUser user);
        Task UpdateUserAsync(ClassifiedUser user);
        Task DeleteUserAsync(string userId);
    }

}
