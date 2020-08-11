namespace Maxov.Otus.RestAndOdata.ViewModels
{
    /// <summary>
    ///     Подробная информация о футбольном команде
    /// </summary>
    public sealed class TeamViewModel
    {
        /// <summary>
        ///     Идентификатор футбольной команды
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///     Офифциальное название футбольной команды
        /// </summary>
        public string OfficialName { get; set; }

        /// <summary>
        ///     Место базирования футбольной команды
        /// </summary>
        public string Location { get; set; }
    }
}