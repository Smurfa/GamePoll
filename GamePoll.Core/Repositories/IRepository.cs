using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamePoll.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task Add(T data);
        Task Update(T data);
    }
}
