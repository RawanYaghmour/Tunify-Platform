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
    }
}
