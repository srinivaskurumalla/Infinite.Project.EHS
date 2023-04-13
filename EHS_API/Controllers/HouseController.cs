using EHS_API.Models;
using EHS_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EHS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {

        private readonly IRepositories<House> _houseRepositories;
        private readonly IGetRepository<House> _getHouseRepositories;
        private readonly ICityRepository<House> _cityRepository;
        private readonly IStateCityRepository<City> _stateCityRepository;
        private readonly IStateRepository<State> _stateRepository;

        public HouseController(IRepositories<House> houseRepositories, IGetRepository<House> getHouseRepositories,ICityRepository<House> cityRepository,IStateRepository<State> stateRepository,IStateCityRepository<City> stateCityRepository)
        {
            _houseRepositories = houseRepositories;
            _getHouseRepositories = getHouseRepositories;
            _cityRepository = cityRepository;
            _stateCityRepository = stateCityRepository;
            _stateRepository = stateRepository;
        }

        //Get All Houses
      
        [HttpGet("GetAllHouses")]
        public async Task<IEnumerable<House>> GetAllHouses()
        {
            return await _getHouseRepositories.GetAll();
        }
       
        [HttpGet("GetAllHousesBySellerName/{sellerName}")]
        public async Task<IActionResult> GetAllHousesBySellerId(string sellerName)
        {
            var houses = await _cityRepository.GetAllHousesBySellerName(sellerName);
            if (houses != null)
            {
                return Ok(houses);
            }
            return NotFound("No houses in this city");
          // return await _cityRepository.GetAllHousesBySellerId();
        }
        [HttpGet]
        [Route("GetHouseById/{id}", Name = "GetHouseById")]
        public async Task<IActionResult> GetHouseById(int id)
        {
            var house = await _getHouseRepositories.GetById(id);
            if (house != null)
            {
                return Ok(house);
            }
            return NotFound();
        }
      
        //Add House
        [HttpPost("CreateHouse")]
        public async Task<IActionResult> CreateHouse([FromBody] House house)
        {
            if(ModelState.IsValid)
            {
                house.Status ??= "PENDING";
                await _houseRepositories.Create(house);
                return CreatedAtAction("GetHouseById", new { id = house.Id }, house);
            }
            return BadRequest();

        }

        //delete house
      
        [HttpDelete("DeleteHouse/{id}")]
        public async Task<IActionResult> DeleteHouse(int id)
        {
            var res = await _houseRepositories.Delete(id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("House with id " + id + " not available");
        }

       
        //update house
        [HttpPut("UpdateHouse/{id}")]
        public async Task<IActionResult> UpdateHouse(int id, [FromBody] House house)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _houseRepositories.Update(id, house);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("GetHousesByCityId/{id}")]
        public async Task<IActionResult> GetHousesByCityId(int id)
        {
            var houses = await _cityRepository.GetAllHouseByCityId(id);
            if (houses != null)
            {
                return Ok(houses);
            }
            return NotFound("No houses in this city");
        }

      
        [HttpGet("GetAllStates")]
        public async Task<IActionResult> GetStates()
        {
            var states = await _stateRepository.GetStates();
            return Ok(states);
        }

        [HttpGet("GetCitiesByStateId/{stateId}")]
        public async Task<IActionResult> GetCities(int stateId)
        {
            var cities = await _stateCityRepository.GetCities(stateId);
            return Ok(cities);
        }
    }
}
