using System.ComponentModel.DataAnnotations;

namespace Test3.Models
{
    public class Message
    {
        public int Id { get; set; }
        

        [Display(Name ="Avsändare")]
        public string? UserId { get; set; }

        [Required]
        [Display(Name ="Mottagare")]
        public string ReceiverId { get; set; }

        [Display(Name ="Ämne")]
        public string Subject { get; set; }

        [Required]
        [Display(Name ="Meddelande")]
        public string Content { get; set; }

        [Display(Name ="Datum")]
        public DateTime? Date { get; set; }
    }
}
