using Microsoft.EntityFrameworkCore;
using System;

namespace auction.Models
{
    public class OrganizationsCatalogDBContext : DbContext
    {
        private string _dbConnectionString;
        public DbSet<UserDBModel> Users { get; set; }
        public DbSet<AuctionInfoDBModel> auctionInfo { get; set; }
        public DbSet<StavkaUserDBModel> stavkaUser { get; set; }
        public DbSet<StavkaDBModel> stavka { get; set; }
        public DbSet<WebUsersDBModel> webUsers { get; set; }
        public DbSet<WebAuctionDBModel> webAuction { get; set; }
        public DbSet<WebDBModel> web { get; set; }

        public OrganizationsCatalogDBContext(string dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbConnectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null);
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}
