namespace Data.Models;
public sealed class PersonalLogEntry
{
    public Enums.PersonalLog.EntryType Type { get; set; }  
    public string Name { get; set; } = string.Empty;
    public int Id { get; set; }
}
