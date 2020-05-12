using System;

namespace CherryPeakTrading.Data.Entities
{
    public class Bid
    {
        public long Id { get; set; }

        public int UserId { get; set; }

        public int LotIt { get; set; }

        public DateTime TimeStamp { get; set; }

        public double BidAmount { get; set; }
    }
}
