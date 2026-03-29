namespace Data.Models;
public sealed class Account
{
    public Enums.Game.Type GameType { get; set; }
    public string Name { get; set; } = string.Empty;
    public Dictionary<string, int> Properties { get; set; } = [];
}
