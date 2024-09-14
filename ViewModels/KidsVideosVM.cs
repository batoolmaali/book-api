using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookAPI.ViewModels
{
    public class KidsVideosVM
    {
      
        public int Id { get; set; }

     
        public string Title { get; set; }

      
        public string Description { get; set; }


        public IFormFile ThumbnailUrl { get; set; }

  
        public IFormFile VideoUrl { get; set; }
    }
}
