using AIssist.Application.Services.Interfaces;
using AIssist.Domain.Http.Request.Profile;
using Microsoft.AspNetCore.Mvc;

namespace AIssist.Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : Controller
    {
        private readonly IProfileAppService _profileAppService;

        public ProfileController(IProfileAppService profileAppService)
        {
            _profileAppService = profileAppService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _profileAppService.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProfileRequest profileRequest)
        {
            try
            {
                var result = await _profileAppService.Add(profileRequest);

                return Ok(result);
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
                var result = await _profileAppService.Get();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }          
        }

        [HttpPut()]
        public async Task<IActionResult> Update(ProfilePutRequest profileRequest)
        {
            try
            {
                var result = await _profileAppService.Update(profileRequest);

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

        [HttpDelete("{profileId}")]
        public async Task<IActionResult> Inactivate(long profileId)
        {
            try
            {
                var result = await _profileAppService.Inactivate(profileId);

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

