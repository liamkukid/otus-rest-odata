using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using Maxov.Otus.RestAndOdata.BLL.Abstractions.Services;
using Maxov.Otus.RestAndOdata.BLL.Models;
using Maxov.Otus.RestAndOdata.DAL.Abstractions.Repositories;
using Maxov.Otus.RestAndOdata.DAL.Models.Entities;

namespace Maxov.Otus.RestAndOdata.BLL.Services
{
    public sealed class ChampionshipService : IChampionshipService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<long, ChampionshipEntity> _repository;

        public ChampionshipService(IRepository<long, ChampionshipEntity> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IReadOnlyList<Championship>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _repository.GetAllAsync(cancellationToken);
            var result = _mapper.From(entities).AdaptToType<IReadOnlyList<Championship>>();
            return result;
        }

        public async Task<Championship> GetAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetAsync(id, cancellationToken);
            var result = _mapper.From(entity).AdaptToType<Championship>();
            return result;
        }

        public async Task CreateAsync(Championship championship, CancellationToken cancellationToken = default)
        {
            if (championship == null) throw new ArgumentNullException(nameof(championship));
            var entity = _mapper.From(championship).AdaptToType<ChampionshipEntity>();

            await _repository.CreateAsync(entity, cancellationToken);
        }
    }
}