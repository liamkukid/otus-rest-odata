using System.Collections.Generic;

namespace Maxov.Otus.RestAndOdata.BLL.Models
{
    public sealed class Championship
    {
        public long Id { get; set; }

        public string OfficialName { get; set; }

        public string Country { get; set; }

        public IReadOnlyList<Team> Teams { get; set; }
    }
}