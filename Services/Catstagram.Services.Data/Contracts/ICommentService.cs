using Catstagram.Data.Models;

namespace Catstagram.Services.Data.Contracts
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetALLByPostAsync(int id);
        Task<IEnumerable<Comment>> GetALLByUserAsync(int id);
        Task<IEnumerable<Comment>> GetALLByUserAsync(string username);
    }
}
