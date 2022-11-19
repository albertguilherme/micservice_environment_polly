using auth_mic_service.Data.Dto;
using auth_mic_service.Data.Model;

namespace auth_mic_service.Data.Profile
{
    public class TokenProfile : AutoMapper.Profile
    {
        public TokenProfile()
        {
            CreateMap<Token, TokenDto>();
        }
    }
}
