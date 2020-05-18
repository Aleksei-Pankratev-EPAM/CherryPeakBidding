using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace CherryPeakTrading.Data.Contracts.Entities
{
    public class Lot
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<Photo> Photos { get; set; } = new List<Photo>();

        public decimal StartPrice { get; set; }

        public decimal PriceStep { get; set; }

        public long CreatorId { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public User Creator { get; set; }

        public uint BiddingTime { get; set; }

        public Status Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<Bid> Bids { get; set; }
    }
}
