using System;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class MovieShopDbContext:DbContext
    {
        //make a constructor
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
            //call MovieShopDbContext in the starter
        {
        }
        //DbSets as properties

        public DbSet<Genre> Genres { get; set; }//This is the mapping
        //DbSet is for mapping from Genre to Genres.
        //build a Genre type names Genres.
        public DbSet<Movie> Movies { get; set; }
        //to use fluent API, we need to oerride a method OnModelCreating
        public DbSet<Trailer> Trailers { get; set; }

        public DbSet<Cast> Casts { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(ConfigureMovie);
            //This is an action, action does not return anything.
            // output is void. input is entityTypeBuilder<movie>, output is void
            modelBuilder.Entity<Trailer>(ConfigureTrailer);
            modelBuilder.Entity<Genre>(ConfigureGenre);
            modelBuilder.Entity<Cast>(ConfigureCast);
            modelBuilder.Entity<Crew>(ConfigureCrew);
            modelBuilder.Entity<Favorite>(ConfigureFavorite);
            modelBuilder.Entity<Purchase>(ConfigurePurchase);
            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<Role>(ConfigureRole);
            modelBuilder.Entity<User>(ConfigureUser);
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.HasKey("Id");
            builder.Property(u => u.FirstName).HasMaxLength(128);
            builder.Property(u => u.LastName).HasMaxLength(128);
            builder.Property(u => u.DateOfBirth).HasColumnType("datetime2");
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.HashedPassword).HasMaxLength(1024);
            builder.Property(u => u.Salt).HasMaxLength(1024);
            builder.Property(u => u.PhoneNumber).HasMaxLength(16);
            builder.Property(u => u.LockoutEndDate).HasColumnType("datetime2");
            builder.Property(u => u.LastLoginDateTime).HasColumnType("datetime2");
        }

        private void ConfigureRole(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey("Id");
            builder.Property(r => r.Name).HasMaxLength(20);
        }

        private void ConfigureReview(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey("MovieId");
            builder.Property(r => r.UserId).IsRequired();
            builder.Property(r => r.Rating).HasPrecision(3, 2).IsRequired();
        }

        private void ConfigureFavorite(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorite");
            builder.HasKey("Id");
            builder.Property(f => f.MovieId).IsRequired();
            builder.Property(f => f.UserId).IsRequired();
        }

        private void ConfigurePurchase(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purchase");
            builder.HasKey("Id");
            builder.Property(p => p.UserId).IsRequired();
            //builder.Property(p => p.PurchaseNumber);//Here is a problem. Uniqueidentifier???
            builder.Property(p => p.TotalPrice).HasPrecision(18,2).IsRequired();
            builder.Property(p => p.PurchaseDateTime).HasColumnType("datetime2");
            builder.Property(p => p.MovieId).IsRequired();
        }

        private void ConfigureCrew(EntityTypeBuilder<Crew> builder)
        {
            builder.ToTable("Crew");
            builder.HasKey("Id");
            builder.Property(c => c.Gender).HasMaxLength(128);
            builder.Property(c => c.ProfilePath).HasMaxLength(2084);
        }

        private void ConfigureCast(EntityTypeBuilder<Cast> builder)
        {
            builder.ToTable("Cast");
            builder.HasKey("Id");
            builder.Property(c => c.Gender).HasMaxLength(128);
            builder.Property(c => c.ProfilePath).HasMaxLength(2084);
        }

        private void ConfigureGenre(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre");
            builder.HasKey("Id");
            builder.Property(g => g.Name).HasMaxLength(64);
        }

        private void ConfigureTrailer(EntityTypeBuilder<Trailer> builder)
        {
            builder.ToTable("Trailer");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TrailerUrl).HasMaxLength(2084);
            builder.Property(t => t.Name).HasMaxLength(2084);
        }

        private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
        {
            //specify all the Fluent API rules for this Model
            builder.ToTable ( "Movie");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).HasMaxLength(256).IsRequired();
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.Budget).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.Revenue).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Ignore(m => m.Rating);
        }
    }
}
