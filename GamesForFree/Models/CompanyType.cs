using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesForFree.Models
{
    public class CompanyType : BaseEntity
    {
        public const int DeveloperTypeId = 1;
        public const int PublisherTypeId = 2;

        public string Code { get; set; }
        public string Name { get; set; }
    }
}
