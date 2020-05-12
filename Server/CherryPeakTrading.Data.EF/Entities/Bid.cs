using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CherryPeakTrading.Data.EF.Entities
{
    public class Bid
    {
        public long ID { get; set; }

        public long BidderID { get; set; }

        public User Bidder { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Offer { get; set; }

        public Guid LotID { get; set; }

        [ForeignKey(nameof(LotID))]
        public Lot Lot { get; set; }
    }
}
