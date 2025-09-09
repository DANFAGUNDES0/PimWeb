using AIssist.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AIssist.Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : Controller
    {
        private readonly ILogAppService _logAppService;

        public LogsController(ILogAppService logAppService)
        {
            _logAppService = logAppService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var result = await _logAppService.Get();

            return Ok(result);
        }
    }
}

