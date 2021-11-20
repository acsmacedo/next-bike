using Microsoft.EntityFrameworkCore;
using NextBike.Data;
using NextBike.Interfaces;
using NextBike.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextBike.Services
{
    public class RentalRecordsService : IRentalRecordsService
    {
        private readonly NextBikeContext _context;

        public RentalRecordsService(NextBikeContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RentalRecords data)
        {
            _context.Add(data);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RentalRecords>> FindAllAsync()
        {
            return await _context.RentalRecords.Include(x => x.Bike).Include(x => x.Client).ToListAsync();
        }

        public async Task<RentalRecords> FindByIdAsync(int id)
        {
            return await _context.RentalRecords
                .Include(x => x.Bike)
                .Include(x => x.Client)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(RentalRecords data)
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
