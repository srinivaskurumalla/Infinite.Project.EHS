using EHS_API.Models;
using EHS_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EHS_API.Repository
{

    public class HouseImageRepository : IGetRepository<HouseImage>, IRepositories<HouseImage>
    {
        private readonly ApplicationDbContext _dbContext;
        public HouseImageRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(HouseImage obj)
        {
            if (obj != null)
            {
                _dbContext.HouseImages.Add(obj);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task<HouseImage> Delete(int id)
        {
            var imageInDb = await _dbContext.HouseImages.FindAsync(id);
            if (imageInDb != null)
            {
                _dbContext.HouseImages.Remove(imageInDb);
                await _dbContext.SaveChangesAsync();

                return imageInDb;
            }
            return null;
        }

        public async Task<IEnumerable<HouseImage>> GetAll()
        {
            return await _dbContext.HouseImages.ToListAsync();
        }

        public async Task<HouseImage> GetById(int id)
        {
            var image = await _dbContext.HouseImages.FirstOrDefaultAsync(s => s.Id == id);
            if (image != null)
            {
                return image;
            }
            return null;
        }

        public async Task<HouseImage> Update(int id, HouseImage obj)
        {
            var imageInDb = await _dbContext.HouseImages.FindAsync(id);
            if (imageInDb != null)
            {
                imageInDb.ImageName = obj.ImageName;
                imageInDb.ImageUrl = obj.ImageUrl;
                imageInDb.HouseId = obj.HouseId;

                _dbContext.HouseImages.Update(imageInDb);
                await _dbContext.SaveChangesAsync();
                return imageInDb;
            }
            return null;
        }
    }
}