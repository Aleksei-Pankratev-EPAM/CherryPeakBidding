namespace CherryPeakTrading.BL.Contracts.Models
{
    public class UserModel
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int RegionId { get; set; }

        public int PersonalAccountId { get; set; }
    }
}
