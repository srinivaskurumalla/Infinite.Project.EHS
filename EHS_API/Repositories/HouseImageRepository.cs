using EHS_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHS_API.Repositories
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
            if(obj!= null)
            {
                _dbContext.HouseImages.Add(obj);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<HouseImage>> GetAll()
        {
            var images = await _dbContext.HouseImages.ToListAsync();
            return images;
        }

        public async Task<HouseImage> GetById(int id)
        {
            var img =  await _dbContext.HouseImages.FirstOrDefaultAsync(img => img.Id == id);
            return img;
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

      

        public async Task<HouseImage> Update(int id, HouseImage obj)
        {
            var imageInDb = await _dbContext.HouseImages.FindAsync(id);
            if (imageInDb != null)
            {
                imageInDb.Image = obj.Image;
               
                imageInDb.HouseId = obj.HouseId;

                _dbContext.HouseImages.Update(imageInDb);
                await _dbContext.SaveChangesAsync();
                return imageInDb;
            }
            return null;
        }
    }
}
