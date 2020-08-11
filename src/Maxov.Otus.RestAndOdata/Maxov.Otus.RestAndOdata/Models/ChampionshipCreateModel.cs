using System.Collections.Generic;
using Maxov.Otus.RestAndOdata.DAL.Models.Entities;

namespace Maxov.Otus.RestAndOdata.Models
{
    public sealed class ChampionshipCreateModel
    {
        public string OfficialName { get; set; }

        public string Country { get; set; }

        public IReadOnlyList<TeamCreateShortModel> Teams { get; set; }
    }
}