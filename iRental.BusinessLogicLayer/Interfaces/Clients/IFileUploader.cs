using iRental.Domain.Entities;
using System.IO;
using System.Threading.Tasks;

namespace iRental.BusinessLogicLayer.Interfaces.Clients
{
    public interface IFileUploader
    {
        Task<PhotoEntity> UploadAvatarPhotoAsync(MemoryStream fileStream, string contentType);
        Task<PhotoEntity> UploadAdvertPhotoAsync(MemoryStream fileStream, string contentType);
        Task DeletePhotoAsync(PhotoEntity photoEntity);
    }
}
