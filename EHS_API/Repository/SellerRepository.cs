using EHS_API.DTO;
using EHS_API.Models;
using EHS_API.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHS_API.Repository
{
    public class SellerRepository : IRepositories<UserDetails>, IGetRepository<UserDetails>, IGetSellerRepository<House>, ISellerDtoRepository<SellerHouseDto>
    {
        private readonly ApplicationDbContext _dbContext;
        public SellerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //Create new seller
        public async Task Create(UserDetails obj)
        {
            if (obj != null)
            {
                _dbContext.Users.Add(obj);
                await _dbContext.SaveChangesAsync();
            }

        }

        //Get All Sellers
        public async Task<IEnumerable<UserDetails>> GetAll()
        {
            var sellers = await _dbContext.Users.ToListAsync();
            return sellers;
        }

        //Get seller by id
        public async Task<UserDetails> GetById(int id)
        {
            var seller = await _dbContext.Users.FirstOrDefaultAsync(s => s.Id == id);
            if (seller != null)
            {
                return seller;
            }
            return null;
        }

        //delete seller
        public async Task<UserDetails> Delete(int id)
        {
            var sellerInDb = await _dbContext.Users.FindAsync(id);
            if (sellerInDb != null)
            {
                _dbContext.Users.Remove(sellerInDb);
                await _dbContext.SaveChangesAsync();

                return sellerInDb;
            }
            return null;
        }



        public async Task<UserDetails> Update(int id, UserDetails obj)
        {
            var sellerInDb = await _dbContext.Users.FindAsync(id);
            if (sellerInDb != null)
            {
                sellerInDb.FullName = obj.FullName;
                // sellerInDb.LastName = obj.LastName;
                sellerInDb.Email = obj.Email;
                sellerInDb.PhoneNumber = obj.PhoneNumber;



                _dbContext.Users.Update(sellerInDb);
                await _dbContext.SaveChangesAsync();
                return sellerInDb;
            }
            return null;
        }

        public async Task<IEnumerable<House>> GetAllMyProperties(int id)
        {
            var houses = await _dbContext.Houses.Where(h => h.UserDetailsId == id).ToListAsync();
            if (houses.Count > 0)
                return houses;
            else
                return null;
        }

        public async Task<IEnumerable<House>> GetPropertiesByCity(int id, int cityId)
        {
            var houses = await _dbContext.Houses.Where(h => h.UserDetailsId == id && h.CityId == cityId).ToListAsync();

            if (houses.Count > 0)
                return houses;
            else
                return null;
        }

        public async Task<SellerHouseDto> GetSellerDetails(int id)
        {
            var sellerHouseDto = await _dbContext.Houses.Include(h => h.UserDetails).Select(h => new SellerHouseDto
            {
                HouseId = h.Id,
                Address = h.Address,
                CityId = h.CityId,
                PriceRange = h.PriceRange,
                PhoneNumber = h.UserDetails.PhoneNumber,
                Email = h.UserDetails.Email,
                CityName = h.City.CityName,
                UserDetailsId = h.UserDetailsId,
                UserName = h.UserDetails.UserName

            }).ToListAsync();

            var sellerDetails = sellerHouseDto.FirstOrDefault(s => s.HouseId == id);

            return sellerDetails;
        }
    }
}