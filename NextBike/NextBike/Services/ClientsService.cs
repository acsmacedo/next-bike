using Microsoft.EntityFrameworkCore;
using NextBike.Data;
using NextBike.Interfaces;
using NextBike.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextBike.Services
{
    public class ClientsService : IClientsService
    {
        private readonly NextBikeContext _context;

        public ClientsService(NextBikeContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Client data)
        {
            _context.Add(data);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            _context.Clients.Remove(client);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> FindAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> FindByIdAsync(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Client data)
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
