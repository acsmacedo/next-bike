using NextBike.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextBike.Interfaces
{
    public interface IBikesService
    {
        Task<IEnumerable<Bike>> FindAllAsync();
        Task<Bike> FindByIdAsync(int id);
        Task AddAsync(Bike data);
        Task UpdateAsync(Bike data);
        Task DeleteAsync(int id);
    }
}
