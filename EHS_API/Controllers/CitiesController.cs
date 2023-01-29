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

        public CitiesController(IGetRepository<City> getCityRepositories)
        {
            _getCityRepositories = getCityRepositories;
        }


        //Get All Sellers
        [HttpGet("GetAllCities")]
        public async Task<IEnumerable<City>> GetAllSellers()
        {
            return await _getCityRepositories.GetAll();
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
    }
}
