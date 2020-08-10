using System.Collections.Generic;

namespace Maxov.Otus.RestAndOdata.ViewModels
{
    public sealed class ChampionshipViewModel
    {
        public long Id { get; set; }

        public string OfficialName { get; set; }

        public string Country { get; set; }

        public IReadOnlyList<TeamViewModel> Teams { get; set; } = new List<TeamViewModel>();
    }
}