using GamesForFree.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using GamesForFree.Data;
using GamesForFree.ViewModels;

namespace GamesForFree.Services
{
    public interface ISeedService
    {
        List<VideoGame> SeedFrom(IList<VideoGameViewModel> videoGames);
		void SeedTransactions();
    }

    public class SeedService : ISeedService
    {
        private GamesForFreeDbContext _db;
        private UnitOfWork _unitOfWork;

        public SeedService(GamesForFreeDbContext db)
        {
            _db = db;
            _unitOfWork = new UnitOfWork(_db);
        }

        public List<VideoGame> SeedFrom(IList<VideoGameViewModel> videoGames)
		{
			if (videoGames != null)
			{
				foreach (var game in videoGames)
				{
					var entity = new VideoGame()
					{
						Title = game.Title,
						AvailableForPurchase = true,
						Description = game.Description,
						Price = new Random().Next(4000, 6000) / 100.00m
					};

					var existingGame = _unitOfWork.videoGameRepository.All.FirstOrDefault(g => g.Title == entity.Title);

					if (existingGame == null)
					{
						_unitOfWork.videoGameRepository.Create(entity);
					}

					foreach (var developer in game.Developers)
					{
						var developerEntity = new Company()
						{
							Name = developer.Name,
							CompanyTypeId = developer.CompanyTypeId,
						};

						var existingDev = _unitOfWork.companyRepository.All.FirstOrDefault(company => company.Name == developer.Name);

						if (existingDev == null)
						{
							_unitOfWork.companyRepository.Create(developerEntity);
						}

						var relationship = new CompanyVideoGame()
						{
							Company = developerEntity,
							VideoGame = entity
						};

						_unitOfWork.companyVideoGameRepository.Create(relationship);
					}

					foreach (var publisher in game.Publishers)
					{
						var publisherEntity = new Company()
						{
							Name = publisher.Name,
							CompanyTypeId = publisher.CompanyTypeId,
						};

						var existingPublisher = _unitOfWork.companyRepository.All.FirstOrDefault(company => company.Name == publisher.Name);

						if (existingPublisher == null)
						{
							_unitOfWork.companyRepository.Create(publisherEntity);
						}

						var relationship = new CompanyVideoGame()
						{
							Company = publisherEntity,
							VideoGame = entity
						};

						_unitOfWork.companyVideoGameRepository.Create(relationship);
					}

					_unitOfWork.Commit();

				};

			}

			var games = _unitOfWork.videoGameRepository.All.ToList();

			return games;


		}

		public void SeedTransactions()
		{
			var games = _unitOfWork.videoGameRepository.All.ToList();
			var user = _unitOfWork.userRepository.All.FirstOrDefault();

			foreach (var game in games)
			{
				var newTransaction = new Transaction()
				{
					CustomerId = user.Id,
					GamePointsExchanged = new Random().Next(4000, 6000) / 1000.00m,
					VideoGameId = game.Id
				};

				_unitOfWork.transactionRepository.Create(newTransaction);
				_unitOfWork.Commit();
			}
		}

    }
}