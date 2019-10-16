using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using iRental.BusinessLogicLayer.Interfaces.Clients;
using iRental.Common.Options;
using iRental.Domain.Entities;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;

namespace iRental.Client
{
    public class FileUploader : IFileUploader
    {
        private readonly StorageClient _storageClient;

        public FileUploader(GoogleCredential googleCredential)
        {
            _storageClient = StorageClient.Create(googleCredential);
        }

        private async Task<PhotoEntity> UploadAsync(string bucket, MemoryStream fileStream, string fileName, string contentType)
        {
            await _storageClient.UploadObjectAsync(bucket, fileName, contentType, fileStream);

            var photoEntity = new PhotoEntity
            {
                Name = fileName,
                BucketName = Constants.FilestoreBucket.Avatar
            };

            return photoEntity;
        }

        public async Task<PhotoEntity> UploadAdvertPhotoAsync(MemoryStream fileStream, string fileName, string contentType)
        {
            return await UploadAsync(Constants.FilestoreBucket.AdvertPhoto, fileStream, fileName, contentType);
        }

        public async Task<PhotoEntity> UploadAvatarPhotoAsync(MemoryStream fileStream, string fileName, string contentType)
        {
            return await UploadAsync(Constants.FilestoreBucket.Avatar, fileStream, fileName, contentType);
        }

        public async Task DeletePhotoAsync(PhotoEntity photoEntity)
        {
            await _storageClient.DeleteObjectAsync(photoEntity.BucketName, photoEntity.Name);
        }
    }
}
