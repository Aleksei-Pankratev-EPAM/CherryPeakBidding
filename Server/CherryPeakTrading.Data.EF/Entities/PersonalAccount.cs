using System.ComponentModel.DataAnnotations.Schema;

namespace CherryPeakTrading.Data.EF.Entities
{
    public class PersonalAccount
    {
        public long ID { get; set; }

        public decimal Balance { get; set; }

        public long OwnerID { get; set; }

        [ForeignKey(nameof(OwnerID))]
        public User Owner { get; set; }
    }
}
