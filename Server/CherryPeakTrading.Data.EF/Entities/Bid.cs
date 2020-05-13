using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CherryPeakTrading.Data.EF.Entities
{
    public class Bid
    {
        public long Id { get; set; }

        public long BidderId { get; set; }

        [ForeignKey(nameof(BidderId))]
        public User Bidder { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Offer { get; set; }

        public Guid LotId { get; set; }

        [ForeignKey(nameof(LotId))]
        public Lot Lot { get; set; }
    }
}
