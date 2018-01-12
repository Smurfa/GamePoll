using System.Collections.Generic;

namespace GamePoll.Core.Repositories
{
    internal interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(int id);
        void Add(T data);
        void Update(T data);
    }
}
