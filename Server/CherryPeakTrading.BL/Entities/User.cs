using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CherryPeakTrading.BL.Entities
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
