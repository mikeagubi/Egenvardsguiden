using System.ComponentModel.DataAnnotations;

namespace Test3.Models
{
    
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Kategorinamn")]
        public String Name { get; set; }
    }
}
