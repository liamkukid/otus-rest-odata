using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using Maxov.Otus.RestAndOdata.DAL.Models.Entities;

namespace Maxov.Otus.RestAndOdata.DAL.Repositories
{
    public class ChampionshipsRepository : Repository<long, ChampionshipEntity>
    {
        private readonly IMapper _mapper;

        private readonly IReadOnlyDictionary<long, List<TeamEntity>> _teamsByChampionship;

        public ChampionshipsRepository(FootballManagerDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _teamsByChampionship = DbContext.Teams
                .GroupBy(c => c.СhampionshipId)
                .ToDictionary(c => c.Key, c => c.ToList());
        }

        public override async Task<IReadOnlyList<ChampionshipEntity>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            var result = DbContext.Championships
                .Select(c => Build(c)).ToList();

            return await Task.FromResult(result);
        }

        public override async Task<ChampionshipEntity> GetAsync(long id, CancellationToken cancellationToken = default)
        {
            var source = DbContext.Championships
                .FirstOrDefault(x => x.Id == id);

            if (source == null) return null;

            var result = Build(source);

            return await Task.FromResult(result);
        }

        private ChampionshipEntity Build(ChampionshipEntity source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var entity = _mapper.From(source).AdaptToType<ChampionshipEntity>();
            if (_teamsByChampionship.TryGetValue(entity.Id, out var teams)) entity.Teams = teams;

            return entity;
        }
    }
}