using System;

namespace CherryPeakTrading.BL.Contracts.Models
{
    public class PhotoModel
    {
        public long Id { get; set; }

        public string? Url { get; set; }

        public Guid LotId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
