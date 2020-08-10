using System;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using Maxov.Otus.RestAndOdata.BLL.Abstractions.Services;
using Maxov.Otus.RestAndOdata.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Maxov.Otus.RestAndOdata.Controllers
{
    [ApiController]
    [Route("api/football-manager/[controller]")]
    public class ChampionshipsController : ControllerBase
    {
        private readonly IChampionshipService _championatService;
        private readonly IMapper _mapper;

        public ChampionshipsController(IChampionshipService championshipService, IMapper mapper)
        {
            _championatService = championshipService ?? throw new ArgumentNullException(nameof(championshipService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(championshipService));
        }

        [HttpGet]
        public async Task<ChampionshipsContainerViewModel> GetAsync(CancellationToken cancellationToken = default)
        {
            var championships = await _championatService.GetAllAsync(cancellationToken);
            var container = _mapper.From(championships).AdaptToType<ChampionshipsContainerViewModel>();

            return container;
        }

        [HttpGet("{id}")]
        public async Task<ChampionshipViewModel> Get(int id, CancellationToken cancellationToken = default)
        {
            var championship = await _championatService.GetAsync(id, cancellationToken);
            var viewModel = _mapper.From(championship).AdaptToType<ChampionshipViewModel>();

            return viewModel;
        }
    }
}