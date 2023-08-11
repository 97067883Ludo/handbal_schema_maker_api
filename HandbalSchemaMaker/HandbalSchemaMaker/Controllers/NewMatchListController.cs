using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace HandbalSchemaMaker.Controllers;

[ApiController]
[Route("upload-nieuwe-lijst")]
public class NewMatchListController : ControllerBase
{

    [HttpPost]
    public ActionResult Post()
    {
        var provider = new FileExtensionContentTypeProvider();
        provider.Mappings.Clear();
        provider.Mappings.Add(".pdf", "application/pdf");

        if (provider.TryGetContentType(Request.Form.Files.GetFile("test").FileName, out _))
        {
            return Ok("Welcome in");
        }

        
        return new UnprocessableEntityResult();
    }
}