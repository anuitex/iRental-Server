using Google.Cloud.Firestore;
using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.Common.Constant;
using iRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRental.Repository.Firestore.Repositories
{
    public class PhotoRepository : BaseRepository<PhotoEntity>, IPhotoRepository
    {
        public PhotoRepository(FirestoreDb dbContext) : base(dbContext, Constants.Collections.Photo)
        {
        }
    }
}
