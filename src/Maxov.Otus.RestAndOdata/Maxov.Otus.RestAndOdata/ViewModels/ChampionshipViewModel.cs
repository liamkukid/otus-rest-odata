using System.Collections.Generic;

namespace Maxov.Otus.RestAndOdata.ViewModels
{
    /// <summary>
    ///     Подробная информация о футбольном турнире
    /// </summary>
    public sealed class ChampionshipViewModel
    {
        /// <summary>
        ///     Идентификатор футбольного турнира
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///     Офифциальное название футбольного турнира
        /// </summary>
        public string OfficialName { get; set; }

        /// <summary>
        ///     Страна проведения футбольного турнира
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///     Список команд, принимающих участие в футбольном турнире
        /// </summary>
        public IReadOnlyList<TeamViewModel> Teams { get; set; } = new List<TeamViewModel>();
    }
}