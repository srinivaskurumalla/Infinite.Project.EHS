using EHS_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public AdminsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllPendings")]
        public async Task<IEnumerable<House>> GetAllPendingHouses()
        {
            var pendings = await _dbContext.Houses.Where(h => h.Status == null). ToListAsync();
            return pendings;
        }

        
    }
}
