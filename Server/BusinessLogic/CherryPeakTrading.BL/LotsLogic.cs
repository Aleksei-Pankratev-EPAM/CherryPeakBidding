using CherryPeakTrading.API.Models.Responses;
using CherryPeakTrading.BL.Contracts;
using CherryPeakTrading.BL.Contracts.Models;
using CherryPeakTrading.BL.Contracts.Responses;
using CherryPeakTrading.Data.Contracts;
using CherryPeakTrading.Data.Contracts.Entities;
using CherryPeakTrading.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lot = CherryPeakTrading.Data.Contracts.Entities.Lot;

namespace CherryPeakTrading.BL
{
    public class LotsLogic : ILotsLogic
    {
        private IMapperAdapter _mapperAdapter;
        private ILotRepository _lotRepository;

        public LotsLogic(IMapperAdapter mapperAdapter, ILotRepository lotRepository)
        {
            _mapperAdapter = mapperAdapter;
            _lotRepository = lotRepository;
        }
        public async Task<SaveLotResponse> CreateLot(LotModel filter)
        {
            Data.Contracts.Entities.Lot lot = _mapperAdapter.Map<Lot>(filter);
            Lot result = await _lotRepository.Add(lot);

            if (result == null)
            {
                return new SaveLotResponse("Lot saving wasn't successful");
            }
            else
            {
                var savedLot = _mapperAdapter.Map<LotModel>(result);
                return new SaveLotResponse(savedLot);
            }
        }
    }
}
