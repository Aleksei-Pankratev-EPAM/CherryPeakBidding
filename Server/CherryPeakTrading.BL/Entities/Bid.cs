using System;
using System.Collections.Generic;
using System.Text;

namespace CherryPeakTrading.BL.Entities
{
	public class Bid
	{
		public long Id { get; set; }

		public int UserId { get; set; }

		public int LotIt { get; set; }

		public DateTime TimeStamp { get; set; }

		public double BidAmount { get; set; } 
	}
}
