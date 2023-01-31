using EHS_API.Models;
using EHS_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EHS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyersController : ControllerBase
    {
        private readonly IGetBuyerCartRepository<BuyerCartModel> _BuyerCartRepository;
        private readonly IGetBuyerRepository<House> _BuyerRepository;
        private readonly IGetUserDetailsRepository<UserDetails> _UserDetailsRepository;

        public BuyersController(IGetBuyerCartRepository<BuyerCartModel> buyerCartRepository, IGetBuyerRepository<House> buyerRepository, IGetUserDetailsRepository<UserDetails> userDetailsRepository)
        {
            _BuyerCartRepository = buyerCartRepository;
            _BuyerRepository = buyerRepository;
            _UserDetailsRepository = userDetailsRepository;
        }

        //Used to get all the approved houses initially but also used for filtering the house by Type
        [HttpGet("GetHouseByType/{selectedValue}")]
        public async Task<IEnumerable<House>> GetHouseByType(string selectedValue = "All")
        {
            if(selectedValue=="All")
            {
                return await _BuyerRepository.GetAllApproved();
            }
            else
            {
                return await _BuyerRepository.GetHousesByType(selectedValue);
            }
        }
        [HttpGet("GetHouseByOption/{selectedValue}")]
        public async Task<IEnumerable<House>> GetHouseByOption(string selectedValue = "All")
        {
            if (selectedValue == "All")
            {
                return await _BuyerRepository.GetAllApproved();
            }
            else
            {
                return await _BuyerRepository.GetHousesByOption(selectedValue);
            }
        }

        [HttpGet("GetHouseByCity/{id}")]
        public async Task<IEnumerable<House>> GetHouseByCity(int id)
        {
            return await _BuyerRepository.GetHousesByCity(id);
        }

        [HttpGet]
        [Route("GetHouseDetails/{id}", Name = "GetHouseDetails")]
        public async Task<IActionResult> GetHouseDetails(int id)
        {
            var cart = await _BuyerRepository.GetById(id);
            if (cart != null)
            {
                return Ok(cart);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetMyCart/{id}", Name = "GetMyCart")]
        public async Task<IEnumerable<BuyerCartModel>> GetMyCart(int id)
        {
            return await _BuyerCartRepository.GetAllMyCart(id);

        }

        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart([FromBody]BuyerCartModel model)
        {
           var res = await _BuyerCartRepository.CheckCartExistence(model);
            if(res==null)
            {
                await _BuyerCartRepository.AddToCart(model);
                return CreatedAtAction("GetHouseDetails", new { Id = model.Id }, model);
            }
            else
            { return BadRequest("Item Already Exists"); }
           
        }

        [HttpDelete("DeleteFromCart")]
        public async Task<IActionResult> DeleteFromCart(int HouseId,int UserDetailsId)
        {
            var res = await _BuyerCartRepository.DeleteFromCart(HouseId,UserDetailsId);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("Item does not exist");
        }

        [HttpGet("GetAllHouses")]
        public async Task<IEnumerable<House>> GetAllHouses()
        {
            return await _BuyerRepository.GetAllApproved();
        }

        [HttpGet("GetUserId/{userName}")]
        public async Task<UserDetails> GetUserId(string userName)
        {
            return await _UserDetailsRepository.GetUserId(userName);
        }

        [HttpGet("GetAllHousesforBuyer")]
        public async Task<IEnumerable<House>> GetAllHousesforBuyer()
        {
            return await _BuyerRepository.GetAllApproved();
        }
    }
}
