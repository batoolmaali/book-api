using BookAPI.Data;
using BookAPI.Data.Models;
using BookAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using static Azure.Core.HttpHeader;
using static System.Net.Mime.MediaTypeNames;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KidsCategoryController : ControllerBase
    {
        private readonly AppDbContext _DbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public KidsCategoryController(AppDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this._DbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await _DbContext.KidsCategories.ToListAsync();

                if (categories != null)
                {
                    return Ok(categories);
                }
                else
                {
                    return NotFound(); 
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet("GetCategoryWithBooks/{id}")]
        public IActionResult GetCategoryWithBooks(int id)
        {
            var categoryBooks = _DbContext.BookKids
                .Where(x => x.KidsCategoryId == id)
                .ToList();

            if (!categoryBooks.Any())
            {
                return NotFound("No books found for the specified category.");
            }

            return Ok(categoryBooks);
        }



        [HttpPost]

        public async Task<IActionResult> AddCat([FromForm]KidsCategoriesVM kidsVM)
        {
            using var stream = new MemoryStream();
            await kidsVM.Image.CopyToAsync(stream);
            var item = new KidsCategory
            {
                Name = kidsVM.Name,
                Image= stream.ToArray()

            };
  
           await _DbContext.KidsCategories.AddAsync(item);
            await _DbContext.SaveChangesAsync();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var category = await _DbContext.KidsCategories.FindAsync(id);

                if (category == null)
                {
                    return NotFound(); // Return 404 Not Found if the category with the provided id is not found
                }

                _DbContext.KidsCategories.Remove(category);
                await _DbContext.SaveChangesAsync();

                return NoContent(); // Return 204 No Content upon successful deletion
            }
            catch (Exception ex)
            {
               

                return StatusCode(500, "An error occurred while deleting the category."); // Return 500 Internal Server Error
            }
        }


    }
}
