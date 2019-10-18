using Google.Cloud.Firestore;
using iRental.BusinessLogicLayer.Interfaces.Repositories;
using iRental.Common.Constant;
using iRental.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iRental.Repository.Firestore.Repositories
{
    public class PhotoRepository : BaseRepository<PhotoEntity>, IPhotoRepository
    {
        public PhotoRepository(FirestoreDb dbContext) : base(dbContext, Constants.Collections.Photo)
        {
        }

        public async Task<IEnumerable<string>> GetUrlsByIds(IEnumerable<string> ids)
        {
            var urls = new List<string>();
            foreach (var id in ids)
            {
                var photoEntity = await FindByIdAsync(id);
                urls.Add(photoEntity.Url);
            }
            return urls;
        }
    }
}
