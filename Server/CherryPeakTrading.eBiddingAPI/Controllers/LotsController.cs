using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CherryPeakTrading.API.ViewModels;
using CherryPeakTrading.BL.Contracts;
using CherryPeakTrading.BL.Contracts.Models;
using CherryPeakTrading.Infrastructure.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CherryPeakTrading.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotsController : ControllerBase
    {

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
        public async Task<IActionResult> Post(LotsFilterViewModel filter)
        {
            if (filter == null)
            {
                Log.Error("Lot object sent from client is null.");
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                Log.Error("Invalid lot object sent from client.");
                return BadRequest("Invalid lot model object");
            }

            LotModel domainFilter = _mapperAdapter.Map<LotModel>(filter);
            await _lotsLogic.CreateLot(domainFilter);
           
            return Ok();
        }
    }
}
