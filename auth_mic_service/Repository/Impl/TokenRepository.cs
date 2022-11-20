using auth_mic_service.Data;
using auth_mic_service.Data.Model;
using auth_mic_service.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace auth_mic_service.Repository.Impl
{
    public class TokenRepository : Repository<Token>, ITokenRepository
    {
        public TokenRepository(Context context) : base(context)
        {

        }
    }

}
