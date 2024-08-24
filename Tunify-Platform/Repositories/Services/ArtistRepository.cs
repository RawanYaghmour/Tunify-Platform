using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly TunifyDbContext _context;

        public ArtistRepository(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return await _context.Artist.ToListAsync();
        }

        public async Task<Artist> GetArtistByIdAsync(int id)
        {
            return await _context.Artist.FindAsync(id);
        }

        public async Task AddArtistAsync(Artist artist)
        {
            await _context.Artist.AddAsync(artist);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateArtistAsync(Artist artist)
        {
            _context.Artist.Update(artist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArtistAsync(int id)
        {
            var artist = await _context.Artist.FindAsync(id);
            _context.Artist.Remove(artist);
            await _context.SaveChangesAsync();
        }

        public async Task<Song> AddSongToArtist(int artistId, int songId)
        {
            var song = await _context.Song.FindAsync(songId);
            if (song != null)
            {
                song.ArtistId = artistId;
                _context.Entry(song).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            var songs = _context.Song.Where(a => a.ArtistId == artistId).FirstOrDefault();
            return songs;
        }

        public async Task<List<Song>> GetAllSongsFromArtist(int artistId)
        {
            var Song = await _context.Song.Where(s => s.ArtistId == artistId).ToListAsync();
            return Song;
        }

    }
}
