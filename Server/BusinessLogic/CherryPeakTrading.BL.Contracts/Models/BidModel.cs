using System;

namespace CherryPeakTrading.BL.Contracts.Models
{
    public class BidModel
    {
        public long Id { get; set; }

        public Guid LotId { get; set; }

        public long BidderId { get; set; }

        public UserModel Bidder { get; set; } = new UserModel();

        public DateTime CreatedAt { get; set; }

        public decimal Offer { get; set; }

        public LotModel Lot { get; set; } = new LotModel();
    }
}
