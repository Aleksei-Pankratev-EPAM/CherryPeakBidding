using System.IO;

namespace CherryPeakTrading.Infrastructure.Contracts
{
    public interface IFileStorage
    {
        string UploadFile(Stream fileStream, string fileMimeType, string containerName);
    }
}
