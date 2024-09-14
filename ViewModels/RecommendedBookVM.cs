using BookAPI.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookAPI.ViewModels
{
    public class RecommendedBookVM
    {
       
        public int Id { get; set; }

    
        public string Title { get; set; }
      
        public string Description { get; set; }

        public string Author { get; set; }

        public IFormFile ImagePath { get; set; }

        public Season? AssociatedSeason { get; set; }
        public Mood? AssociatedMood { get; set; }
    }
}
