using Catstagram.Data.Models;

namespace Catstagram.Web.API.Mapping.Models
{
    public class PostResponseModel
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<TagResponseModel> Tags { get; set; }
    }
}
