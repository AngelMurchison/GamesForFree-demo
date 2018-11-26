using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesForFree.Models
{
    public class CompanyVideoGame : BaseEntity
    {
        public int CompanyId { get; set; }
        public int VideoGameId { get; set; }

        public Company Company { get; set; }
        public VideoGame VideoGame { get; set; }
    }
}
