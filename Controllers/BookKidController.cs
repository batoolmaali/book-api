using BookAPI.Data;
using BookAPI.Data.Models;
using BookAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookKidController : Controller
    {
        private readonly AppDbContext _DbContext;
       
        public BookKidController(AppDbContext dbContext )
        {
            this._DbContext = dbContext;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cat = await _DbContext.BookKids.ToListAsync();
            return Ok(cat);
        }
        [HttpPost]

        public async Task<IActionResult> AddBook([FromForm] BookKidVM model)
        {
            using var stream = new MemoryStream();
            await model.Image.CopyToAsync(stream);

            using var stream1 = new MemoryStream();
            await model.PDF.CopyToAsync(stream1);

            var item = new BookKid
            {
                Title=model.Title,
                Description=model.Description,
                KidsCategoryId=model.KidsCategoryId,
                Image = stream.ToArray(),
                PDF= stream1.ToArray(),
                

            };

            await _DbContext.BookKids.AddAsync(item);
            await _DbContext.SaveChangesAsync();
            return Ok(item);
        }
        [HttpGet("/GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
          
            var book = await _DbContext.BookKids.FirstOrDefaultAsync(x => x.Id == id);

            if (book == null)
            {

                return NotFound();
            }


            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var book = await _DbContext.BookKids.FindAsync(id);

                if (book == null)
                {
                    return NotFound(); 
                }

                _DbContext.BookKids.Remove(book);
                await _DbContext.SaveChangesAsync();

                return NoContent(); 
            }
            catch (Exception ex)
            {


                return StatusCode(500, "An error occurred while deleting the category."); 
                // Return 500 Internal Server Error
            }
        }
    }
}
