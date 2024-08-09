using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class SongRepository : ISongRepository
    {
        private readonly TunifyDbContext _context;

        public SongRepository(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Song>> GetAllSongsAsync()
        {
            return await _context.Song.ToListAsync();
        }

        public async Task<Song> GetSongByIdAsync(int id)
        {
            return await _context.Song.FindAsync(id);
        }

        public async Task AddSongAsync(Song song)
        {
            await _context.Song.AddAsync(song);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSongAsync(Song song)
        {
            _context.Song.Update(song);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSongAsync(int id)
        {
            var song = await _context.Song.FindAsync(id);
            _context.Song.Remove(song);
            await _context.SaveChangesAsync();
        }
    }
}
