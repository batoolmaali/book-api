using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookAPI.Data.Models
{
    public class RecommendedBook
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

        [Required]
        [StringLength(20)]
        public string Author { get; set; }

        public byte[]? ImagePath { get; set; }
      

        public Season? AssociatedSeason { get; set; }
        public Mood? AssociatedMood { get; set; }




    }

    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    public enum Mood
    {
        Happy,
        Cozy,
        Adventure,
        Bad
    }

}
