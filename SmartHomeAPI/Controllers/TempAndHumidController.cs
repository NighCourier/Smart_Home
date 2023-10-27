using Microsoft.AspNetCore.Mvc;
using SmartHomeAPI.Interfaces;
using SmartHomeAPI.Models;
using SmartHomeAPI.Message;

namespace SmartHomeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TempAndHumidController : ControllerBase
    {
        private readonly ITempAndHumidRepository _tempAndHumidRepository;
        public readonly Messages message = new Messages();
        public TempAndHumidController(ITempAndHumidRepository tempAndHumidRepository)
        {
            _tempAndHumidRepository = tempAndHumidRepository;   
        }
        [HttpGet]
        [ProducesResponseType(200, Type =typeof(IEnumerable<TempAndHumid>))]
        public IActionResult GetTempAndHumids()
        {
            try
            {
                var tempAndHumids = _tempAndHumidRepository.GetTempAndHumids();
                return (!ModelState.IsValid) ? BadRequest(message.emptyModel) : Ok(tempAndHumids);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(TempAndHumid))]
        [ProducesResponseType(400)]
        public IActionResult GetTempAndHumid(int id)
        {
            try
            {
                if (!_tempAndHumidRepository.TempAndHumidExist(id))
                    return BadRequest(message.noTempAndHumid);
                var tempAndHumid = _tempAndHumidRepository.GetTempAndHumid(id);
                return (!ModelState.IsValid)?BadRequest(message.emptyModel) : Ok(tempAndHumid);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult PostTempAndHumid(TempAndHumid tempAndHumid)
        {
            try
            {
                if (tempAndHumid == null)
                    return BadRequest(ModelState);
                var tempAndHumids = _tempAndHumidRepository.TempAndHumidExist(tempAndHumid.id);
                if (tempAndHumids == true)
                    return BadRequest(message.idTempAndHumidExist);
                if (!_tempAndHumidRepository.PostTempAndHumid(tempAndHumid))
                {
                    ModelState.AddModelError("", message.errorSave);
                    return StatusCode(500, ModelState);
                }
                return Ok(message.successSave);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
