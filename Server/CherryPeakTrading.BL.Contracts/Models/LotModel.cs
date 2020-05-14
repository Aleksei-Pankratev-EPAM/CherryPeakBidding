using System;
using System.Collections.Generic;

namespace CherryPeakTrading.BL.Contracts.Models
{
    public class LotModel
    {
        public long Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<PhotoModel> Photos { get; set; } = new List<PhotoModel>();

        public decimal StartPrice { get; set; }

        public decimal PriceStep { get; set; }

        public uint TimeToLive { get; set; }

        public uint BiddingTime { get; set; }

        public DateTime CreatedAt { get; set; }

        public UserModel Creator { get; set; } = new UserModel();

        public int RegionId { get; set; }

        public int Status { get; set; }

        public List<BidModel> Bids { get; set; } = new List<BidModel>();
    }
}
