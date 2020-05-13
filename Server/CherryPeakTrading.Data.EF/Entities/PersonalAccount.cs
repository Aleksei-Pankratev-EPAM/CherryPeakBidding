using System.ComponentModel.DataAnnotations.Schema;

namespace CherryPeakTrading.Data.EF.Entities
{
    public class PersonalAccount
    {
        public long Id { get; set; }

        public decimal Balance { get; set; }

        public long OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public User Owner { get; set; }
    }
}
