using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HandbalSchemaMaker.Data.DataStrucures;

public class NewFileUpload
{
    [Key]
    public int Id { get; set; }
    
    [JsonIgnore]
    public string FilePath { get; set; } = String.Empty; 

    public string Key { get; set; } = String.Empty;
}