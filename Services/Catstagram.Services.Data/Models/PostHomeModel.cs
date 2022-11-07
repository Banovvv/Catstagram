namespace Catstagram.Services.Data.Models
{
    public class PostHomeModel
    {
        public string Caption { get; set; }
        public string Author { get; set; }
        public byte[] Image { get; set; }
        public int Likes { get; set; }
        public CommentHomeModel? TopComment { get; set; }
    }
}
