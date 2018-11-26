using GamesForFree.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesForFree.Models
{
    public class Company : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public int CompanyTypeId { get; set; }
        [ForeignKey("CompanyTypeId")]
        public virtual CompanyType CompanyType { get; set; }

        public ICollection<CompanyVideoGame> CompanyVideoGames { get; set; }

    }
}
