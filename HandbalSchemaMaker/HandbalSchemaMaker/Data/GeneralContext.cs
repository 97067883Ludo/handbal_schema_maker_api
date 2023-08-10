using Microsoft.EntityFrameworkCore;

namespace HandbalSchemaMaker.Data;

public class GeneralContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5431;User Id=postgres;Password=mysecretpassword;Database=HandbalSchemaMaker;");
    }
}