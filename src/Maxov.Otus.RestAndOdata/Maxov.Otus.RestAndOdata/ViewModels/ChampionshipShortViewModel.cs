namespace Maxov.Otus.RestAndOdata.ViewModels
{
    public sealed class ChampionshipShortViewModel
    {
        public long Id { get; set; }

        public string OfficialName { get; set; }

        public string Country { get; set; }

        public int TeamsCount { get; set; }
    }
}