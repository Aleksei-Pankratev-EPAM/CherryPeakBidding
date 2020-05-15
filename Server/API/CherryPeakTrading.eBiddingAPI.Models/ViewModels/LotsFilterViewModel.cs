using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CherryPeakTrading.API.Models.ViewModels
{
    public class LotsFilterViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal StartPrice { get; set; }

        public decimal PriceStep { get; set; }

        public uint BiddingTime { get; set; }

        public DateTime CreatedAt { get; set; }

        public UserViewModel Creator { get; set; }

        public Status Status { get; set; }

        public uint TimeToLive { get; set; }
    }
}
