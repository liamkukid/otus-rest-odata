using System;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using Maxov.Otus.RestAndOdata.BLL.Abstractions.Services;
using Maxov.Otus.RestAndOdata.BLL.Models;
using Maxov.Otus.RestAndOdata.ErrorHandling;
using Maxov.Otus.RestAndOdata.Models;
using Maxov.Otus.RestAndOdata.ViewModels;
using Maxov.Otus.RestAndOdata.ViewModels.BeforeV3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Maxov.Otus.RestAndOdata.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("2.0")]
    [Route("api/football-manager/v{v:apiVersion}/championships")]
    public class ChampionshipsV1And2Controller : ControllerBase
    {
        private readonly IChampionshipService _championatService;
        private readonly IMapper _mapper;

        public ChampionshipsV1And2Controller(IChampionshipService championshipService, IMapper mapper)
        {
            _championatService = championshipService ?? throw new ArgumentNullException(nameof(championshipService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(championshipService));
        }

        /// <summary>
        ///     Получить список футбольчных турниров
        /// </summary>
        /// <remarks>
        ///     Sample request:
        ///     GET /api/footbal-manager/v1.0/championships/
        ///     or
        ///     GET /api/footbal-manager/v2.0/championships/
        /// </remarks>
        /// <returns>Контейнер, содержащий список с базовой информацией о футбольных турнирах</returns>
        /// <response code="200">Запрос выполнился успешно, возвращены данные</response>
        /// <response code="204">Запрос выполнился успешно, но данные не найдены</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ChampionshipsContainerBeforeV3ViewModel> GetAsync(CancellationToken cancellationToken = default)
        {
            var championships = await _championatService.GetAllAsync(cancellationToken);
            var container = _mapper.From(championships).AdaptToType<ChampionshipsContainerBeforeV3ViewModel>();

            return container;
        }

        /// <summary>
        ///     Получить подробную информацию о запрашиваемом футбольном турнире
        /// </summary>
        /// <remarks>
        ///     Sample request:
        ///     GET /api/footbal-manager/v1.0/championships/:id
        ///     or
        ///     GET /api/footbal-manager/v2.0/championships/:id
        /// </remarks>
        /// <param name="id">Идентификатор футбольного турнира</param>
        /// <returns>Подробная информация о запрашиваемом футбольном турнире</returns>
        /// <response code="200">Запрос выполнился успешно, возвращены данные</response>
        /// <response code="404">Данные не найдены</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ChampionshipViewModel> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var championship = await _championatService.GetAsync(id, cancellationToken);

            if (championship == null)
                throw new HttpResponseException
                {
                    Status = StatusCodes.Status404NotFound,
                    Value = $"Запрашиваемый футбольный турнир с id {id} не найден"
                };

            var viewModel = _mapper.From(championship).AdaptToType<ChampionshipViewModel>();

            return viewModel;
        }

        /// <summary>
        ///     Создает новые записи о футбольном турнире и о командах, участвующих в нем
        /// </summary>
        /// <remarks>
        ///     Sample request:
        ///     POST /api/footbal-manager/v1.0/championships/
        ///     or
        ///     POST /api/footbal-manager/v2.0/championships/
        ///     {
        ///        "OfficialName":"Le championnat de France de football",
        ///        "Country":"France",
        ///        "Teams":[
        ///           {
        ///              "OfficialName":"Amiens",
        ///              "Location":"Amiens"
        ///           },
        ///           {
        ///              "OfficialName":"Angers",
        ///              "Location":"Angers"
        ///           }
        ///        ]
        ///     }
        /// </remarks>
        /// <response code="200">Запрос выполнился успешно, создана запись</response>
        /// <response code="400">Некорректные данные</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpPost]
        public async Task CreateAsync(ChampionshipCreateModel model, CancellationToken cancellationToken = default)
        {
            var championship = _mapper.From(model).AdaptToType<Championship>();

            await _championatService.CreateAsync(championship, cancellationToken);
        }
    }
}