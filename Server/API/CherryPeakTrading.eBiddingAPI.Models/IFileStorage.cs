using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CherryPeakTrading.Infrastructure.Contracts
{
    public interface IFileStorage
    {
        string UploadFile(Stream fileStream, string fileMimeType, string containerName);
    }
}
