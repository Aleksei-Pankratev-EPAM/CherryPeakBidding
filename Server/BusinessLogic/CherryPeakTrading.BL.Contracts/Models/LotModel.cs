using System;

namespace CherryPeakTrading.BL.Contracts.Models
{
    public class LotModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal StartPrice { get; set; }

        public decimal PriceStep { get; set; }

        public uint BiddingTime { get; set; }

        public uint TimeToLive { get; set; }

        public DateTime CreatedAt { get; set; }

        public UserModel Creator { get; set; } = new UserModel();

        public Status Status { get; set; }
    }
}
