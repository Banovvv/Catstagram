namespace Catstagram.Data.Models
{
    public class Post
    {
        public Post()
        {
            Tags = new HashSet<Tag>();
            Likes = new HashSet<Like>();
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Caption { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
