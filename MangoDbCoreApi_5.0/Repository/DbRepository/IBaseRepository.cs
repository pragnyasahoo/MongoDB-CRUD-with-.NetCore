using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoDbCoreApi_5.Repository.DbRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllBookAsync();
        Task<TEntity> GetByIdAsync(string obj);
        Task<TEntity> CreateAsync(TEntity obj);
        Task UpdateAsync(string Id, TEntity book);
        Task DeleteAsync(string id);

    }
}
