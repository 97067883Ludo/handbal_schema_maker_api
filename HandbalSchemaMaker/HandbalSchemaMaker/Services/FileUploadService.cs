using HandbalSchemaMaker.Data;
using HandbalSchemaMaker.Data.DataStrucures;
using Microsoft.AspNetCore.StaticFiles;
namespace HandbalSchemaMaker.Services;

public class FileUploadService
{
    
    public static async Task<NewFileUpload> ProcessFile(IFormFile? file)
    {
        var provider = new FileExtensionContentTypeProvider();
        provider.Mappings.Clear();
        provider.Mappings.Add(".pdf", "application/pdf");

        if (!provider.TryGetContentType(file.FileName, out _))
        {
            throw new Exception("file type is not correct");
        }
        
        string filePath = await WriteFile(file);
        
        NewFileUpload NewlyUploadedFile = new NewFileUpload()
        {
            FilePath = filePath,
            Key = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(),
        };
        
        using (var db = new NewFileUploadContext())
        {
            db.Add(NewlyUploadedFile);
            db.SaveChanges();
        }
        
        Console.WriteLine(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
        
        return NewlyUploadedFile;
    }

    private static async Task<string> WriteFile(IFormFile file)
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
        

        return filePath;
    }
}