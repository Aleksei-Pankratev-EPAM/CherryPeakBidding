namespace CherryPeakTrading.API.Models.ViewModels
{
    public class UserViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int RegionId { get; set; }

        public RegionViewModel Region { get; set; } = new RegionViewModel();

        public PersonalAccountViewModel PersonalAccount { get; set; } = new PersonalAccountViewModel();
    }
}
