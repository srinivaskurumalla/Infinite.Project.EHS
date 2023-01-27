using EHS_API.Models;
using EHS_API.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace EHS_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HouseImagesController : ControllerBase
    {
        private readonly IRepositories<HouseImage> _imageRepositories;
        private readonly IGetRepository<HouseImage> _getImagesRepositories;

       

        public HouseImagesController(IRepositories<HouseImage> imageRepositories, IGetRepository<HouseImage> getImagesRepositories)
        {
            _imageRepositories = imageRepositories;
            _getImagesRepositories = getImagesRepositories;
        }

        //Get All Houses
        [HttpGet("GetAllHouseImages")]
        public async Task<IEnumerable<HouseImage>> GetAllHouses()
        {
            return await _getImagesRepositories.GetAll();
        }


        [HttpGet]
        [Route("GetHouseImageById/{id}", Name = "GetHouseImageById")]
        public async Task<IActionResult> GetHouseImageById(int id)
        {
            var image = await _getImagesRepositories.GetById(id);
            if (image != null)
            {
                return Ok(image);
            }
            return NotFound();
        }

        //Add House
        [HttpPost("CreateHouseImage")]
        public async Task<IActionResult> CreateHouse([FromBody] HouseImage houseImage)
        {
            if (ModelState.IsValid)
            {
                await _imageRepositories.Create(houseImage);
                return CreatedAtAction("GetHouseImageById", new { id = houseImage.Id }, houseImage);
            }
            return BadRequest();

        }

        //delete house

        [HttpDelete("DeleteHouseImage/{id}")]
        public async Task<IActionResult> DeleteHouseImage(int id)
        {
            var res = await _imageRepositories.Delete(id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("House image with id " + id + " not available");
        }


        //update house
        [HttpPut("UpdateHouseImage/{id}")]
        public async Task<IActionResult> UpdateHouseImage(int id, [FromBody] HouseImage houseImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _imageRepositories.Update(id, houseImage);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
