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
        Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken = default);
        Task CreateAsync(ChampionshipEntity entity, CancellationToken cancellationToken = default);
    }
}