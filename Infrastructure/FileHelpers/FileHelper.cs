using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;
using SkiaSharp;


namespace AnytourApi.Infrastructure.FileHelper;

public class FileHelper : IFileHelper
{
    public void DeleteFile(string[] path, string fileName)
    {
        try
        {
            File.Delete(Path.Combine(GetBasePath(path), fileName));
        }
        catch (DirectoryNotFoundException) { }
    }

    public void DeleteFile(string path)
    {
        try
        {
            File.Delete(path);
        }
        catch (DirectoryNotFoundException) { }
    }

    public byte[] GetFile(string path)
    {
        return File.ReadAllBytes(path);
    }

    public byte[] GetFile(string[] path, string fileName)
    {
        var filePath = Path.Combine(GetBasePath(path), fileName);
        return File.ReadAllBytes(filePath);
    }

    public void OverrideFileImage(IFormFile file, string path)
    {
        SaveImageToWebp(file, path, 80);
    }

    public string UploadFileImage(IFormFile file, string[] path)
    {
        var targetDirectory = GetBasePath(path);
        EnsureDirectoryExists(targetDirectory);

        var webPFileName = $"{Guid.NewGuid()}.webp";
        var filePath = Path.Combine(targetDirectory, webPFileName);

        SaveImageToWebp(file, filePath, 100);
        return filePath;
    }

    public string UploadFileImage(IFormFile file, string[] path, string fileName)
    {
        var targetDirectory = GetBasePath(path);
        EnsureDirectoryExists(targetDirectory);

        var webPFileName = $"{fileName}.webp";
        var filePath = Path.Combine(targetDirectory, webPFileName);

        SaveImageToWebp(file, filePath, 80);
        return filePath;
    }

    public (int height, int width) GetHeightAndWidthOfImage(IFormFile file)
    {
        using var inputStream = file.OpenReadStream();
        using var skBitmap = SKBitmap.Decode(inputStream);
        return (skBitmap.Height, skBitmap.Width);
    }

    private string GetBasePath(string[] pathSegments)
    {
        return Path.Combine(Directory.GetCurrentDirectory(), Path.Combine(pathSegments));
    }

    private void EnsureDirectoryExists(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    private void SaveImageToWebp(IFormFile file, string outputPath, int quality)
    {
        using var inputStream = file.OpenReadStream();
        using var skBitmap = SKBitmap.Decode(inputStream);
        using var image = SKImage.FromBitmap(skBitmap);
        using var data = image.Encode(SKEncodedImageFormat.Webp, quality);
        using var stream = File.OpenWrite(outputPath);
        data.SaveTo(stream);
    }
}