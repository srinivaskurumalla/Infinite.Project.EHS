﻿using EHS_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHS_API.Repositories
{
    public class HouseRepository : IRepositories<House>, IGetRepository<House>,ICityRepository<House>,IStateRepository<State>,IStateCityRepository<City>
    {
        private readonly ApplicationDbContext _dbContext;
        public HouseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Add new house
        public async Task Create(House obj)
        {
            if(obj != null)
            {
                _dbContext.Houses.Add(obj);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<House> Delete(int id)
        {
            var houseInDb = await _dbContext.Houses.FindAsync(id);
            var houseInCarts = await _dbContext.BuyerCarts.Where(h => h.HouseId == id).ToListAsync();
            if (houseInCarts.Count > 0)
            {
                _dbContext.BuyerCarts.RemoveRange(houseInCarts);
                await _dbContext.SaveChangesAsync();
               

            }

            if (houseInDb != null)
            {
                _dbContext.Houses.Remove(houseInDb);
                await _dbContext.SaveChangesAsync();

                return houseInDb;
            }
            return null;
        }
      
        public async Task<House> Update(int id, House obj)
        {
            var houseInDb = await _dbContext.Houses.FindAsync(id);
            if (houseInDb != null)
            {
                houseInDb.PropertyType = obj.PropertyType;
                houseInDb.PropertyName = obj.PropertyName;
                houseInDb.Address = obj.Address;
                houseInDb.Region = obj.Region;
                houseInDb.PropertyOption = obj.PropertyOption;
                houseInDb.PriceRange = obj.PriceRange;
                houseInDb.InitialDeposit = obj.InitialDeposit;
                houseInDb.Landmark = obj.Landmark;
                houseInDb.CityId = obj.CityId;

                

               

                _dbContext.Houses.Update(houseInDb);
                await _dbContext.SaveChangesAsync();
                return houseInDb;
            }
            return null;
        }

        //get all houses
        public async Task<IEnumerable<House>> GetAll()
        {
            var houses = await _dbContext.Houses.ToListAsync();
            return houses;
        }
      

        //get house by Id
        public async Task<House> GetById(int id)
        {
            var house = await _dbContext.Houses.FirstOrDefaultAsync(h => h.Id == id) ;
            if(house != null)
            {
                return house;
            }
            return null;
        }

        public async Task<IEnumerable<House>> GetAllHouseByCityId(int id)
        {
            var houses = await _dbContext.Houses.Where(h => h.CityId== id).ToListAsync();
            if(houses.Count>0)
                return houses;
            return null;
        }

        public async Task<IEnumerable<House>> GetAllHousesBySellerName(string sellerName)
        {
            var houses = await _dbContext.Houses.Where(h => h.UserDetails.UserName == sellerName).ToListAsync();
            if (houses.Count > 0)
                return houses;
            else
                return null;
        }

       
        public async Task<IEnumerable<State>> GetStates()
        {
            var states = await _dbContext.States.ToListAsync();
            return states;
        }

       
        public async Task<IEnumerable<City>> GetCities(int stateId)
        {
            var cities = await _dbContext.Cities.Where(c => c.StateId == stateId).ToListAsync();
            return cities;
        }

       
    }
}
