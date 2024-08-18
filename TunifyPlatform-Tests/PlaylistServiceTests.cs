using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Services;
using Microsoft.EntityFrameworkCore;


namespace TunifyPlatform_Tests
{
    public class PlaylistServiceTests
    {
        private readonly Mock<TunifyDbContext> _mockContext;
        private readonly PlaylistRepository _playlistService;

        public PlaylistServiceTests()
        {
            // Initialize mock DbContext
            _mockContext = new Mock<TunifyDbContext>();

            // Set up in-memory DbSet for Playlists
            var playlistData = new List<Playlist>
        {
            new Playlist { PlaylistId = 1, Playlist_Name = "Vibes1" },
            new Playlist { PlaylistId = 2, Playlist_Name = "Vibes2" }
        }.AsQueryable();

            var mockPlaylistSet = new Mock<DbSet<Playlist>>();
            mockPlaylistSet.As<IQueryable<Playlist>>().Setup(m => m.Provider).Returns(playlistData.Provider);
            mockPlaylistSet.As<IQueryable<Playlist>>().Setup(m => m.Expression).Returns(playlistData.Expression);
            mockPlaylistSet.As<IQueryable<Playlist>>().Setup(m => m.ElementType).Returns(playlistData.ElementType);
            mockPlaylistSet.As<IQueryable<Playlist>>().Setup(m => m.GetEnumerator()).Returns(playlistData.GetEnumerator());

            // Set up in-memory DbSet for Songs
            var songData = new List<Song>
        {
            new Song { Id = 1, Title = "Morning", playlistSongs = new List<PlaylistSongs>() },
            new Song { Id = 2, Title = "Exciting Music", playlistSongs = new List<PlaylistSongs>() }
        }.AsQueryable();

            var mockSongSet = new Mock<DbSet<Song>>();
            mockSongSet.As<IQueryable<Song>>().Setup(m => m.Provider).Returns(songData.Provider);
            mockSongSet.As<IQueryable<Song>>().Setup(m => m.Expression).Returns(songData.Expression);
            mockSongSet.As<IQueryable<Song>>().Setup(m => m.ElementType).Returns(songData.ElementType);
            mockSongSet.As<IQueryable<Song>>().Setup(m => m.GetEnumerator()).Returns(songData.GetEnumerator());

            // Configure mock DbContext to return the mock DbSets
            _mockContext.Setup(c => c.Playlist).Returns(mockPlaylistSet.Object);
            _mockContext.Setup(c => c.Song).Returns(mockSongSet.Object);

            // Initialize the PlaylistService
            _playlistService = new PlaylistRepository(_mockContext.Object);
        }

        [Fact]
        public async Task AddSongToPlaylist_ShouldAddSongToPlaylist()
        {
            // Act
            await _playlistService.AddSongToPlaylist(1, 1);

            // Assert
            var playlist = await _mockContext.Object.Playlist.FindAsync(1);
            Assert.NotNull(playlist);
            Assert.Single(playlist.playlistSongs);
        }

        [Fact]
        public async Task GetSongsForPlaylist_ShouldReturnSongs()
        {
            // Act
            var songs = await _playlistService.GetAllSongsFromPlayList(1);

            // Assert
            Assert.NotNull(songs);
            Assert.Empty(songs); // Assuming initially no songs are in the playlist
        }
    }
}