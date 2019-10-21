using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using iRental.BusinessLogicLayer.Interfaces.Clients;
using iRental.Common.Options;
using iRental.Domain.Entities;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;

namespace iRental.Client
{
    public class FileUploader : IFileUploader
    {
        private readonly StorageClient _storageClient;
        private readonly string _projectId;

        public FileUploader(GoogleCredential googleCredential, IOptions<FirestoreOptions> options)
        {
            _storageClient = StorageClient.Create(googleCredential);
            _projectId = options.Value.ProjectId;
        }

        private async Task<PhotoEntity> UploadAsync(string folder, MemoryStream fileStream, string contentType)
        {
            var photoEntity = new PhotoEntity();
            photoEntity.BucketPath = $"{folder}/{photoEntity.Id}";

            await _storageClient.UploadObjectAsync(_projectId, objectName: photoEntity.BucketPath, contentType, fileStream);

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
            if (photoEntity == null)
            {
                throw new ArgumentNullException("photoEntity");
            }

            await _storageClient.DeleteObjectAsync(_projectId, objectName: photoEntity.BucketPath);
        }

        public async Task DeletePhotoAsync(string bucketPath)
        {
            if (string.IsNullOrWhiteSpace(bucketPath))
            {
                throw new ArgumentNullException("bucketPath");
            }
            await _storageClient.DeleteObjectAsync(_projectId, objectName: bucketPath);
        }
    }
}
