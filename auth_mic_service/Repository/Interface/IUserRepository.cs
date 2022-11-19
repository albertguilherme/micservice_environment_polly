using auth_mic_service.Data.Dto;
using auth_mic_service.Data.Model;

namespace auth_mic_service.Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        User? FindAndLogIn(LogInDtoIn logInDtoIn);
    }
}
