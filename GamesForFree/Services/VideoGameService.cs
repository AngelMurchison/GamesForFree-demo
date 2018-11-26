using GamesForFree.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using GamesForFree.Data;

namespace GamesForFree.Services
{
    public interface IVideoGameService
    {
        List<VideoGame> GetForAdmin();
        List<VideoGame> Get();
        VideoGame GetDetails();
        VideoGame Create();
        VideoGame Update();
        VideoGame Delete();
    }

    public class VideoGameService : IVideoGameService
    {
        private GamesForFreeDbContext _db;
        private UnitOfWork _unitOfWork;

        public VideoGameService(GamesForFreeDbContext db)
        {
            _db = db;
            _unitOfWork = new UnitOfWork(_db);
        }

        public List<VideoGame> Get()
        {
            return _unitOfWork.videoGameRepository.All.ToList();
        }

        public List<VideoGame> GetForAdmin()
        {
            return Get();
        }

        public VideoGame GetDetails()
        {
            throw new NotImplementedException();
        }

        public VideoGame Create()
        {
            _unitOfWork.Commit();
            throw new NotImplementedException();
        }

        public VideoGame Delete()
        {

            _unitOfWork.Commit();
            throw new NotImplementedException();
        }

        public VideoGame Update()
        {
            _unitOfWork.Commit();
            throw new NotImplementedException();
        }
    }
}