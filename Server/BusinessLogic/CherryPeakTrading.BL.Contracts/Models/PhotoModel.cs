using System;

namespace CherryPeakTrading.BL.Contracts.Models
{
    public class PhotoModel
    {
        public long Id { get; set; }

        public string Url { get; set; } = string.Empty;

        public Guid LotId { get; set; }

        public LotModel Lot { get; set; } = new LotModel();
    }
}
