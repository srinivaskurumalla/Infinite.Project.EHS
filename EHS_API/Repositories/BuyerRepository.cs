using EHS_API.Models;
using EHS_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHS_API.Repositories
{
    public class BuyerRepository : IGetBuyerRepository<House>, IGetBuyerCartRepository<BuyerCartModel>, IGetUserDetailsRepository<UserDetails>
    {
        private readonly ApplicationDbContext _dbContext;
        public BuyerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddToCart(BuyerCartModel obj)
        {

            if (obj != null)
            {
                _dbContext.BuyerCarts.Add(obj);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task<BuyerCartModel> DeleteFromCart(int Houseid, int UserDetailsId)
        {
            var CartsInDb = await _dbContext.BuyerCarts.FirstOrDefaultAsync(c => c.HouseId == Houseid && c.UserDetaisId == UserDetailsId);
            if (CartsInDb != null)
            {
                _dbContext.BuyerCarts.Remove(CartsInDb);
                await _dbContext.SaveChangesAsync();

                return CartsInDb;
            }
            return null;
        }


        //Getting All houses for index page

        public async Task<IEnumerable<House>> GetAllApproved()
        {
            var pendings = await _dbContext.Houses.Where(h => h.Status == "APPROVED").ToListAsync();
            return pendings;
        }

        //To Show all the houseId in the cart
        public async Task<IEnumerable<BuyerCartModel>> GetAllMyCart(int id)
        {
            var houses = await _dbContext.BuyerCarts.Where(h => h.UserDetaisId == id).ToListAsync();
            if (houses.Count > 0)
                return houses;
            else
                return null;
        }

      
        //Getting Houses by Id so that the buyer can get any house details on clicking the house itself.
        public async Task<House> GetById(int id)
        {
            var house = await _dbContext.Houses.FirstOrDefaultAsync(h => h.Id == id);
            if (house != null)
            {
                return house;
            }
            return null;
        }


        //Filtering Based On City
        public async Task<IEnumerable<House>> GetHousesByCity(int cityId)
        {
            var houses = await _dbContext.Houses.Where(h => h.CityId == cityId && h.Status == "Approved").ToListAsync();
            return houses;
        }

        //Filtering Based on Type
        public async Task<IEnumerable<House>> GetHousesByType(string type)
        {
            var houses = await _dbContext.Houses.Where(h => h.PropertyType == type && h.Status == "Approved").ToListAsync();

            return houses;
        }

        //Filtering Based on Option
        public async Task<IEnumerable<House>> GetHousesByOption(string option)
        {
            var houses = await _dbContext.Houses.Where(h => h.PropertyOption == option && h.Status == "Approved").ToListAsync();
            return houses;
        }

        public async Task<BuyerCartModel> CheckCartExistence(BuyerCartModel model)
        {
            var res = await _dbContext.BuyerCarts.FirstOrDefaultAsync(c => c.HouseId == model.HouseId && c.UserDetaisId == model.UserDetaisId);
            if (res != null)
            {
                return null;
            }
            else
                return res;
        }


        public async Task<UserDetails> GetUserId(string userName)
        {
            var res = await _dbContext.Users.FirstOrDefaultAsync(c => c.UserName == userName);
            if (res != null)
            {
                return res;
            }
            return null;
        }

       /* public Task AddToCompare(int id)
        {
            var res = _dbContext.Houses.FirstOrDefault(c => c.Id == id);
            if(res != null)
            {

            }
        }*/
    }
}