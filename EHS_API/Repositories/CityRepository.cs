using EHS_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHS_API.Repositories
{
    public class CityRepository : IGetRepository<City>,IStateCityRepository<City>,IStateRepository<State>
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

        public async Task<IEnumerable<City>> GetCities(int stateId)
        {
            var citiesFromState = await _dbContext.Cities.Where(c => c.StateId == stateId).ToListAsync();
            return citiesFromState;
        }

        public async Task<IEnumerable<State>> GetStates()
        {
            var states = await _dbContext.States.ToListAsync();
            return states;
        }
    }
}
