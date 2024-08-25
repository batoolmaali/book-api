using BookAPI.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace BookAPI.ViewModels
{
    public class KidsCategoriesVM
    {
        public int Id { get; set; }

       
        public string Name { get; set; }


        public IFormFile Image { get; set; }

       /* public virtual ICollection<BookKid> bookKids { get; set; }*/
    }
}
