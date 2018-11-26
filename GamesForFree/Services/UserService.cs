using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using GamesForFree.Data;
using GamesForFree.Models;
using GamesForFree.ViewModels;

namespace GamesForFree.Services
{
    public interface IUserService
    {
        UserViewModel Validate(UserValidationModel user);
        List<UserViewModel> Get();
        UserViewModel GetDetails(UserValidationModel user);
        UserViewModel Create(User user);
    }

    public class UserService : IUserService
    {
        private GamesForFreeDbContext _db;
        private UnitOfWork _unitOfWork;

        public UserService(GamesForFreeDbContext db)
        {
            _db = db;
            _unitOfWork = new UnitOfWork(_db);
        }

        public List<UserViewModel> Get()
        {
            var models = new List<UserViewModel>();
            var entities = _unitOfWork.userRepository.All.ToList();

            entities.ForEach(user =>
            {
                models.Add(new UserViewModel(user));
            });

            return models;
        }

        public UserViewModel GetDetails(UserValidationModel validationModel)
        {
            var user = _unitOfWork.userRepository.All.FirstOrDefault(
                entity => entity.UserName == validationModel.UserName && entity.Password == validationModel.Password);

            return new UserViewModel(user);
        }

        public UserViewModel Validate(UserValidationModel validationModel)
        {
            var user = _unitOfWork.userRepository.All.FirstOrDefault(
                entity => entity.UserName == validationModel.UserName && entity.Password == validationModel.Password);

            var viewModel = new UserViewModel(user);

            return new UserViewModel(user);
        }

        public UserViewModel Create(User user)
        {
            _unitOfWork.userRepository.Create(user);
            _unitOfWork.Commit();

            return new UserViewModel(user);
        }
    }
}