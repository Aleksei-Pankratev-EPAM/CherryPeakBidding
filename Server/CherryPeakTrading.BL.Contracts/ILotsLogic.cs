using CherryPeakTrading.BL.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CherryPeakTrading.BL.Contracts
{
    public interface ILotsLogic
    {
        public Task CreateLot(LotModel filter);
    }
}
