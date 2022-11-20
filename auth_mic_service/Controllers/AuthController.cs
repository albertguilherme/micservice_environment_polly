using auth_mic_service.Data.Dto;
using auth_mic_service.Data.Model;
using auth_mic_service.Repository.Interface;
using auth_mic_service.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace auth_mic_service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AuthController(ILogger<AuthController> logger, IUserRepository userRepository, IMapper mapper, ITokenService tokenService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult<TokenDto>> LogIn([FromBody] LogInDtoIn logInDto)
        {
            _logger.LogInformation("Trying to make logIn with credentials: {0}", logInDto.ToString());

            var user = _userRepository.FindAndLogIn(logInDto);
            if (user == null)
                return NotFound(new { message = "User not found" });

            var token = _tokenService.CreateUserToken(user);
            var tokenDto = _mapper.Map<TokenDto>(token);
            return Ok(tokenDto);
        }
        
    }
}