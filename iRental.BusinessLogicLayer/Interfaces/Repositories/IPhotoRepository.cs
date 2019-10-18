using iRental.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iRental.BusinessLogicLayer.Interfaces.Repositories
{
    public interface IPhotoRepository : IBaseRepository<PhotoEntity>
    {
        Task<IEnumerable<string>> GetUrlsByIds(IEnumerable<string> ids);
    }
}
