using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Maxov.Otus.RestAndOdata.DAL.Abstractions.Repositories;
using Maxov.Otus.RestAndOdata.DAL.Models.Entities;

namespace Maxov.Otus.RestAndOdata.DAL.Repositories
{
    public abstract class Repository<TId, TEntity> : IRepository<TId, TEntity>
        where TId : struct
        where TEntity : EntityBase<TId>
    {
        protected readonly FootballManagerDbContext DbContext;

        public Repository(FootballManagerDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public abstract Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        public abstract Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken = default);
    }
}