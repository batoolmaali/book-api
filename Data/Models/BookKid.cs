using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookAPI.Data.Models
{
    public class BookKid
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
        public byte[] Image { get; set; }

        public byte[] PDF { get; set; }

        [ForeignKey("KidsCategoryId")]
        public int KidsCategoryId { get; set; }

        public virtual KidsCategory KidsCategory { get; set; }


    }
}
