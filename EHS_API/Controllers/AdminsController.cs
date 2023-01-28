using EHS_API.Models;
using EHS_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;


namespace EHS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminRepository<House> _adminRepository;
        public AdminsController(IAdminRepository<House> adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet("GetProperties/{selectedValue}")]
        // [ApiExplorerSettings(IgnoreApi = true)]

        public async Task<IEnumerable<House>> GetData(string selectedValue = "All")
        {
            if (selectedValue == "All")
            {
                return await _adminRepository.GetAll();
            }
            else if (selectedValue == "Rejected")
            {
                return await _adminRepository.GetAllRejected();
            }
            else if (selectedValue == "Pending")
            {
                return await _adminRepository.GetAllPendings();
            }
            else if (selectedValue == "Approved")
            {
                return await _adminRepository.GetAllApproved();
            }
            return await _adminRepository.GetAll(); ;

        }






        /*
                        [HttpGet("GetAllProperties")]
                public async Task<IEnumerable<House>> GetAllProperties()
                {
                    return await _adminRepository.GetAll();
                }
                [HttpGet("GetAllPendings")]
                public async Task<IEnumerable<House>> GetAllPendings()
                {
                    return await _adminRepository.GetAllPendings();
                }
                [HttpGet("GetAllRejected")]
                public async Task<IEnumerable<House>> GetAllRejected()
                {
                    return await _adminRepository.GetAllRejected();
                }
                [HttpGet("GetAllApproved")]
                public async Task<IEnumerable<House>> GetAllApproved()
                {
                    return await _adminRepository.GetAllApproved() ;
                }*/


        [HttpPut("RejectHouse/{id}")]
        public async Task<IActionResult> RejectHouse(int id)
        {
            var res = await _adminRepository.Reject(id);

            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("House with id " + id + " not available");
        }

        [HttpPut("ApproveHouse/{id}")]
        public async Task<IActionResult> ApproveHouse(int id)
        {
            var res = await _adminRepository.Approve(id);

            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("House with id " + id + " not available");
        }


        [HttpGet("ViewByRegion/{cityId}")]
        public async Task<IActionResult> ViewByRegion(int cityId)
        {
            var res = await _adminRepository.ViewByRegion(cityId);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("No Proeprties availabel in selected Region");
        }

        [HttpGet("ViewByOwner/{modeType}")]
        public async Task<IActionResult> ViewByOwner(string modeType)
        {
            var res = await _adminRepository.ViewByOwner(modeType);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("No Proeprties availabel in selected mode");
        }
    }
}