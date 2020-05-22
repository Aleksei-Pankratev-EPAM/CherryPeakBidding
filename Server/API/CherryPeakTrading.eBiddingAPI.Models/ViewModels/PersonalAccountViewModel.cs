namespace CherryPeakTrading.API.Models.ViewModels
{
    public class PersonalAccountViewModel
    {
        public long Id { get; set; }

        public decimal Balance { get; set; }

        public long OwnerId { get; set; }

        public UserViewModel Owner { get; set; }
    }
}
