using System;

namespace CherryPeakTrading.API.Models.ViewModels
{
    public class BidViewModel
    {
        public long Id { get; set; }

        public Guid LotId { get; set; }

        public long BidderId { get; set; }

        public UserViewModel Bidder { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Offer { get; set; }

        public LotViewModel Lot { get; set; }
    }
}
