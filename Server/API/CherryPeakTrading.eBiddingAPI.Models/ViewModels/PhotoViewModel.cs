using System;

namespace CherryPeakTrading.API.Models.ViewModels
{
    public class PhotoViewModel
    {
        public long Id { get; set; }
        public string Url { get; set; }

        public Guid LotId { get; set; }

        public LotsFilterViewModel Lot { get; set; } = new LotsFilterViewModel();
    }
}
