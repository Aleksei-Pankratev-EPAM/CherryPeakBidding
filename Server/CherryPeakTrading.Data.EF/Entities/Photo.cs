using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CherryPeakTrading.Data.EF.Entities
{
    public class Photo
    {
        public long Id { get; set; }

        public string Url { get; set; }

        public Guid LotId { get; set; }

        [ForeignKey(nameof(LotId))]
        public Lot Lot { get; set; }
    }
}
