using auth_mic_service.Data.Dto;
using auth_mic_service.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace auth_mic_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserRepository _userRepository;

        public AuthController(ILogger<AuthController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<TokenDto>> LogIn([FromBody] LogInDtoIn logInDto)
        {
            _logger.LogInformation("Trying to make logIn with credentials: {0}", logInDto.ToString());

            var user = _userRepository.FindAndLogIn(logInDto);
            
            return Ok(user);
        }
        
    }
}