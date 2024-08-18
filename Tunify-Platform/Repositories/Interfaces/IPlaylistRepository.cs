using Tunify_Platform.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<IEnumerable<Playlist>> GetAllPlaylistsAsync();
        Task<Playlist> GetPlaylistByIdAsync(int id);
        Task AddPlaylistAsync(Playlist playlist);
        Task UpdatePlaylistAsync(Playlist playlist);
        Task DeletePlaylistAsync(int id);
        Task<bool> AddSongToPlaylist(int playlistId, int songId);
        Task<List<Song>> GetAllSongsFromPlayList(int playlistId);
    }
}
