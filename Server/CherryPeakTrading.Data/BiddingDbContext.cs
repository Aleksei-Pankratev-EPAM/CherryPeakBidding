using CherryPeakTrading.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CherryPEakTrading.Data.EF
{
	public class BiddingDbContext : DbContext
	{
		public BiddingDbContext(DbContextOptions<BiddingDbContext> options)
			: base(options)
		{
		}
		#region Entities

		public DbSet<Lot> Lots { get; set; }
		public DbSet<LotPicture> LotPictures { get; set; }
		public DbSet<Bid> Bids { get; set; }
		public DbSet<User> Users { get; set; }

		#endregion
	}
}
