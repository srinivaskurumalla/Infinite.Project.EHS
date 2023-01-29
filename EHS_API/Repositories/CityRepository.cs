using EHS_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EHS_API.Repositories
{
    public class CityRepository : IGetRepository<City>
    {
        private readonly ApplicationDbContext _dbContext;

        public CityRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  async Task<IEnumerable<City>> GetAll()
        {
            var cities = await _dbContext.Cities.ToListAsync();
            return cities;
        }

        public async Task<City> GetById(int id)
        {
          
                var city = await _dbContext.Cities.FirstOrDefaultAsync(s => s.Id == id);
                if (city != null)
                {
                    return city;
                }
                return null;
            
        }
    }
}
