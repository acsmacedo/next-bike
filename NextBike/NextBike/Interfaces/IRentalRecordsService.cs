using NextBike.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextBike.Interfaces
{
    public interface IRentalRecordsService
    {
        Task<IEnumerable<RentalRecords>> FindAllAsync();
        Task<RentalRecords> FindByBikeIdAsync(int bikeId);
        Task AddAsync(RentalRecords data);
        Task UpdateAsync(RentalRecords data);
    }
}
