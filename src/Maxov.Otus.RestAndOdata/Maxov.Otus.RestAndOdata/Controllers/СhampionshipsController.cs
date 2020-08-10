using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Maxov.Otus.RestAndOdata.Controllers
{
    [ApiController]
    [Route("api/football-manager/[controller]")]
    public class ChampionshipsController : ControllerBase
    {
        private readonly List<Сhampionship> _championships = new List<Сhampionship>
        {
            new Сhampionship {Id = 1, Country = "England", OfficialName = "English Premier League"},
            new Сhampionship {Id = 2, Country = "England", OfficialName = "English Football League Championship"},
            new Сhampionship {Id = 3, Country = "Russia", OfficialName = "Russian Premier League"},
            new Сhampionship {Id = 4, Country = "Spain", OfficialName = "Campeonato Nacional de Liga de Primera División"}
        };

        [HttpGet]
        public IEnumerable<Сhampionship> Get()
        {
            return _championships;
        }
        
        [HttpGet("{id}")]
        public Сhampionship Get(int id)
        {
            return _championships.FirstOrDefault(x => x.Id == id);
        }
    }
}