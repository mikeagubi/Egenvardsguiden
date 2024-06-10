using System.ComponentModel.DataAnnotations;

namespace Test3.Models
{
    public class SubCategory
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Underkategori Namn")]
        public string Name { get; set; }


        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
