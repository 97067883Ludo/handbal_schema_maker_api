using System.ComponentModel.DataAnnotations;

namespace HandbalSchemaMaker.Data.DataStrucures;

public class NewFileUpload
{
    [Key]
    public int Id { get; set; }
    
    public string FilePath { get; set; } = String.Empty; 

    public string Key { get; set; } = String.Empty;
}