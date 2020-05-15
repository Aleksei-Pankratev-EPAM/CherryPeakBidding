using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CherryPeakTrading.Data.Contracts.Entities
{
    public class Photo
    {
        public long Id { get; set; }

        public string Url { get; set; } = string.Empty;

        public Guid LotId { get; set; }

        [ForeignKey(nameof(LotId))]
        public Lot Lot { get; set; } = new Lot();
    }
}
