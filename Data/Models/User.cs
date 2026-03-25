namespace Data.Models;
public sealed class User
{
    public string Name { get; set; } = string.Empty;
    public List<Account> Accounts { get; set; } = [];
}
