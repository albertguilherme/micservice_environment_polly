using auth_mic_service.Data;
using auth_mic_service.Data.Dto;
using auth_mic_service.Data.Model;
using auth_mic_service.Extensions;
using auth_mic_service.Repository.Interface;

namespace auth_mic_service.Repository.Impl
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context) : base(context)
        {
            _context = context;
        }

        public User? FindAndLogIn(LogInDtoIn logInDtoIn)
        {
            return _context.Users.FirstOrDefault(x => x.Username == logInDtoIn.Username && x.Password == logInDtoIn.Password.ToMd5());
        }
    }
}
