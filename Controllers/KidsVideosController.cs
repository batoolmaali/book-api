﻿using BookAPI.Data;
using BookAPI.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Azure.Core.HttpHeader;
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

        List<KidsVideos> kidsVideosList = new List<KidsVideos>
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
        };

        [HttpGet]
        public IActionResult GetVideos()
        {
            return Ok(kidsVideosList);
        }


    }
}

    
