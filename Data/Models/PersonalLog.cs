namespace Data.Models;
public sealed class PersonalLog
{
    public DateTime Created { get; set; }
    public string Owner { get; set; } = string.Empty;
    public List<PersonalLogEntry> Entries { get; set; } = [];
}
