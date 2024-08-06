using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;

namespace Tunify_Platform.Data
{
    public class TunifyDbContext : DbContext
    {
        public TunifyDbContext(DbContextOptions<TunifyDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<PlaylistSongs> PlaylistSongs { get; set; }
        public DbSet<Subscription> Subscription { get; set; }

        //OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //User
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "Rawan", Email = "rawan@gmail.com", Join_Date = new DateTime(2024 - 02 - 05), SubscriptionId = 1 },
                new User { UserId = 2, Username = "noor", Email = "noor@gmail.com", Join_Date = new DateTime(2024 - 02 - 05), SubscriptionId = 2 },
                new User { UserId = 3, Username = "ahmad", Email = "ahmad@gmail.com", Join_Date = new DateTime(2024 - 02 - 13), SubscriptionId = 1 }
                );

            //Song
            modelBuilder.Entity<Song>().HasData(
                new Song { SongId = 1, Title = "Morning", ArtistId = 1, AlbumId = 1, Duration = TimeSpan.FromMinutes(2), Genre = "Pop" },
                new Song { SongId = 2, Title = "Exciting Music", ArtistId = 1, AlbumId = 1, Duration = TimeSpan.FromMinutes(3), Genre = "Hip Hop" }
            );

            //Playlist
            modelBuilder.Entity<Playlist>().HasData(
                new Playlist { PlaylistId = 1, UserId = 1, Playlist_Name = "Vibes1", Created_Date = new DateTime(2024 - 02 - 06) },
                new Playlist { PlaylistId = 2, UserId = 2, Playlist_Name = "Vibes2", Created_Date = new DateTime(2024 - 02 - 05) }
            );
        }


    }

 }
