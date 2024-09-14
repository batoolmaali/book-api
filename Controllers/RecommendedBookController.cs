using BookAPI.Data;
using BookAPI.Data.Models;
using BookAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendedBookController : ControllerBase
    {
        private readonly AppDbContext _DbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public RecommendedBookController(AppDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this._DbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var books = await _DbContext.RecommendedBooks.ToListAsync();

                if (books != null)
                {
                    return Ok(books);
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

        [HttpPost]
        public async Task<IActionResult> AddBook([FromForm] RecommendedBookVM model)
        {

            using var stream = new MemoryStream();
            await model.ImagePath.CopyToAsync(stream);
            /////////////////////////////////////////////////////////////////////////////////////////




            var item = new RecommendedBook
            {
             Title = model.Title,
             Description = model.Description,
             Author = model.Author,
             ImagePath = stream.ToArray(),
             AssociatedSeason = model.AssociatedSeason,
             AssociatedMood = model.AssociatedMood,
            };

            await _DbContext.RecommendedBooks.AddAsync(item);
            await _DbContext.SaveChangesAsync();

            return Ok(item);
        }

        [HttpGet("GetBooks/{name}")]
        public async Task<IActionResult> GetBooks(string name)
        {

            var books = await _DbContext.RecommendedBooks.ToListAsync();
            switch (name)
            {
                case "Spring":
                    books = books.Where(x => x.AssociatedSeason == Season.Spring).ToList();
                    break;
                case "Summer":
                    books = books.Where(x => x.AssociatedSeason == Season.Summer).ToList();
                    break;
                case "Autumn":
                    books = books.Where(x => x.AssociatedSeason == Season.Autumn).ToList();
                    break;
                case "Winter":
                    books = books.Where(x => x.AssociatedSeason == Season.Winter).ToList();
                    break;
                case "Happy":
                    books = books.Where(x => x.AssociatedMood == Mood.Happy).ToList();
                    break;
                case "Bad":
                    books = books.Where(x => x.AssociatedMood == Mood.Bad).ToList();
                    break;
                case "Adventure":
                    books = books.Where(x => x.AssociatedMood == Mood.Adventure).ToList();
                    break;
                case "Cozy":
                    books = books.Where(x => x.AssociatedMood == Mood.Cozy).ToList();
                    break;
                default:
                    Console.WriteLine("Not a valid season!");
                    break;
            }
      
            return Ok(books);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var book = await _DbContext.RecommendedBooks.FindAsync(id);

                if (book == null)
                {
                    return NotFound();
                }

                _DbContext.RecommendedBooks.Remove(book);
                await _DbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {


                return StatusCode(500, "An error occurred while deleting the book.");
            }
        }
    }
}
