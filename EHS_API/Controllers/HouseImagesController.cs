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
    public class HouseImagesController : ControllerBase
    {
        private readonly IGetRepository<HouseImage> _getRepository;
        private readonly IRepositories<HouseImage> _repository;

        public HouseImagesController(IGetRepository<HouseImage> getRepository, IRepositories<HouseImage> repository)
        {
            _getRepository = getRepository;
            _repository = repository;
        }
        //Get All Houses
        [HttpGet("GetAllHouseImages")]
        public async Task<IEnumerable<HouseImage>> GetAllHouses()
        {
            return await _getRepository.GetAll();
        }


        [HttpGet]
        [Route("GetHouseImageById/{id}", Name = "GetHouseImageById")]
        public async Task<IActionResult> GetHouseImageById(int id)
        {
            var houseImg = await _getRepository.GetById(id);
            if (houseImg != null)
            {
                return Ok(houseImg);
            }
            return NotFound();
        }

        //Add House
        [HttpPost("CreateHouseImage")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateHouseImage([FromBody] HouseImage houseImg)
        {
            if (ModelState.IsValid)
            {
                await _repository.Create(houseImg);
                return CreatedAtAction("GetHouseById", new { id = houseImg.Id }, houseImg);
            }
            return BadRequest();

        }

        //delete house images
        [HttpDelete("DeleteHouseImage/{id}")]
        public async Task<IActionResult> DeleteHouseImage(int id)
        {
            var res = await _repository.Delete(id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("Image with id " + id + " not available");
        }

        //update image
        [HttpPut("UpdateImage/{id}")]
        public async Task<IActionResult> UpdateImage(int id, [FromBody] HouseImage houseImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _repository.Update(id, houseImage);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}

