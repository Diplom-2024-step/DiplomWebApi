using AnytourApi.Infrastructure.FileHelper;
using Microsoft.AspNetCore.Http;

namespace AnytourApi.SharedModels.MockObjects;

public class FileHelperMock : IFileHelper
{
    public void DeleteFile(string[] path, string fileName)
    {
    }

    public void DeleteFile(string path)
    {
    }

    public byte[] GetFile(string path)
    {
        return new byte[0];
    }

    public byte[] GetFile(string[] path, string fileName)
    {
        return new byte[0];
    }

    public (int height, int width) GetHeightAndWidthOfImage(IFormFile file)
    {
        return (128, 128);
    }

    public void OverrideFileImage(IFormFile file, string path)
    {
    }

    public string UploadFileImage(IFormFile file, string[] path, string fileName)
    {
        return "C:\\Test\\Faker";
    }

    public string UploadFileImage(IFormFile file, string[] path)
    {
        return "C:\\Test\\Faker";
    }
}
