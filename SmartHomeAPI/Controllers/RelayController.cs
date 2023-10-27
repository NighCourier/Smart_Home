using Microsoft.AspNetCore.Mvc;
using SmartHomeAPI.Interfaces;
using SmartHomeAPI.Message;
using SmartHomeAPI.Models;

namespace SmartHomeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RelayController : ControllerBase
    {
        private readonly IRelayRepository _relayRepository;
        public readonly Messages message = new Messages();
        public RelayController(IRelayRepository relayRepository)
        {
            _relayRepository = relayRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Relay>))]
        public IActionResult GetRelays()
        {
            try
            {
                var relays = _relayRepository.GetRelays();
                return (!ModelState.IsValid) ? BadRequest(message.emptyModel) : Ok(relays);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Relay))]
        [ProducesResponseType(400)]
        public IActionResult GetRelay(int id)
        {
            try
            {
                if (!_relayRepository.RelayExist(id))
                    return BadRequest(message.noRelay);
                var relay = _relayRepository.GetRelay(id);
                return (!ModelState.IsValid) ? BadRequest(message.emptyModel) : Ok(relay);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult PostRelay(Relay relay)
        {
            try
            {
                if (relay == null)
                    return BadRequest(message.noRelay);
                var relays = _relayRepository.RelayExist(relay.id);
                if (relays == true)
                    return BadRequest(message.idRelayExist);
                if (!_relayRepository.PostRelay(relay)) 
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
