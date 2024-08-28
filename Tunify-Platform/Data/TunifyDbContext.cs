using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;

namespace Tunify_Platform.Data
{
    public class TunifyDbContext : IdentityDbContext<ApplicationUser>
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
            // PlaylistSongs and Playlist: Many-to-One
            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(ps => ps.Playlist)
                .WithMany(p => p.playlistSongs)
                .HasForeignKey(ps => ps.PlaylistId)
                .OnDelete(DeleteBehavior.Restrict);

            // PlaylistSongs and Songs: Many-to-One
            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.playlistSongs)
                .HasForeignKey(ps => ps.SongId)
                .OnDelete(DeleteBehavior.Restrict);

            // Users and Subscriptions: One-to-Many
            modelBuilder.Entity<User>()
                .HasOne(u => u.Subscription)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.SubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Users and Playlists: One-to-Many
            modelBuilder.Entity<Playlist>()
                .HasOne(p => p.User)
                .WithMany(u => u.Playlists)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Songs and Artists: Many-to-One
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Artist)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            // Songs and Albums: Many-to-One
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

            // Albums and Artists: Many-to-One
            modelBuilder.Entity<Album>()
                .HasOne(a => a.Artist)
                .WithMany(ar => ar.Albums)
                .HasForeignKey(a => a.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);


    ////////////////////////

            base.OnModelCreating(modelBuilder);

            //User
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "Rawan", Email = "rawan@gmail.com", Join_Date = new DateTime(2024 - 02 - 05), SubscriptionId = 1 },
                new User { UserId = 2, Username = "noor", Email = "noor@gmail.com", Join_Date = new DateTime(2024 - 02 - 05), SubscriptionId = 2 },
                new User { UserId = 3, Username = "ahmad", Email = "ahmad@gmail.com", Join_Date = new DateTime(2024 - 02 - 13), SubscriptionId = 1 }
                );

            // Seeding Album data
            modelBuilder.Entity<Album>().HasData(
                new Album { Id = 1, Album_Name = "25", Release_Date = new DateTime(2015, 11, 20), ArtistId = 1 },
                new Album { Id = 2, Album_Name = "24K Magic", Release_Date = new DateTime(2016, 11, 18), ArtistId = 2 }
                );

            //Song
            modelBuilder.Entity<Song>().HasData(
                new Song { Id = 1, Title = "Morning", ArtistId = 1, AlbumId = 1, Duration = TimeSpan.FromMinutes(2), Genre = "Pop" },
                new Song { Id = 2, Title = "Exciting Music", ArtistId = 2, AlbumId = 2, Duration = TimeSpan.FromMinutes(3), Genre = "Pop" }
                );

            //Playlist
            modelBuilder.Entity<Playlist>().HasData(
                new Playlist { PlaylistId = 1, UserId = 1, Playlist_Name = "Vibes1", Created_Date = new DateTime(2024 , 02 , 06) },
                new Playlist { PlaylistId = 2, UserId = 2, Playlist_Name = "Vibes2", Created_Date = new DateTime(2024 , 02 , 05) },
                new Playlist { PlaylistId = 3, UserId = 1, Playlist_Name = "Vibes3", Created_Date = new DateTime(2024, 04, 12) }

                );



            // Seeding Subscription data
            modelBuilder.Entity<Subscription>().HasData(
                new Subscription { SubscriptionId = 1, Subscription_Type = "Starter", Price = 7.99 },
                new Subscription { SubscriptionId = 2, Subscription_Type = "Deluxe", Price = 14.00 }
            );

            // Seeding Artist data
            modelBuilder.Entity<Artist>().HasData(
                new Artist { Id = 1, Name = "Adele", Bio = "British singer-songwriter, known for her deep, emotional ballads." },
                new Artist { Id = 2, Name = "Bruno Mars", Bio = "American singer-songwriter and performer, known for his dynamic stage presence and hit singles." }
            );


            // Seeding PlaylistSongs data
            modelBuilder.Entity<PlaylistSongs>().HasData(
                 new PlaylistSongs { PlaylistSongsId = 1, PlaylistId = 1, SongId = 1 },
                 new PlaylistSongs { PlaylistSongsId = 2, PlaylistId = 2, SongId = 2 }
                 );

            // Seeding roles and claims
            seedRoles(modelBuilder, "Admin", "create", "update", "delete");
            seedRoles(modelBuilder, "User", "update");

            // Seeding admin user
            seedAdminUser(modelBuilder);
        }

        private void seedRoles(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            // add claims for the users
            // complete


            modelBuilder.Entity<IdentityRole>().HasData(role);

            var claims = permissions.Select(permission => new IdentityRoleClaim<string>
            {
                Id = Guid.NewGuid().GetHashCode(), 
                RoleId = role.Id,
                ClaimType = "permission",
                ClaimValue = permission
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(claims);
        }

        private void seedAdminUser(ModelBuilder modelBuilder)
        {
            var adminUser = new ApplicationUser
            {
                Id = "admin_user_id",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
            };

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "AdminPassword123!");

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "admin",
                UserId = adminUser.Id
            });

            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
            {
                Id = Guid.NewGuid().GetHashCode(),
                UserId = adminUser.Id,
                ClaimType = "permission",
                ClaimValue = "full_access"
            });
        }


    }

 }
