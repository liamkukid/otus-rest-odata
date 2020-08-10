using System.Collections.Generic;

namespace Maxov.Otus.RestAndOdata.DAL.Models.Entities
{
    public sealed class ChampionshipEntity : EntityBase<long>
    {
        public string OfficialName { get; set; }

        public string Country { get; set; }

        public IReadOnlyList<TeamEntity> Teams { get; set; }
    }
}