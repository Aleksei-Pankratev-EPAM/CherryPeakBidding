using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CherryPeakTrading.Data.EF.Entities
{
    public class Photo
    {
        public long ID { get; set; }

        public string Url { get; set; }

        public Guid LotID { get; set; }

        [ForeignKey(nameof(LotID))]
        public Lot Lot { get; set; }
    }
}
