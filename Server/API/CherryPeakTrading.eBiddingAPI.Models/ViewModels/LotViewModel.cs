using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CherryPeakTrading.API.Models.ViewModels
{
    public class LotViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal StartPrice { get; set; }

        [Required]
        public decimal PriceStep { get; set; }

        [Required]
        public uint BiddingTime { get; set; }
    }
}
