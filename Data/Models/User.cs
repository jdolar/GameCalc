namespace Data.Models;
public sealed class User
{
    public string Name { get; set; } = string.Empty;
    public Dictionary<string, int> Properties { get; set; } = [];
}
