namespace CherryPeakTrading.BL.Contracts.Models
{
    public class PersonalAccountModel
    {
        public long Id { get; set; }

        public decimal Balance { get; set; }

        public long OwnerId { get; set; }

        public UserModel Owner { get; set; } = new UserModel();
    }
}
