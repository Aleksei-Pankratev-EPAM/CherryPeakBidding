﻿using System;
using System.Collections.Generic;

namespace CherryPeakTrading.Data.Entities
{
    public class Lot
    {
        public long Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public LotPicture? Picture { get; set; }

        public decimal MinPrice { get; set; }

        public int CreatorId { get; set; }

        public int RegionID { get; set; }

        public int TimeToLeave { get; set; }

        public int TimeStep { get; set; }

        public int StatusId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public List<Bid> Bids { get; set; } = new List<Bid>();
    }
}
