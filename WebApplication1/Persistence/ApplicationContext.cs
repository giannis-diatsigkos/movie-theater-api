using Microsoft.EntityFrameworkCore;
using MoviesTheaterApplication.Persistence.Entities;
using System;

namespace MoviesTheaterApplication.Persistence
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserEntity> User { get; set; }
        public DbSet<MovieEntity> Movies { get; set; }

        public DbSet<LikedMovieEntity> LikedMovie { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }

        public DbSet<CastMemberEntity> CastMembers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MovieEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                //entity.HasMany(e => e.LikedByUsers)
                //      .WithOne(e => e.Movie)
                //      .HasForeignKey(e => e.MovieId);
                // ...other property configurations...
            });

            modelBuilder.Entity<PersonEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<CastMemberEntity>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.PersonId });

                entity.HasOne(cm => cm.Movie)
                      .WithMany(m => m.CastMembers)
                      .HasForeignKey(cm => cm.MovieId);

                entity.HasOne(cm => cm.Person)
                      .WithMany(p => p.CastMembers)
                      .HasForeignKey(cm => cm.PersonId);
            });

            modelBuilder.Entity<LikedMovieEntity>().HasKey(likedMovie => new { likedMovie.UserId, likedMovie.MovieId });
            modelBuilder.Entity<LikedMovieEntity>()
                      .HasOne(lm => lm.User)
                      .WithMany(u => u.LikedMovies)
                      .HasForeignKey(lm => lm.UserId);

            modelBuilder.Entity<LikedMovieEntity>()
                    .HasOne(lm => lm.Movie)
                    .WithMany(m => m.LikedByUsers)
                    .HasForeignKey(lm => lm.MovieId);

        }
    }
}
