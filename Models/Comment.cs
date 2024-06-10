using System.ComponentModel.DataAnnotations;

namespace Test3.Models
{
    public class Comment
    {
        public int Id { get; set; }


        [Display(Name = "Rubrik")]
        public string Title { get; set; }


        [Display(Name = "Datum")]
        public DateTime? Date { get; set; }


        [Display(Name = "Kommentar")]
        public string Text { get; set; }


        [Display(Name = "Inlägget")]
        public virtual Post? Post { get; set; }
        public int PostId { get; set; }


        [Display(Name = "Användare")]
        public string? UserId { get; set; }

        public string? Image { get; set; }
    }
}
