using CherryPeakTrading.BL.Contracts.Models;
using System.Threading.Tasks;

namespace CherryPeakTrading.BL.Contracts
{
    public interface ILotsLogic
    {
        public Task<LotModel> CreateLot(LotModel filter);
    }
}
