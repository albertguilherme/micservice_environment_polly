using auth_mic_service.Data.Model;

namespace auth_mic_service.Services.Interface
{
    public interface ITokenService
    {
        Token CreateUserToken(User user);
    }
}
