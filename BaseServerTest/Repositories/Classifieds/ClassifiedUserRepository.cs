using BaseServerTest.Contracts.Repositories.Classifieds;
using BaseServerTest.Data;
using BaseServerTest.Shared.Domain.Classifieds;
using Microsoft.EntityFrameworkCore;

namespace BaseServerTest.Repositories.Classifieds
{
    public class ClassifiedUserRepository : RepositoryBase<ClassifiedUser>, IClassifiedUserRepository
    {
        public ClassifiedUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ClassifiedUser> GetUserByUsernameAsync(string username)
        {
            return await _context.ClassifiedUsers.FirstOrDefaultAsync(u => u.UserName == username);
        }
    }

}
