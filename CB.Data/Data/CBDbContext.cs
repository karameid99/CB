using CB.Models.Entities.Auth;
using CB.Models.Entities.Car;
using CB.Models.Entities.Client;
using CB.Models.Entities.Country;
using CB.Models.Entities.FAQ;
using CB.Models.Entities.Mailing;
using CB.Models.Mailing.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CB.Data.Data
{
    public class CBDbContext : IdentityDbContext<CBUser>
    {
        public CBDbContext(DbContextOptions<CBDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Auction>().HasOne(x => x.CarCity).WithMany(x => x.Auctions).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<CommentLike>().HasKey(x => new { x.ClientId, x.CommentId });
            builder.Entity<BidLike>().HasKey(x => new { x.ClientId, x.BidId });
            builder.Entity<AuctionWatch>().HasKey(x => new { x.ClientId, x.AuctionId });

        }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionLink> AuctionLinks { get; set; }
        public DbSet<BrandCar> BrandCars { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentLike> CommentLike { get; set; }
        public DbSet<AuctionWatch> AuctionWatches { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<BidLike> BidLike { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<FrequentlyAskedQuestion> FrequentlyAskedQuestions { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<MillingList> MillingLists { get; set; }
        public DbSet<Notfication> Notfications { get; set; }
    }
}
