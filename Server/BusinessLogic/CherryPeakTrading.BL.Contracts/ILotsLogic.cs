using CherryPeakTrading.BL.Contracts.Models;
using CherryPeakTrading.BL.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CherryPeakTrading.BL.Contracts
{
    public interface ILotsLogic
    {
        public Task<SaveLotResponse> CreateLot(LotModel filter);
    }
}
