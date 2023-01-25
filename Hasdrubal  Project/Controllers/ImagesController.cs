using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hasdrubal__Project.DBConnection;
using Hasdrubal__Project.Models;
using Hasdrubal__Project.Services;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Image = Hasdrubal__Project.Models.Image;

namespace Hasdrubal__Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IStorageService _blobService;
        private readonly IImagesService _imageService;
        public ImagesController(IStorageService blobService, AppDBContext context, IImagesService imageService)
        {
            _context = context;
            _blobService = blobService;
            _imageService = imageService;
        }

        #region Upload UserPics
        [HttpPost("api/UploadPictures")]
        public async Task<IActionResult> UploadPictures(IFormFile file, int oeuvreId)
        {
            if (file != null)
            {
                string resUrl = "";
                string name = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                using (var stream = file.OpenReadStream())
                {
                    resUrl = await _blobService.UploadBinary(name,stream);
                }
                Image image = new Image();
                image.name= name;
                image.OeuvreId=oeuvreId;
                _context.Images.Add(image);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetImage", new { id = image.Id }, image);
            }
            return BadRequest("File is null...");
        }
        #endregion

        #region GetImagesByOeuvre
        [HttpGet("api/GetImagesByOeuvre")]
        public async Task<ActionResult> GetImagesByOeuvre(int id)
        {
            List<string> imagesNames = await _imageService.GetImagesnameByOeuvreAsync(id);
            var res = new List<Uri>();
        
            foreach(var name in imagesNames) 
            {
               res.Add(await _blobService.DownloadBlobToLocalStorage(name));
            }
            return Ok(res);
        }
        #endregion

        #region other crud
        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(int id)
        {
            var image = await _context.Images.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }

        // PUT: api/Images/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImage(int id, Image image)
        {
            if (id != image.Id)
            {
                return BadRequest();
            }

            _context.Entry(image).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Image>> PostImage(Image image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImage", new { id = image.Id }, image);
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
        private bool ImageExists(int id)
        {
            return _context.Images.Any(e => e.Id == id);
        }
    }
}
