namespace Catstagram.Data.Models
{
    public class Like
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
