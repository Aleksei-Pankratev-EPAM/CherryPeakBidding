using CherryPeakTrading.API.Models.ViewModels;
using CherryPeakTrading.BL.Contracts;
using CherryPeakTrading.BL.Contracts.Models;
using CherryPeakTrading.Infrastructure.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace CherryPeakTrading.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotsController : ControllerBase
    {
        private const string LotCreationError = "Lot wasn't created successfully";
        private readonly IMapperAdapter _mapperAdapter;
        private readonly ILotsLogic _lotsLogic;

        public LotsController(IMapperAdapter mapperAdapter,
                              ILotsLogic lotsLogic)
        {
            _mapperAdapter = mapperAdapter;
            _lotsLogic = lotsLogic;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(LotViewModel lotToCreate)
        {
            LotModel domainLot = _mapperAdapter.Map<LotModel>(lotToCreate);

            LotModel result;

            try
            {
                result = await _lotsLogic.CreateLot(domainLot);
            }
            catch (Exception ex)
            {
                Log.Error($"{LotCreationError}. Error: {ex.Message}");
                return BadRequest($"{LotCreationError}");
            }

            var createdLot = _mapperAdapter.Map<LotViewModel>(result);

            return CreatedAtRoute(nameof(Get), new { id = createdLot.Id }, createdLot);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            return Ok(";)");
        }
    }
}
