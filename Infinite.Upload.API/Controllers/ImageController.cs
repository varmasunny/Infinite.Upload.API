using Infinite.Upload.API.Models;
using Infinite.Upload.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infinite.Upload.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IRepository<UploadImage> _repository;
        private readonly IGetRepository<UploadImage> _getrepository ;
        public ImageController(IRepository<UploadImage> repository,IGetRepository<UploadImage> getrepository)
        {
            _getrepository=getrepository;
            _repository = repository;
        }
        [HttpGet("GetAllUploadImages")]
        public async Task<IEnumerable<UploadImage>> GetAllHouses()
        {
            return await _getrepository.GetAll();
        }
        [HttpGet]
        [Route("GetImageById/{id}")]
        public async Task<IActionResult> GetImageById(int id)
        {
            var image = await _getrepository.GetById(id);
            if (image != null)
            {
                return Ok(image);
            }
            return NotFound();
        }

        [HttpPost("CreateImage")]
        public async Task<IActionResult> Create([FromBody] UploadImage image)
        {
            if (ModelState.IsValid)
            {
                await _repository.Create(image);
                return CreatedAtAction("GetImageById", new { id = image.Id }, image);
            }
            return BadRequest();
        }
       

    }
}
