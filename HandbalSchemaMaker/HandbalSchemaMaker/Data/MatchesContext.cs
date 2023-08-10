using Microsoft.EntityFrameworkCore;
using HandbalSchemaMaker.Data.DataStrucures;

namespace HandbalSchemaMaker.Data;

public class MatchesContext : GeneralContext
{
    private DbSet<Match>? Match { get; set; }
}