using System.ComponentModel.DataAnnotations.Schema;

namespace CherryPeakTrading.Data.EF.Entities
{
    public class User
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int RegionID { get; set; }

        [ForeignKey(nameof(RegionID))]
        public Region Region { get; set; }

        public PersonalAccount PersonalAccount { get; set; }
    }
}
