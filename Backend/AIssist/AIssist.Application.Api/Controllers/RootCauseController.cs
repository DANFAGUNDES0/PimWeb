using AIssist.Application.Services.Interfaces;
using AIssist.Domain.Http.Request.RootCause;
using Microsoft.AspNetCore.Mvc;

namespace AIssist.Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RootCauseController : Controller
    {
        private readonly IRootCauseAppService _rootCauseAppService;

        public RootCauseController(IRootCauseAppService rootCauseAppService)
        {
            _rootCauseAppService = rootCauseAppService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _rootCauseAppService.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(RootCausePostRequest rootCauseRequest)
        {
            try
            {
                var result = await _rootCauseAppService.Add(rootCauseRequest);

                if (result.Success)
                    return Ok();
                else
                    return BadRequest(new { result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _rootCauseAppService.Get();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Update(RootCausePutRequest rootCauseRequest)
        {
            try
            {
                var result = await _rootCauseAppService.Update(rootCauseRequest);

                if (result.Success)
                    return Ok();
                else
                    return BadRequest(new { result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpDelete("{rootCauseId}")]
        public async Task<IActionResult> Inactivate(long rootCauseId)
        {
            try
            {
                var result = await _rootCauseAppService.Inactivate(rootCauseId);

                if (result.Success)
                    return Ok();
                else
                    return BadRequest(new { result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }
    }
}

