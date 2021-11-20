using NextBike.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextBike.Interfaces
{
    public interface IClientsService
    {
        Task<IEnumerable<Client>> FindAllAsync();
        Task<Client> FindByIdAsync(int id);
        Task AddAsync(Client data);
        Task UpdateAsync(Client data);
        Task DeleteAsync(int id);
    }
}
