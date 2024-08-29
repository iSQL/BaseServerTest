using BaseServerTest.Contracts.Repositories.Classifieds;
using BaseServerTest.Contracts.Services.Classifieds;
using BaseServerTest.Data;
using BaseServerTest.Shared.Domain.Classifieds;
using Microsoft.AspNetCore.Identity;

namespace BaseServerTest.Services.Classifieds
{
    public class ClassifiedUserService : IClassifiedUserService
    {
        private readonly IClassifiedUserRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ClassifiedUserService(IClassifiedUserRepository repository, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _repository = repository;
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<ClassifiedUser> CreateClassifiedUserAsync(string identityUserId, string username)
        {
            var identityUser = await _userManager.FindByIdAsync(identityUserId);
            if (identityUser == null)
            {
                throw new ArgumentException("Invalid IdentityUser ID");
            }

            var classifiedUser = new ClassifiedUser
            {
                Id = identityUser.Id,
                UserName = username,
                Email = identityUser.Email,
                DateRegistered = DateTime.UtcNow
            };

            _context.ClassifiedUsers.Add(classifiedUser);
            await _context.SaveChangesAsync();

            return classifiedUser;
        }

        public async Task<ClassifiedUser> GetUserByIdAsync(string userId)
        {
            return await _repository.GetByIdAsync(userId);
        }

        public async Task<ClassifiedUser> GetUserByUsernameAsync(string username)
        {
            return await _repository.GetUserByUsernameAsync(username);
        }

        public async Task CreateUserAsync(ClassifiedUser user)
        {
            await _repository.CreateAsync(user);
        }

        public async Task UpdateUserAsync(ClassifiedUser user)
        {
            await _repository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await _repository.GetByIdAsync(userId);
            if (user != null)
            {
                await _repository.DeleteAsync(user);
            }
        }
    }

}
