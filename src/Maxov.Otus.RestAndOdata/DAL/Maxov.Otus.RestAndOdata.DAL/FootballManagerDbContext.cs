using System.Collections.Generic;
using Maxov.Otus.RestAndOdata.DAL.Models.Entities;

namespace Maxov.Otus.RestAndOdata.DAL
{
    public class FootballManagerDbContext
    {
        public IList<ChampionshipEntity> Championships = new List<ChampionshipEntity>
        {
            new ChampionshipEntity {Id = 1, Country = "England", OfficialName = "English Premier League"},
            new ChampionshipEntity {Id = 2, Country = "England", OfficialName = "English Football League Championship"},
            new ChampionshipEntity {Id = 3, Country = "Russia", OfficialName = "Russian Premier League"},
            new ChampionshipEntity
                {Id = 4, Country = "Spain", OfficialName = "Campeonato Nacional de Liga de Primera División"}
        };

        public IList<TeamEntity> Teams = new List<TeamEntity>
        {
            new TeamEntity { Id = 61, OfficialName = "Alavés", Location = "Vitoria-Gasteiz", СhampionshipId = 4},
            new TeamEntity { Id = 62, OfficialName = "Athletic Bilbao", Location = "Bilbao", СhampionshipId = 4},
            new TeamEntity { Id = 63, OfficialName = "Atlético Madrid", Location = "Madrid", СhampionshipId = 4},
            new TeamEntity { Id = 64, OfficialName = "Barcelona", Location = "Barcelona", СhampionshipId = 4},
            new TeamEntity { Id = 65, OfficialName = "Celta Vigo", Location = "Vigo", СhampionshipId = 4},
            new TeamEntity { Id = 66, OfficialName = "Eibar", Location = "Eibar", СhampionshipId = 4},
            new TeamEntity { Id = 67, OfficialName = "Espanyol", Location = "Barcelona", СhampionshipId = 4},
            new TeamEntity { Id = 68, OfficialName = "Getafe", Location = "Getafe", СhampionshipId = 4},
            new TeamEntity { Id = 69, OfficialName = "Granada", Location = "Granada", СhampionshipId = 4},
            new TeamEntity { Id = 70, OfficialName = "Leganés", Location = "Leganés", СhampionshipId = 4},
            new TeamEntity { Id = 71, OfficialName = "Levante", Location = "Valencia	", СhampionshipId = 4},
            new TeamEntity { Id = 72, OfficialName = "Mallorca", Location = "Palma", СhampionshipId = 4},
            new TeamEntity { Id = 73, OfficialName = "Osasuna", Location = "Pamplona", СhampionshipId = 4},
            new TeamEntity { Id = 74, OfficialName = "Real Betis", Location = "Seville", СhampionshipId = 4},
            new TeamEntity { Id = 75, OfficialName = "Real Madrid", Location = "Madrid", СhampionshipId = 4},
            new TeamEntity { Id = 76, OfficialName = "Real Sociedad", Location = "San Sebastián", СhampionshipId = 4},
            new TeamEntity { Id = 77, OfficialName = "Sevilla", Location = "Seville", СhampionshipId = 4},
            new TeamEntity { Id = 78, OfficialName = "Valencia", Location = "Valencia", СhampionshipId = 4},
            new TeamEntity { Id = 79, OfficialName = "Valladolid", Location = "Valladolid", СhampionshipId = 4},
            new TeamEntity { Id = 80, OfficialName = "Villarreal", Location = "Villarreal", СhampionshipId = 4},
        };
    }
}