namespace Test3.Models
{
    public class ReportedPost
    {
        public int Id { get; set; }
        public virtual Post? Post { get; set; }
        public int PostId { get; set; } 
        public DateTime? ReportedDate { get; set; }
    }
}
