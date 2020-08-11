using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Maxov.Otus.RestAndOdata.DAL.Models.Entities;

namespace Maxov.Otus.RestAndOdata.Models
{
    public sealed class ChampionshipCreateModel
    {
        [Required]
        [StringLength(400)]
        public string OfficialName { get; set; }

        [Required]
        [StringLength(10)]
        public string Country { get; set; }
        
        public IReadOnlyList<TeamCreateShortModel> Teams { get; set; }
    }
}