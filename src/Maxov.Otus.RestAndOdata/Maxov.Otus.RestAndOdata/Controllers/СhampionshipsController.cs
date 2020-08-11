using System;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using Maxov.Otus.RestAndOdata.BLL.Abstractions.Services;
using Maxov.Otus.RestAndOdata.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Maxov.Otus.RestAndOdata.Controllers
{
    [Produces("application/json")]
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

        /// <summary>
        /// Получить список футбольчных турниров
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/footbal-manager/championships/
        ///
        /// </remarks>
        /// <returns>Контейнер, содержащий список с базовой информацией о футбольных турнирах</returns>
        /// <response code="200">Запрос выполнился успешно, возвращены данные</response>
        /// <response code="204">Запрос выполнился успешно, но данные не найдены</response>            
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ChampionshipsContainerViewModel> GetAsync(CancellationToken cancellationToken = default)
        {
            var championships = await _championatService.GetAllAsync(cancellationToken);
            var container = _mapper.From(championships).AdaptToType<ChampionshipsContainerViewModel>();

            return container;
        }

        /// <summary>
        /// Получить подробную информацию о запрашиваемом футбольном турнире
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/footbal-manager/championships/:id
        ///
        /// </remarks>
        /// <param name="id">Идентификатор футбольного турнира</param>
        /// <returns>Подробная информация о запрашиваемом футбольном турнире</returns>
        /// <response code="200">Запрос выполнился успешно, возвращены данные</response>
        /// <response code="404">Данные не найдены</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ChampionshipViewModel> Get(int id, CancellationToken cancellationToken = default)
        {
            var championship = await _championatService.GetAsync(id, cancellationToken);
            var viewModel = _mapper.From(championship).AdaptToType<ChampionshipViewModel>();

            return viewModel;
        }
    }
}