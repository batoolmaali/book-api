using BookAPI.Data;
using BookAPI.Data.Models;
using BookAPI.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Azure.Core.HttpHeader;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KidsVideosController : ControllerBase
    {
        private readonly AppDbContext _DbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public KidsVideosController(AppDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this._DbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

     /*   List<KidsVideos> kidsVideosList = new List<KidsVideos>
        {
            new KidsVideos
            {
                Id=1,
                Title = "Cartoon Adventures",
                Description = "Exciting adventures in the cartoon world",
                ThumbnailUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a7/Big_Buck_Bunny_thumbnail_vlc.png/1200px-Big_Buck_Bunny_thumbnail_vlc.png",
                VideoUrl = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"
            },
            new KidsVideos
            {
                Id=2,
                Title = "Learning Numbers",
                Description = "Fun and interactive way to learn numbers",
                ThumbnailUrl = "https://i.ytimg.com/vi_webp/gWw23EYM9VM/maxresdefault.webp",
                VideoUrl = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4"
            },
             new KidsVideos
            {
                 Id=3,
                Title = "Learning Numbers",
                Description = "Fun and interactive way to learn numbers",
                ThumbnailUrl = "https://videocdn.cdnpk.net/harmony/content/video/partners1801/thumbnails/h25b49fb4_13657891-001-cartoon-jungle-background_small.jpg",
                VideoUrl = " https://videocdn.cdnpk.net/harmony/content/video/partners1801/large_preview/h25b49fb4_13657891-001-cartoon-jungle-background.mp4"
            },
             
                new KidsVideos
            {
                    Id=4,
                Title = "Learning Numbers",
                Description = "Fun and interactive way to learn numbers",
                ThumbnailUrl = "https://th.bing.com/th/id/OIP.SqllrqroAQX61VZkGtFxJgHaFN?pid=ImgDet&w=161&h=113&c=7",
                VideoUrl = "https://cdn.pixabay.com/video/2019/10/10/27730-365891000_large.mp4"
            },
                     new KidsVideos
            {
                         Id=5,
                Title = "Learning Numbers",
                Description = "Fun and interactive way to learn numbers",
                ThumbnailUrl = "https://th.bing.com/th/id/OIP.Qwu_y3M3Ms4dnoXZ99l6fAHaFj?pid=ImgDet&w=192&h=144&c=7&dpr=1.3",
                VideoUrl = "https://v.ftcdn.net/07/38/52/61/700_F_738526193_CNGSpmvIiyFO22bSsjcCCphSjbftWqky_ST.mp4"
            },
                          new KidsVideos
            {
                              Id=6,
                Title = "Learning Numbers",
                Description = "Fun and interactive way to learn numbers",
                ThumbnailUrl = "https://th.bing.com/th/id/OIP.SqllrqroAQX61VZkGtFxJgHaFN?pid=ImgDet&w=161&h=113&c=7",
                VideoUrl = "https://cdn.pixabay.com/video/2019/10/10/27730-365891000_large.mp4"
            },     new KidsVideos
            {
                Id=7,
                Title = "Learning Numbers",
                Description = "Fun and interactive way to learn numbers",
                ThumbnailUrl = "https://th.bing.com/th/id/OIP.SqllrqroAQX61VZkGtFxJgHaFN?pid=ImgDet&w=161&h=113&c=7",
                VideoUrl = "https://cdn.pixabay.com/video/2019/10/10/27730-365891000_large.mp4"
            }
            ,
                               new KidsVideos
            {
                                   Id=8,
                Title = "Learning Numbers",
                Description = "Fun and interactive way to learn numbers",
                ThumbnailUrl = "https://th.bing.com/th/id/OIP.SqllrqroAQX61VZkGtFxJgHaFN?pid=ImgDet&w=161&h=113&c=7",
                VideoUrl = "https://cdn.pixabay.com/video/2019/10/10/27730-365891000_large.mp4"
            },
                                    new KidsVideos
            {
                                        Id=9,
                Title = "Learning Numbers",
                Description = "Fun and interactive way to learn numbers",
                ThumbnailUrl = "https://th.bing.com/th/id/OIP.SqllrqroAQX61VZkGtFxJgHaFN?pid=ImgDet&w=161&h=113&c=7",
                VideoUrl = "https://cdn.pixabay.com/video/2019/10/10/27730-365891000_large.mp4"
            }
        };*/

        /*  [HttpGet]
          public IActionResult GetVideos()
          {
              return Ok(kidsVideosList);
          }*/
        [HttpGet]
        public async Task<IActionResult> GetVideos()
        {
            try
            {
                var videos = await _DbContext.KidsVideos.ToListAsync();

                if (videos != null)
                {
                    return Ok(videos);
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
        public async Task<IActionResult> AddVid([FromForm] KidsVideosVM videosVM)
        {
            try
            {
                /*
                            if (videosVM.ThumbnailUrl == null || videosVM.ThumbnailUrl.Length == 0)
                            {
                                return BadRequest("No file uploaded");
                            }

                            string uploadsDirectory1 = Path.Combine(Directory.GetCurrentDirectory(), "UploadsImage");
                          *//*  if (!Directory.Exists(uploadsDirectory1))
                            {
                                Directory.CreateDirectory(uploadsDirectory1);
                            }*/

               /* string uniqueFileName1 = Guid.NewGuid().ToString() + "_" + videosVM.ThumbnailUrl.FileName;
                string filePath1 = Path.Combine(uploadsDirectory1, uniqueFileName1);

                using (var stream1 = new FileStream(filePath1, FileMode.Create))
                {
                    await videosVM.ThumbnailUrl.CopyToAsync(stream1);
                }*/
                /////////////////////////////////////////////////////////////////////////////////////////


                if (videosVM.VideoUrl == null || videosVM.VideoUrl.Length == 0)
                {
                    return BadRequest("No file uploaded");
                }

                string uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(uploadsDirectory))
                {
                    Directory.CreateDirectory(uploadsDirectory);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + videosVM.VideoUrl.FileName;
                string filePath = Path.Combine(uploadsDirectory, uniqueFileName);

                using (var stream2 = new FileStream(filePath, FileMode.Create))
                {
                    await videosVM.VideoUrl.CopyToAsync(stream2);
                }

                using var stream = new MemoryStream();
            await videosVM.ThumbnailUrl.CopyToAsync(stream);

         

            var item = new KidsVideos
            {
                Title = videosVM.Title,
                Description = videosVM.Description,
                ThumbnailUrl = stream.ToArray(),
                VideoUrl = uniqueFileName
                /*  ThumbnailUrl= uniqueFileName1,
                  VideoUrl = uniqueFileName */
            };

            await _DbContext.KidsVideos.AddAsync(item);
            await _DbContext.SaveChangesAsync();

            return Ok(item);
        }
        catch (TaskCanceledException ex)
{
    // Handle the TaskCanceledException
    // Log the exception or perform other error handling
    return StatusCode(500, "A task was canceled: " + ex.Message);
    }
}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var vidoe = await _DbContext.KidsVideos.FindAsync(id);

                if (vidoe == null)
                {
                    return NotFound(); 
                }

                _DbContext.KidsVideos.Remove(vidoe);
                await _DbContext.SaveChangesAsync();

                return NoContent(); 
            }
            catch (Exception ex)
            {


                return StatusCode(500, "An error occurred while deleting the video."); 
            }
        }
    }
}

    
