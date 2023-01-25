using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Hasdrubal__Project.Services
{
    public interface IStorageService
    {
        Task<string> UploadBinary(string blobname,Stream fileContent);
        Task<Uri> DownloadBlobToLocalStorage(string blobname);
    }
    public class StorageService : IStorageService
    {
        #region Create blob
        public  async Task<string> UploadBinary(string blobname,Stream fileContent)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=blobprojectsql3;AccountKey=OPLisLcR4r9CyfagUtUFUKQLYqHGOCAdzgBNUg0N0MpSofoxAvEkZEzwHkvyY6hd9bDlTw4z+Y8U+ASt6pFj3w==;EndpointSuffix=core.windows.net";
            string containerName = "blobimages";
            var blobServiceClient = new BlobServiceClient(connectionString);

            try
            {

                BlobContainerClient containerClientTask = blobServiceClient.GetBlobContainerClient(containerName);
                containerClientTask.CreateIfNotExists();

                BlobClient blobClient = containerClientTask.GetBlobClient(blobname);

                await blobClient.UploadAsync(fileContent, true);

                return blobClient.Uri.AbsoluteUri;
            }
            catch
            {
                return "error";
            }
        }
        #endregion

        #region DownloadBlobToLocalStorage
        public async Task<Uri> DownloadBlobToLocalStorage(string blobname)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=blobprojectsql3;AccountKey=OPLisLcR4r9CyfagUtUFUKQLYqHGOCAdzgBNUg0N0MpSofoxAvEkZEzwHkvyY6hd9bDlTw4z+Y8U+ASt6pFj3w==;EndpointSuffix=core.windows.net";
            string containerName = "blobimages";
            var blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClientTask = blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClientTask.GetBlobClient(blobname);

            if (await blobClient.ExistsAsync())
            {
                return  blobClient.Uri;
            }
            return null;
        }
        #endregion
    }
}
