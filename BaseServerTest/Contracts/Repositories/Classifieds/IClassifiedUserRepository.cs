using BaseServerTest.Shared.Domain.Classifieds;

namespace BaseServerTest.Contracts.Repositories.Classifieds
{
    public interface IClassifiedUserRepository : IRepositoryBase<ClassifiedUser>
    {
        Task<ClassifiedUser> GetUserByUsernameAsync(string username);
    }
}
