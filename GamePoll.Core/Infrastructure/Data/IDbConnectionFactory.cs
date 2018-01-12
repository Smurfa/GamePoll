using System.Data;

namespace GamePoll.Core.Infrastructure.Data
{
    internal interface IDbConnectionFactory
    {
        IDbConnection Create();
    }
}
