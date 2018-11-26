using GamesForFree.Models;
using System;

namespace GamesForFree.ViewModels
{
    public class VideoGameAdminModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool AvailableForPurchase { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }

        public decimal LifetimeGamePointsValue { get; set; }
        public decimal MinGamePointsTransaction { get; set; }
        public decimal MaxGamePointsTransaction { get; set; }
        public decimal Rolling12MonthsGamePointsValue { get; set; }

        public VideoGameAdminModel(VideoGame entity)
        {
            this.Title = entity.Title;
            this.Price = entity.Price;
            this.Description = entity.Description;
            this.ReleaseDate = entity.ReleaseDate;
            this.AvailableForPurchase = entity.AvailableForPurchase;
        }
    }
}
