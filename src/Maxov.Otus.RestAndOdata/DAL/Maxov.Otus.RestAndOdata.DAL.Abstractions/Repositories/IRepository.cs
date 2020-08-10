using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Maxov.Otus.RestAndOdata.DAL.Models.Entities;

namespace Maxov.Otus.RestAndOdata.DAL.Abstractions.Repositories
{
    public interface IRepository<TId, TEntity>
        where TEntity : EntityBase<TId>
        where TId : struct
    {
        public Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        public Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken = default);
    }
}