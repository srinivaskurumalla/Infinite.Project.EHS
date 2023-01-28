﻿using EHS_API.Models;
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
    public class HouseController : ControllerBase
    {
        private readonly IRepositories<House> _houseRepositories;
        private readonly IGetRepository<House> _getHouseRepositories;

        public HouseController(IRepositories<House> houseRepositories, IGetRepository<House> getHouseRepositories)
        {
            _houseRepositories = houseRepositories;
            _getHouseRepositories = getHouseRepositories;
        }

        //Get All Houses
        [HttpGet("GetAllHouses")]
        public async Task<IEnumerable<House>> GetAllHouses()
        {
            return await _getHouseRepositories.GetAll();
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
    }
}