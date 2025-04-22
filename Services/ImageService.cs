public interface IImageService
{
    Task<string> SaveImageAsync(IFormFile file);
}

public class ImageService : IImageService
{
    private readonly IWebHostEnvironment _env;

    public ImageService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public async Task<string> SaveImageAsync(IFormFile file)
    {
        var imagesPath = Path.Combine(_env.WebRootPath, "images");
        if (!Directory.Exists(imagesPath))
            Directory.CreateDirectory(imagesPath);

        var ext = Path.GetExtension(file.FileName);
        var fileName = $"{Guid.NewGuid()}{ext}";
        var filePath = Path.Combine(imagesPath, fileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        return $"/images/{fileName}";
    }
}