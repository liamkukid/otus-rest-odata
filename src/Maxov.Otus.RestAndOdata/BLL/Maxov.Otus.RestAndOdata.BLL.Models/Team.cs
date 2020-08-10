namespace Maxov.Otus.RestAndOdata.BLL.Models
{
    public sealed class Team
    {
        public long Id { get; set; }

        public string OfficialName { get; set; }

        public string Location { get; set; }

        public int СhampionshipId { get; set; }
    }
}