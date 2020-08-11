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
            new TeamEntity {Id = 1, OfficialName = "Arsenal", Location = "London (Holloway)", СhampionshipId = 1},
            new TeamEntity {Id = 2, OfficialName = "Aston Villa", Location = "Birmingham", СhampionshipId = 1},
            new TeamEntity {Id = 3, OfficialName = "Bournemouth", Location = "Bournemouth", СhampionshipId = 1},
            new TeamEntity {Id = 4, OfficialName = "Brighton & Hove Albion", Location = "Brighton", СhampionshipId = 1},
            new TeamEntity {Id = 5, OfficialName = "Burnley", Location = "Burnley", СhampionshipId = 1},
            new TeamEntity {Id = 6, OfficialName = "Chelsea", Location = "London (Fulham)", СhampionshipId = 1},
            new TeamEntity
                {Id = 7, OfficialName = "Crystal Palace", Location = "London (Selhurst)", СhampionshipId = 1},
            new TeamEntity {Id = 8, OfficialName = "Everton", Location = "Liverpool (Walton)", СhampionshipId = 1},
            new TeamEntity {Id = 9, OfficialName = "Leicester City", Location = "Leicester", СhampionshipId = 1},
            new TeamEntity {Id = 10, OfficialName = "Liverpool", Location = "Liverpool (Anfield)", СhampionshipId = 1},
            new TeamEntity {Id = 11, OfficialName = "Manchester City", Location = "Manchester", СhampionshipId = 1},
            new TeamEntity {Id = 12, OfficialName = "Manchester United", Location = "Old Trafford", СhampionshipId = 1},
            new TeamEntity
                {Id = 13, OfficialName = "Newcastle United", Location = "Newcastle upon Tyne", СhampionshipId = 1},
            new TeamEntity {Id = 14, OfficialName = "Norwich City", Location = "Norwich", СhampionshipId = 1},
            new TeamEntity {Id = 15, OfficialName = "Sheffield United", Location = "Sheffield", СhampionshipId = 1},
            new TeamEntity {Id = 16, OfficialName = "Southampton", Location = "Southampton", СhampionshipId = 1},
            new TeamEntity
                {Id = 17, OfficialName = "Tottenham Hotspur", Location = "London (Tottenham)", СhampionshipId = 1},
            new TeamEntity {Id = 18, OfficialName = "Watford", Location = "Watford", СhampionshipId = 1},
            new TeamEntity
                {Id = 19, OfficialName = "West Ham United", Location = "London (Stratford)", СhampionshipId = 1},
            new TeamEntity
                {Id = 20, OfficialName = "Wolverhampton Wanderers", Location = "Wolverhampto", СhampionshipId = 1},
            new TeamEntity {Id = 21, OfficialName = "Barnsley", Location = "Barnsley", СhampionshipId = 2},
            new TeamEntity {Id = 22, OfficialName = "Birmingham City", Location = "Birmingham", СhampionshipId = 2},
            new TeamEntity {Id = 23, OfficialName = "Blackburn Rovers", Location = "Blackburn", СhampionshipId = 2},
            new TeamEntity {Id = 24, OfficialName = "Brentford", Location = "London (Brentford)", СhampionshipId = 2},
            new TeamEntity {Id = 25, OfficialName = "Bristol City", Location = "Bristol", СhampionshipId = 2},
            new TeamEntity {Id = 26, OfficialName = "Cardiff City", Location = "Cardiff", СhampionshipId = 2},
            new TeamEntity
                {Id = 27, OfficialName = "Charlton Athletic", Location = "London (Charlton)", СhampionshipId = 2},
            new TeamEntity {Id = 28, OfficialName = "Derby County", Location = "Derby", СhampionshipId = 2},
            new TeamEntity {Id = 29, OfficialName = "Fulham", Location = "London (Fulham)", СhampionshipId = 2},
            new TeamEntity {Id = 30, OfficialName = "Huddersfield Town", Location = "Huddersfield", СhampionshipId = 2},
            new TeamEntity {Id = 31, OfficialName = "Hull City", Location = "Kingston upon Hull", СhampionshipId = 2},
            new TeamEntity {Id = 32, OfficialName = "Leeds United", Location = "Leeds", СhampionshipId = 2},
            new TeamEntity {Id = 33, OfficialName = "Luton Town", Location = "Luton", СhampionshipId = 2},
            new TeamEntity {Id = 34, OfficialName = "Middlesbrough", Location = "Middlesbrough", СhampionshipId = 2},
            new TeamEntity
                {Id = 35, OfficialName = "Millwall", Location = "London (South Bermondsey)", СhampionshipId = 2},
            new TeamEntity
                {Id = 36, OfficialName = "Nottingham Forest", Location = "West Bridgford", СhampionshipId = 2},
            new TeamEntity {Id = 37, OfficialName = "Preston North End", Location = "Preston", СhampionshipId = 2},
            new TeamEntity
                {Id = 38, OfficialName = "Queens Park Rangers", Location = "London (White City)", СhampionshipId = 2},
            new TeamEntity {Id = 39, OfficialName = "Reading", Location = "Reading", СhampionshipId = 2},
            new TeamEntity {Id = 40, OfficialName = "Sheffield Wednesday", Location = "Sheffield", СhampionshipId = 2},
            new TeamEntity {Id = 41, OfficialName = "Stoke City", Location = "Stoke-on-Trent", СhampionshipId = 2},
            new TeamEntity {Id = 42, OfficialName = "Swansea City", Location = "Swansea", СhampionshipId = 2},
            new TeamEntity
                {Id = 43, OfficialName = "West Bromwich Albion", Location = "West Bromwich", СhampionshipId = 2},
            new TeamEntity {Id = 44, OfficialName = "Wigan Athletic", Location = "Wigan", СhampionshipId = 2},
            new TeamEntity {Id = 45, OfficialName = "Akhmat", Location = "Grozny", СhampionshipId = 3},
            new TeamEntity {Id = 46, OfficialName = "Arsenal", Location = "Tula", СhampionshipId = 3},
            new TeamEntity {Id = 47, OfficialName = "CSKA", Location = "Moscow", СhampionshipId = 3},
            new TeamEntity {Id = 48, OfficialName = "Dynamo", Location = "Moscow", СhampionshipId = 3},
            new TeamEntity {Id = 49, OfficialName = "Krasnodar", Location = "Krasnodar", СhampionshipId = 3},
            new TeamEntity {Id = 50, OfficialName = "Krylia Sovetov", Location = "Samara", СhampionshipId = 3},
            new TeamEntity {Id = 51, OfficialName = "Lokomotiv", Location = "Moscow", СhampionshipId = 3},
            new TeamEntity {Id = 52, OfficialName = "Orenburg", Location = "Orenburg", СhampionshipId = 3},
            new TeamEntity {Id = 53, OfficialName = "Rostov", Location = "Rostov-on-Don", СhampionshipId = 3},
            new TeamEntity {Id = 54, OfficialName = "Rubin", Location = "Kazan", СhampionshipId = 3},
            new TeamEntity {Id = 55, OfficialName = "Sochi", Location = "Sochi", СhampionshipId = 3},
            new TeamEntity {Id = 56, OfficialName = "Spartak", Location = "Moscow", СhampionshipId = 3},
            new TeamEntity {Id = 57, OfficialName = "Tambov", Location = "Tambov", СhampionshipId = 3},
            new TeamEntity {Id = 58, OfficialName = "Ufa", Location = "Ufa", СhampionshipId = 3},
            new TeamEntity {Id = 59, OfficialName = "Ural", Location = "Yekaterinburg", СhampionshipId = 3},
            new TeamEntity {Id = 60, OfficialName = "Zenit", Location = "Saint Petersburg", СhampionshipId = 3},
            new TeamEntity {Id = 61, OfficialName = "Alavés", Location = "Vitoria-Gasteiz", СhampionshipId = 4},
            new TeamEntity {Id = 62, OfficialName = "Athletic Bilbao", Location = "Bilbao", СhampionshipId = 4},
            new TeamEntity {Id = 63, OfficialName = "Atlético Madrid", Location = "Madrid", СhampionshipId = 4},
            new TeamEntity {Id = 64, OfficialName = "Barcelona", Location = "Barcelona", СhampionshipId = 4},
            new TeamEntity {Id = 65, OfficialName = "Celta Vigo", Location = "Vigo", СhampionshipId = 4},
            new TeamEntity {Id = 66, OfficialName = "Eibar", Location = "Eibar", СhampionshipId = 4},
            new TeamEntity {Id = 67, OfficialName = "Espanyol", Location = "Barcelona", СhampionshipId = 4},
            new TeamEntity {Id = 68, OfficialName = "Getafe", Location = "Getafe", СhampionshipId = 4},
            new TeamEntity {Id = 69, OfficialName = "Granada", Location = "Granada", СhampionshipId = 4},
            new TeamEntity {Id = 70, OfficialName = "Leganés", Location = "Leganés", СhampionshipId = 4},
            new TeamEntity {Id = 71, OfficialName = "Levante", Location = "Valencia	", СhampionshipId = 4},
            new TeamEntity {Id = 72, OfficialName = "Mallorca", Location = "Palma", СhampionshipId = 4},
            new TeamEntity {Id = 73, OfficialName = "Osasuna", Location = "Pamplona", СhampionshipId = 4},
            new TeamEntity {Id = 74, OfficialName = "Real Betis", Location = "Seville", СhampionshipId = 4},
            new TeamEntity {Id = 75, OfficialName = "Real Madrid", Location = "Madrid", СhampionshipId = 4},
            new TeamEntity {Id = 76, OfficialName = "Real Sociedad", Location = "San Sebastián", СhampionshipId = 4},
            new TeamEntity {Id = 77, OfficialName = "Sevilla", Location = "Seville", СhampionshipId = 4},
            new TeamEntity {Id = 78, OfficialName = "Valencia", Location = "Valencia", СhampionshipId = 4},
            new TeamEntity {Id = 79, OfficialName = "Valladolid", Location = "Valladolid", СhampionshipId = 4},
            new TeamEntity {Id = 80, OfficialName = "Villarreal", Location = "Villarreal", СhampionshipId = 4}
        };
    }
}