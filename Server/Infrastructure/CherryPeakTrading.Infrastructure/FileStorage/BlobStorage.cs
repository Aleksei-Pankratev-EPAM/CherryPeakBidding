using CherryPeakTrading.API.Models;
using CherryPeakTrading.Infrastructure.Contracts;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CherryPeakTrading.Infrastructure.FileStorage
{
    public class BlobStorage : IFileStorage
    {
        private readonly CloudBlobClient _cloudBlobClient;

        private readonly ILogger _logger;

        public BlobStorage(CloudBlobClient cloudBlobClient, ILogger<BlobStorage> logger)
        {
            _cloudBlobClient = cloudBlobClient;
            _logger = logger;
        }

        public string UploadFile(Stream fileStream, string fileMimeType, string containerName)
        {
            try
            {
                // Creating a container for each lot
                string strContainerName = containerName;
                CloudBlobContainer cloudBlobContainer = _cloudBlobClient.GetContainerReference(strContainerName);
                if (cloudBlobContainer.CreateIfNotExists())
                {
                    _logger.LogInformation("Create new Container for lot {ContainerName}", containerName);
                    cloudBlobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                }

                string fileName = Guid.NewGuid().ToString();
                if (fileName != null && fileStream != null)
                {
                    _logger.LogInformation("Start uploading a new photo {FileName} in container {ContainerName}", fileName, containerName);
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
                    cloudBlockBlob.Properties.ContentType = fileMimeType;
                    cloudBlockBlob.UploadFromStream(fileStream);
                    _logger.LogInformation("Photo {fileName} was loaded in container {ContainerName}, uri: {PhotoURI}", fileName, containerName, cloudBlockBlob.Uri.AbsoluteUri);

                    return cloudBlockBlob.Uri.AbsoluteUri;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return "";
        }
    }
}
