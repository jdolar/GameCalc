namespace Data.Models;
public sealed class Account
{
    public Enums.Game.Type GameType { get; set; } = Enums.Game.Type.Main;
    public Dictionary<string, int> Properties { get; set; } = [];
}
