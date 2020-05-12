using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CherryPeakTrading.Data.EF.Entities
{
    public class Lot
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<Photo> Photos { get; set; }

        public decimal StartPrice { get; set; }

        public decimal PriceStep { get; set; }

        public long CreatorID { get; set; }

        [ForeignKey(nameof(CreatorID))]
        public User Creator { get; set; }

        public uint TimeToLive { get; set; }

        public uint BiddingTime { get; set; }

        public Status Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<Bid> Bids { get; set; }
    }
}
