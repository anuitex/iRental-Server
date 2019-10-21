using Google.Apis.Auth.OAuth2;
using iRental.Common.Options;
using iRental.Domain.Entities;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace iRental.Client.Test
{
    public class FileUploaderTest
    {
        public FileUploaderTest()
        {

        }

        [Fact]
        public async Task DeletePhotoAsyncTest()
        {
            var credentials = GoogleCredential.FromFile($"./iRentalServiceAccount.json");
            var someOptions = Options.Create<FirestoreOptions>(new FirestoreOptions { ProjectId = "realestatetestapp-717da" });

            var storage = new FileUploader(credentials, someOptions);

            await storage.DeletePhotoAsync("avatars/e4813520-f327-4fc8-aa34-7280d64b4d8e");
        }

        [Fact]
        public async Task<PhotoEntity> UploadAdvertPhotoAsyncTest()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task<PhotoEntity> UploadAvatarPhotoAsyncTest()
        {
            throw new NotImplementedException();
        }
    }
}
