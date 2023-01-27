using EHS_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHS_API.Repositories
{
    public class AdminRepository : IAdminRepository<House>
    {
        private readonly ApplicationDbContext _dbContext;
        public AdminRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<House>> GetAll()
        {

            var pendings = await _dbContext.Houses.Where(h => h.Status == null || h.Status == "REJECTED" || h.Status == "APPROVED").ToListAsync();
            return pendings;
        }

        public async Task<IEnumerable<House>> GetAllPendings()
        {

            var pendings = await _dbContext.Houses.Where(h => h.Status == null ).ToListAsync();
            return pendings;
        }
        public async Task<IEnumerable<House>> GetAllRejected()
        {

            var pendings = await _dbContext.Houses.Where(h =>  h.Status == "REJECTED").ToListAsync();
            return pendings;
        }
        public async Task<IEnumerable<House>> GetAllApproved()
        {

            var pendings = await _dbContext.Houses.Where(h => h.Status == "APPROVED").ToListAsync();
            return pendings;
        }
        public async Task<House> Reject(int id)
        {
            var rejectProperty = await _dbContext.Houses.FindAsync(id);
            if (rejectProperty != null)
            {
               rejectProperty.Status = "REJECTED";

                _dbContext.Houses.Update(rejectProperty);
                await _dbContext.SaveChangesAsync();

                return rejectProperty;
            }
            return null;
        }

        public async Task<House> Approve(int id)
        {
            var rejectProperty = await _dbContext.Houses.FindAsync(id);
            if (rejectProperty != null)
            {
                rejectProperty.Status = "APPROVED";

                _dbContext.Houses.Update(rejectProperty);
                await _dbContext.SaveChangesAsync();

                return rejectProperty;
            }
            return null;
        }

        public async Task<IEnumerable<House>> ViewByRegion(int cityId)
        {
            var houses = await _dbContext.Houses.Where(h => h.CityId == cityId).ToListAsync();
            if(houses.Count> 0)
            {
                return houses;
            }
            return null;
        }

        public async Task<IEnumerable<House>> ViewByOwner(string modeType)
        {
            var houses = await _dbContext.Houses.Where(h => h.PropertyOption == modeType).ToListAsync();
            if (houses.Count > 0)
            {
                return houses;
            }
            return null;
        }
    }
}
