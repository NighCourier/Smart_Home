using Microsoft.AspNetCore.Mvc;
using SmartHomeAPI.Interfaces;
using SmartHomeAPI.Models;

namespace SmartHomeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToggleController : ControllerBase
    {
        private readonly IToggleRepository _toggleRepository;
        public ToggleController(IToggleRepository toggleRepository)
        {
            _toggleRepository = toggleRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TempAndHumid>))]
        public IActionResult GetToggle()
        {
            try
            {
                //return (_toggleRepository.GetToggle().isEnabled == true) ? Ok(toggle) : Ok(toggle);
                return Ok(_toggleRepository.GetToggle());
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult PostToggle(Toggle toggle) 
        {
            try
            {
                return Ok(_toggleRepository.PostToggle(toggle));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
