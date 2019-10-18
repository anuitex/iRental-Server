using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using iRental.BusinessLogicLayer.Interfaces.Clients;
using iRental.Domain.Entities;
using System;
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

        private async Task<PhotoEntity> UploadAsync(string bucket, MemoryStream fileStream, string contentType)
        {
            var photoEntity = new PhotoEntity
            {
                BucketName = Constants.FilestoreBucket.Avatar
            };

            await _storageClient.UploadObjectAsync(bucket, objectName: photoEntity.Id, contentType, fileStream);

            return photoEntity;
        }

        public async Task<PhotoEntity> UploadAdvertPhotoAsync(MemoryStream fileStream, string contentType)
        {
            if (fileStream == null)
            {
                throw new ArgumentNullException("fileStream");
            }

            if (string.IsNullOrWhiteSpace(contentType))
            {
                throw new ArgumentNullException("contentType");
            }

            return await UploadAsync(Constants.FilestoreBucket.AdvertPhoto, fileStream, contentType);
        }

        public async Task<PhotoEntity> UploadAvatarPhotoAsync(MemoryStream fileStream, string contentType)
        {
            if (fileStream == null)
            {
                throw new ArgumentNullException("fileStream");
            }

            if (string.IsNullOrWhiteSpace(contentType))
            {
                throw new ArgumentNullException("contentType");
            }

            return await UploadAsync(Constants.FilestoreBucket.Avatar, fileStream, contentType);
        }

        public async Task DeletePhotoAsync(PhotoEntity photoEntity)
        {
            await _storageClient.DeleteObjectAsync(photoEntity.BucketName, objectName: photoEntity.Id);
        }
    }
}
