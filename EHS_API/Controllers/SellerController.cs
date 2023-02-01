using EHS_API.Models;
using EHS_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EHS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly IRepositories<UserDetails> _sellerRepository;
        private readonly IGetRepository<UserDetails> _getSellerRepositories;
        private readonly IGetSellerRepository<House> _houseRepository;
        public SellerController(IRepositories<UserDetails> sellerRepository, IGetRepository<UserDetails> getSellerRepositories, IGetSellerRepository<House> houseRepository)
        {
            _sellerRepository = sellerRepository;
            _getSellerRepositories = getSellerRepositories;
            _houseRepository = houseRepository;
        }

        //Get All Sellers
        [HttpGet("GetAllSellers")]
        public async Task<IEnumerable<UserDetails>> GetAllSellers()
        {
            return await _getSellerRepositories.GetAll();
        }

        //Get Seller By Id

        [HttpGet]
        [Route("GetSellerById/{id}", Name = "GetSellerById")]
        public async Task<IActionResult> GetSellerById(int id)
        {
            var seller = await _getSellerRepositories.GetById(id);
            if (seller != null)
            {
                return Ok(seller);
            }
            return NotFound();
        }

        //Add new Seller
        [HttpPost("CreateSeller")]
        public async Task<IActionResult> CreateHouse([FromBody] UserDetails seller)
        {
            if (ModelState.IsValid)
            {
                await _sellerRepository.Create(seller);
                return CreatedAtAction("GetSellerById", new { Id = seller.Id }, seller);
            }
            return BadRequest();

        }

        //delete seller

        [HttpDelete("DeleteSeller/{id}")]
        public async Task<IActionResult> DeleteSeller(int id)
        {
            var res = await _sellerRepository.Delete(id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("Seller with id " + id + " not available");
        }


        //update seller
        [HttpPut("UpdateSeller/{id}")]
        public async Task<IActionResult> UpdateSeller(int id, [FromBody] UserDetails seller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _sellerRepository.Update(id, seller);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        //get All houses of seller

        [HttpGet("GetAllMyProperties/{id}")]
        public async Task<IActionResult> GetAllMyProperties(int id)
        {
            var res = await _houseRepository.GetAllMyProperties(id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("You dont have any propeeties");
        }

        [HttpGet("GetPropertiesByCity/{id}")]
        public async Task<IActionResult> GetPropertiesByCity(int id, int cityId)
        {
            var res = await _houseRepository.GetPropertiesByCity(id, cityId);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("There are no properties in this city");
        }
    }
}