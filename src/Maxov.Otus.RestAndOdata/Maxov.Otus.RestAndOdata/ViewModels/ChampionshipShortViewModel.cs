namespace Maxov.Otus.RestAndOdata.ViewModels
{
    /// <summary>
    ///     Базовая информация о футбольном турнире
    /// </summary>
    public sealed class ChampionshipShortViewModel
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
        ///     Количество команда, принимающих участие в футбольном турнире
        /// </summary>
        public int TeamsCount { get; set; }
    }
}