namespace Maxov.Otus.RestAndOdata.DAL.Models.Entities
{
    public sealed class TeamEntity : EntityBase<long>
    {
        public string OfficialName { get; set; }

        public string Location { get; set; }

        public long СhampionshipId { get; set; }
    }
}