using System.ComponentModel.DataAnnotations.Schema;

namespace CherryPeakTrading.Data.Contracts.Entities
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int RegionId { get; set; }

        [ForeignKey(nameof(RegionId))]
        public Region Region { get; set; } = new Region();

        public PersonalAccount PersonalAccount { get; set; } = new PersonalAccount();
    }
}
