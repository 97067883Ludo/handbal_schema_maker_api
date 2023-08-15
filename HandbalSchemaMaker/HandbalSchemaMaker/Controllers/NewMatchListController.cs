using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace HandbalSchemaMaker.Controllers;

[ApiController]
[Route("upload-nieuwe-lijst")]
public class NewMatchListController : ControllerBase
{

    [HttpPost]
    public async Task<ActionResult> Post()
    {
        if (Request.Form.Files.Count != 1)
        {
            return UnprocessableEntity("no File selected");
        }

        var file = Request.Form.Files.GetFile("test");

        if (file.Length == 0)
        {
            return UnprocessableEntity("empty file");
        }

        var provider = new FileExtensionContentTypeProvider();
        provider.Mappings.Clear();
        provider.Mappings.Add(".pdf", "application/pdf");

        if (provider.TryGetContentType(file.FileName, out _))
        {
            string filePath = Path.Combine(Thread.GetDomain().BaseDirectory, "uploadedFiles//", file.FileName);

            if (System.IO.File.Exists(filePath))
            {
                return UnprocessableEntity("dit bestand bestaat al.");
            }

            Console.WriteLine(filePath);

            await using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
                fileStream.Flush();
            }

            return Ok("uploaded successful");
        }

        return UnprocessableEntity("wrong file");
    }

    
    
}