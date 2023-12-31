using HandbalSchemaMaker.Data;
using HandbalSchemaMaker.Data.DataStrucures;
using HandbalSchemaMaker.Dto;
using HandbalSchemaMaker.Services;
using Microsoft.AspNetCore.Mvc;

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
            return UnprocessableEntity("multiple files or no files selected");
        }

        var file = Request.Form.Files.GetFile("test");

        if (file.Length == 0)
        {
            return UnprocessableEntity("empty file");
        }
        
        try
        { 
            NewFileUpload UploadedFile = await FileUploadService.ProcessFile(file);
            return Ok(UploadedFile);
        }
        catch (Exception e)
        {
            ExceptionDto exception = new ExceptionDto()
            {
                message = e.Message
            };
            return UnprocessableEntity(exception);
        }
    }
}