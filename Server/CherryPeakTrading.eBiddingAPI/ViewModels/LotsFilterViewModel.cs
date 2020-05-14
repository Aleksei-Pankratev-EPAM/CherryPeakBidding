using System;

namespace CherryPeakTrading.API.ViewModels
{
    public class LotsFilterViewModel
    {
        public Guid Guid { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal StartPrice { get; set; }

        public decimal PriceStep { get; set; }

        public uint BiddingTime { get; set; }
    }
}
