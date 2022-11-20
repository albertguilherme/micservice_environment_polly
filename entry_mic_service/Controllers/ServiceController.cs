using entry_mic_service.Data.Dto;
using Microsoft.AspNetCore.Mvc;

namespace entry_mic_service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly ILogger<ServiceController> _logger;

        public ServiceController(ILogger<ServiceController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<List<ServiceResultDto>>> CreateService([FromBody] List<ServiceDto> serviceCollection)
        {

            return Ok();
        }
    }
}