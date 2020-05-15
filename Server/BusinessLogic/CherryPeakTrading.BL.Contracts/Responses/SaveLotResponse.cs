using CherryPeakTrading.BL.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CherryPeakTrading.BL.Contracts.Responses
{
    public class SaveLotResponse : BaseResponse
    {
        public LotModel Lot { get; private set; }

        private SaveLotResponse(bool success, string message, LotModel lot) : base(success, message)
        {
            Lot = lot;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public SaveLotResponse(LotModel lot) : this(true, string.Empty, lot)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveLotResponse(string message) : this(false, message, null)
        {
        }
    }
}
