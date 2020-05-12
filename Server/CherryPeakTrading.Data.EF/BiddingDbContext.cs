using CherryPeakTrading.Data.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace CherryPeakTrading.Data.EF
{
    public class BiddingDbContext : DbContext
    {
        public BiddingDbContext(DbContextOptions<BiddingDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        #region Entities

        public DbSet<Lot> Lots { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PersonalAccount> PersonalAccounts { get; set; }
        public DbSet<Region> Regions { get; set; }

        #endregion Entities
    }
}
