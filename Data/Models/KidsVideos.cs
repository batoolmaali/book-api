using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAPI.Data.Models
{
    [Table("KidsVideos")]
    public class KidsVideos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

     
        [Url]
        public string? ThumbnailUrl { get; set; }

        [Required]
        [Url]
        
        public string? VideoUrl { get; set; }
    }
}
