using EHS_API.Models;
using EHS_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EHS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IGetRepository<City> _getCityRepositories;
        private readonly IStateCityRepository<City> _getStateCitiesRepositories;
        private readonly IStateRepository<State> _getSateReposotiries;

        public CitiesController(IGetRepository<City> getCityRepositories,IStateCityRepository<City> getStateCitiesRepositories, IStateRepository<State> getSateReposotiries)
        {
            _getCityRepositories = getCityRepositories;
            _getStateCitiesRepositories = getStateCitiesRepositories;
            _getSateReposotiries = getSateReposotiries;
        }


        //Get All Sellers
        [HttpGet("GetAllCities")]
        public async Task<IEnumerable<City>> GetAllSellers()
        {
            return await _getCityRepositories.GetAll();
        }

        [HttpGet("GetAllStates")]
        public async Task<IEnumerable<State>> GetAllStates()
        {
            return await _getSateReposotiries.GetStates();
        }

        [HttpGet]
        [Route("GetcityById/{id}")]
        public async Task<IActionResult> GetSellerById(int id)
        {
            var city = await _getCityRepositories.GetById(id);
            if (city != null)
            {
                return Ok(city);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetCitiesFromState/{stateId}")]
        public async Task<IActionResult> GetCitiesFromState(int stateId)
        {
            var cities = await _getStateCitiesRepositories.GetCities(stateId);
            if (cities != null)
            {
                return Ok(cities);
            }
            return NotFound();
        }
    }
}
