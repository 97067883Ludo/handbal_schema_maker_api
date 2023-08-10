using Microsoft.EntityFrameworkCore;

namespace HandbalSchemaMaker.Data;

public class GeneralContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public GeneralContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("default"));
    }
}