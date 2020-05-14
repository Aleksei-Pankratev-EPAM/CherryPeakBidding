using CherryPeakTrading.BL.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CherryPeakTrading.BL.Contracts
{
    public interface IPhotosLogic
    {
        public Task AddPhoto(PhotoModel photo);
    }
}
