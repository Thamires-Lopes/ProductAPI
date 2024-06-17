using System.Data;

namespace Repositories.IManager
{
    public interface ITransactionManager
    {
        Task BeginTransactionAsync(IsolationLevel isolationLevel);
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
