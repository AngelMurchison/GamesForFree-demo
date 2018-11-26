using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesForFree.Models
{
    public class VideoGame : BaseEntity
    {
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool AvailableForPurchase { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }

        public ICollection<CompanyVideoGame> VideoGameCompanies { get; set; }
    }
}
