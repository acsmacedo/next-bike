using Microsoft.EntityFrameworkCore;
using NextBike.Data;
using NextBike.Interfaces;
using NextBike.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextBike.Services
{
    public class BikesService : IBikesService
    {
        private readonly NextBikeContext _context;

        public BikesService(NextBikeContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Bike data)
        {
            _context.Add(data);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bike = await _context.Bikes.FindAsync(id);

            _context.Bikes.Remove(bike);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bike>> FindAllAsync()
        {
            return await _context.Bikes.ToListAsync();
        }

        public async Task<Bike> FindByIdAsync(int id)
        {
            return await _context.Bikes.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Bike data)
        {
            try
            {
                _context.Update(data);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
