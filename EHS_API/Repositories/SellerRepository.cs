using EHS_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHS_API.Repositories
{
    public class SellerRepository : IRepositories<Seller>, IGetRepository<Seller>,IGetSellerRepository<House>
    {
        private readonly ApplicationDbContext _dbContext;
        public SellerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //Create new seller
        public async Task Create(Seller obj)
        {
            if (obj != null)
            {
                _dbContext.Sellers.Add(obj);
                 await _dbContext.SaveChangesAsync();
            }
           
        }

        //Get All Sellers
        public async Task<IEnumerable<Seller>> GetAll()
        {
            var sellers = await _dbContext.Sellers.ToListAsync();
            return sellers;
        }

        //Get seller by id
        public async Task<Seller> GetById(int id)
        {
            var seller = await _dbContext.Sellers.FirstOrDefaultAsync(s => s.Id == id);
            if (seller != null)
            {
                return seller;
            }
            return null;
        }

        //delete seller
        public async Task<Seller> Delete(int id)
        {
            var sellerInDb = await _dbContext.Sellers.FindAsync(id);
            if (sellerInDb != null)
            {
                _dbContext.Sellers.Remove(sellerInDb);
                await _dbContext.SaveChangesAsync();

                return sellerInDb;
            }
            return null;
        }

       

        public async Task<Seller> Update(int id, Seller obj)
        {
            var sellerInDb = await _dbContext.Sellers.FindAsync(id);
            if (sellerInDb != null)
            {
                sellerInDb.FirstName = obj.FirstName;
                sellerInDb.LastName = obj.LastName;
                sellerInDb.Email = obj.Email;
                sellerInDb.PhoneNumber = obj.PhoneNumber;
                

               
                _dbContext.Sellers.Update(sellerInDb);
                await _dbContext.SaveChangesAsync();
                return sellerInDb;
            }
            return null;
        }

         public async Task<IEnumerable<House>> GetAllMyProperties(int id)
        {
            var houses = await _dbContext.Houses.Where(h => h.SellerId == id).ToListAsync();
            if(houses.Count> 0)
                return houses;
            else 
                return null;
        }
        
        public async Task<IEnumerable<House>> GetPropertiesByCity(int id, int cityId)
        {
            var houses = await _dbContext.Houses.Where(h => h.SellerId== id &&h.CityId == cityId).ToListAsync();
            
            if(houses.Count> 0)
                 return houses;
            else 
                return null;
        }
    }
}
