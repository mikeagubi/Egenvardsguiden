using System.ComponentModel.DataAnnotations;

namespace Test3.Models
{
    public class Article
    {
        public int Id { get; set; }


        [Display(Name = "Rubrik")]
        public string Title { get; set; }


        [Display(Name = "Datum")]
        public DateTime? Date { get; set; }


        [Display(Name = "Inlägg")]
        public string Text { get; set; }


        [Display(Name = "Underkategori")]
        public virtual SubCategory? SubCategory { get; set; }
        public int SubCategoryId { get; set; }


        [Display(Name = "Användare")]
        public string? UserId { get; set; }

        public string Image { get; set; }
    }
}

