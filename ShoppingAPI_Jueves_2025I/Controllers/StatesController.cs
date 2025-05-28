using Microsoft.AspNetCore.Mvc;
using ShoppingAPI_Jueves_2025I.DAL.Entities;
using ShoppingAPI_Jueves_2025I.Domain.Interfaces;
using System.Diagnostics.Metrics;

namespace ShoppingAPI_Jueves_2025I.Controllers
{
    [Route("api/[controller]")] // Este es el nombre inicial de mi RUTA, URL o PATH
    [ApiController]
    public class StatesController : Controller
    {
        private readonly IStateService _stateService;

        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByCountryId/{countryId}")]

        public async Task<ActionResult<IEnumerable<State>>> GetStatesByCountryIdAsync(State state, Guid countryId)
        {
            var states = await _stateService.GetStatesByCountryIdAsync(state, countryId);

            if (states == null || states.Any()) return NotFound(); // NotFound = Status Code 404

            return Ok(states); // Ok = Status Code 200

        }

        [HttpGet, ActionName("Get")]
        [Route("GetByName/{stateName}")]

        public async Task<ActionResult<IEnumerable<State>>> GetStatesByNameAsync(String stateName)
        {
            var states = await _stateService.GetStatesByNameAsync(stateName);

            if (states == null || states.Any()) return NotFound();

            return Ok(states);

        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]

        public async Task<ActionResult<State>> CreateStateAsync(State state)
        {
            try
            {
                var newState = await _stateService.CreateStateAsync(state);
                if (newState == null) return NotFound();
                return Ok(newState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                    return Conflict(String.Format("{0} ya existe", state.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]

        public async Task<ActionResult<State>> EditStateAsync(State state)
        {
            try
            {
                var editedState = await _stateService.EditStateAsync(state);
                
                if (editedState == null) return NotFound();
                
                return Ok(editedState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                    return Conflict(String.Format("{0} ya existe", state.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]

        public async Task<ActionResult<State>> DeleteStateAsync(Guid guid)
        {
            if (guid == null) return BadRequest();

                var deletedState = await _stateService.DeleteStateAsync(guid);

                if (deletedState == null) return NotFound();

                return Ok(deletedState);
          

        }
    }
}
