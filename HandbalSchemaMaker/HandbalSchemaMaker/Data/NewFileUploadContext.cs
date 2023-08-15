using HandbalSchemaMaker.Data.DataStrucures;
using Microsoft.EntityFrameworkCore;

namespace HandbalSchemaMaker.Data;

public class NewFileUploadContext : GeneralContext
{
    public DbSet<NewFileUpload>? NewFileUpload { get; set; }
}