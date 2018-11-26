using GamesForFree.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GamesForFree.ViewModels
{
    public class VideoGameViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        //public bool AvailableForPurchase { get; set; }
        //public DateTimeOffset ReleaseDate { get; set; }
        public IEnumerable<CompanyViewModel> Developers { get; set; }
        public IEnumerable<CompanyViewModel> Publishers { get; set; }

        public VideoGameViewModel()
        {

        }
    }
}
