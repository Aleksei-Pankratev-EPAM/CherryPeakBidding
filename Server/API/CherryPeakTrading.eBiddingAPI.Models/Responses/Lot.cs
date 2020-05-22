using System;
using System.Collections.Generic;
using System.Text;

namespace CherryPeakTrading.API.Models.Responses
{
    public class Lot
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal StartPrice { get; set; }

        public decimal PriceStep { get; set; }

        public uint TimeToLive { get; set; }

        public uint BiddingTime { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
