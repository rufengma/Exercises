using System;
using System.Collections.Generic;
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
        public DbSet<User> Users { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<MovieCrew> MovieCrews { get; set; }
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
            //modelBuilder.Entity<Genre>(ConfigureGenre);
            modelBuilder.Entity<Movie>().HasMany(m => m.Genres).WithMany(g => g.Movies).UsingEntity<Dictionary<string, object>>
                ("MovieGenre",
                m => m.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                g => g.HasOne<Movie>().WithMany().HasForeignKey("MovieId"));

            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<User>().HasMany(u => u.Roles).WithMany(r => r.Users)
                .UsingEntity<Dictionary<string, object>>("UserRole",
                u => u.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                r => r.HasOne<User>().WithMany().HasForeignKey("UserId"));

            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<MovieCrew>(ConfigureMovieCrew);
            //modelBuilder.Entity<Genre>(ConfigureGenre);
            modelBuilder.Entity<Crew>(ConfigureCrew);
            modelBuilder.Entity<Cast>(ConfigureCast);
            modelBuilder.Entity<Favorite>(ConfigureFavorite);
            modelBuilder.Entity<Purchase>(ConfigurePurchase);
            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<Role>(ConfigureRole);
            
        }

        private void ConfigureMovieCrew(EntityTypeBuilder<MovieCrew> builder)
        {
            builder.ToTable("MovieCrew");
            builder.HasKey(mc => new { mc.CrewId, mc.MovieId, mc.Department,mc.Job });
            builder.HasOne(mc => mc.Movie).WithMany(mc => mc.MovieCrews).HasForeignKey(mc => mc.MovieId);
            builder.HasOne(mc => mc.Crew).WithMany(mc => mc.MovieCrews).HasForeignKey(mc => mc.CrewId);
            builder.Property(mc => mc.Department).HasMaxLength(128);
            builder.Property(mc => mc.Job).HasMaxLength(128);
        }


        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            builder.ToTable("MovieCast");
            builder.HasKey(mc => new { mc.CastId, mc.MovieId, mc.Character });
            builder.HasOne(mc => mc.Movie).WithMany(mc => mc.MovieCasts).HasForeignKey(mc => mc.MovieId);
            builder.HasOne(mc => mc.Cast).WithMany(mc => mc.MovieCasts).HasForeignKey(mc => mc.CastId);
            builder.Property(mc => mc.Character).HasMaxLength(450);
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.FirstName).HasMaxLength(128);
            builder.Property(u => u.LastName).HasMaxLength(128);
            builder.Property(u => u.HashedPassword).HasMaxLength(1024);
            builder.Property(u => u.PhoneNumber).HasMaxLength(16);
            builder.Property(u => u.Salt).HasMaxLength(1024);
            builder.Property(u => u.ProfilePictureUrl).HasMaxLength(4096);
            builder.Property(u => u.IsLocked).HasDefaultValue(false);
        }

        private void ConfigureRole(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey("Id");
            builder.Property(r => r.Name).HasMaxLength(20);
        }

        private void ConfigureReview(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");
            builder.HasKey(r => new { r.MovieId, r.UserId });
            builder.Property(r => r.ReviewText).HasMaxLength(20000);
            builder.Property(r => r.Rating).HasColumnType("decimal(3, 2)");
            builder.Property(r => r.CreatedDate).HasDefaultValueSql("getdate()");
        }

        private void ConfigureFavorite(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorite");
            builder.HasKey("Id");
            builder.HasOne(f => f.Movie).WithMany(f => f.Favorites).HasForeignKey(f=>f.MovieId);
            builder.HasOne(f => f.User).WithMany(f => f.Favorites).HasForeignKey(f => f.UserId);
        }

        private void ConfigurePurchase(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purchase");
            builder.HasKey("Id");
            builder.HasOne(p => p.Movie).WithMany(p => p.Purchases).HasForeignKey(p => p.MovieId);
            builder.HasOne(p => p.User).WithMany(p => p.Purchases).HasForeignKey(p => p.UserId);
            builder.Property(p => p.TotalPrice).HasPrecision(18,2).HasDefaultValue(9.9m);
            builder.Property(p => p.PurchaseDateTime).HasColumnType("datetime2");
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
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(128);
            builder.Property(t => t.Gender).HasMaxLength(4096);
            builder.Property(t => t.TmdbUrl).HasMaxLength(4096);
            builder.Property(t => t.ProfilePath).HasMaxLength(2084);
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
