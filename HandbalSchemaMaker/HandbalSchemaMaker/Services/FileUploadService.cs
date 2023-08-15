using Microsoft.AspNetCore.StaticFiles;
namespace HandbalSchemaMaker.Services;

public class FileUploadService
{
    public static async Task<bool> ProcessFile(IFormFile? file)
    {
        var provider = new FileExtensionContentTypeProvider();
        provider.Mappings.Clear();
        provider.Mappings.Add(".pdf", "application/pdf");

        if (!provider.TryGetContentType(file.FileName, out _))
        {
            throw new Exception("file type is not correct");
        }
        
        await WriteFile(file);
        
        return true;
    }

    private static async Task<bool> WriteFile(IFormFile file)
    {
        string filePath = Path.Combine(Thread.GetDomain().BaseDirectory, "uploadedFiles//", file.FileName);

        if (System.IO.File.Exists(filePath))
        {
            throw new Exception("file already exists");
        }

        await using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
            fileStream.Flush();
        }
        
        //save file path to database.
        
        return true;
    }
}