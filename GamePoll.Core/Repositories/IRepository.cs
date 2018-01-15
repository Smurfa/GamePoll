using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamePoll.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(int id);
        Task<int> AddAsync(T data);
        Task<bool> UpdateAsync(T data);
        Task<bool> DeleteAsync(int id);
    }
}
