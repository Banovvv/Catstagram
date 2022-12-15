namespace Catstagram.Services.Data.Models
{
    public class PostInputModel
    {
        public string Caption { get; set; }
        public int UserId { get; set; }
        public string[] Tags { get; set; }
    }
}
