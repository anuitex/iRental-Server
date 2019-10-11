using Google.Cloud.Firestore;
using iRental.BusinessLogicLayer.Interfaces;
using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.Domain.Entities;
using iRental.Domain.Entities.User;
using iRental.Repository.Firestore.Constants;
using iRental.Repository.Firestore.Options;
using iRental.Repository.Repositories;
using Microsoft.Extensions.Options;
using System;

namespace iRental.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private FirestoreDb _dbContext;

        private IBaseRepository<AdvertEntity> _adverts;
        public IBaseRepository<AdvertEntity> Adverts => _adverts ?? (_adverts = new BaseRepository<AdvertEntity>(_dbContext, Constants.Collections.Advert));

        private IBaseRepository<PhotoEntity> _photos;
        public IBaseRepository<PhotoEntity> Photos => _photos ?? (_photos = new BaseRepository<PhotoEntity>(_dbContext, Constants.Collections.Photo));

        private IBaseRepository<UserEntity> _users;
        public IBaseRepository<UserEntity> Users => _users ?? (_users = new BaseRepository<UserEntity>(_dbContext, Constants.Collections.User));


        public UnitOfWork(IOptions<FirestoreOptions> options)
        {
            if (options.Value == null)
            {
                throw new ArgumentNullException("options", "Options can`t be null");
            }

            _dbContext = FirestoreDb.Create(options.Value.ProjectId);
        }
    }
}