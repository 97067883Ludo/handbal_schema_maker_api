using System.ComponentModel.DataAnnotations;

namespace HandbalSchemaMaker.Data.DataStrucures;

public class Match
{
    [Key] 
    public int MatchId { get; set; }

    public int MatchNumber { get; set; }

    public string Date { get; set; } = String.Empty;
    
    public string Time { get; set; } = String.Empty;
    
    public string HomeTeam { get; set; } = String.Empty;

    public string OutTeam { get; set; } = String.Empty;

    public string? Referee1 { get; set; }

    public string? Referee2 { get; set; }

    public string? TableService { get; set; }

    public string? Field { get; set; }

}