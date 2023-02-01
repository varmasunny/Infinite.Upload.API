using Infinite.Upload.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infinite.Upload.API.Repositories
{
    public class ImageRepository:IRepository<UploadImage>,IGetRepository<UploadImage>
    {
        private readonly ApplicationDbContext _dbContext;
        public ImageRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(UploadImage obj)
        {
            if (obj != null)
            {
                _dbContext.Uploads.Add(obj);
                await _dbContext.SaveChangesAsync();
            }
        }

       
        public async Task<IEnumerable<UploadImage>> GetAll()
        {
            return await _dbContext.Uploads.ToListAsync();
        }
    

        public async Task<UploadImage> GetById(int id)
        {
            var image = await _dbContext.Uploads.FirstOrDefaultAsync(s => s.Id == id);
            if (image != null)
            {
                return image;
            }
            return null;
        }
    }
}
