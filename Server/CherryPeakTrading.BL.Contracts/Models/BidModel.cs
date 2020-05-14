using System;

namespace CherryPeakTrading.BL.Contracts.Models
{
    public class BidModel
    {
        public long Id { get; set; }

        public int UserId { get; set; }

        public int LotIt { get; set; }

        public DateTime TimeStamp { get; set; }

        public double BidAmount { get; set; }
    }
}
