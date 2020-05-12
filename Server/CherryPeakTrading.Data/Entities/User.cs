namespace CherryPeakTrading.Data.Entities
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; } = "";

        public string Email { get; set; } = "";

        public int RegionId { get; set; }

        public int PersonalAccountId { get; set; }
    }
}
