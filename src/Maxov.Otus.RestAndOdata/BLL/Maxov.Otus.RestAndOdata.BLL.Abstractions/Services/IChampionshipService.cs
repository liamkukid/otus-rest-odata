using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Maxov.Otus.RestAndOdata.BLL.Models;

namespace Maxov.Otus.RestAndOdata.BLL.Abstractions.Services
{
    public interface IChampionshipService
    {
        public Task<IReadOnlyList<Championship>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<Championship> GetAsync(long id, CancellationToken cancellationToken = default);
    }
}