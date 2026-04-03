using Data.Models;
using System.Text.Json;
namespace Data;
public static class Users
{
    public static User Create(string? name, string path)
    {
        User user = new()
        {
            Name = name ?? string.Empty
        };

        user.Accounts.Add(CreateAccount(Enums.Game.Type.Main));
        user.Accounts.Add(CreateAccount(Enums.Game.Type.Ascended));
        user.Accounts.Add(CreateAccount(Enums.Game.Type.NewGrounds));

        for (int i = 0; i < user.Accounts.Count; i++)
            user.Accounts[i].Name = !string.IsNullOrEmpty(user.Accounts[i].Name) ? user.Accounts[i].Name : user.Accounts[i].GameType.ToString();

        if (Directory.Exists(path))
            File.Delete(path);

        string json = JsonSerializer.Serialize(user, Constants.Json.SerializerOptions);
        File.WriteAllText(path, json);

        return user;
    }
    public static User Get(string path)
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<User>(json, Constants.Json.SerializerOptions) ?? new User();
    }
    private static Account CreateAccount(Enums.Game.Type gameType, string? name = null)
     {
        Account account = new()
        {
            GameType = gameType,
            Name = !string.IsNullOrEmpty(name) ? name : gameType.ToString()
        };

        account.Properties.Add(Constants.Users.Id, default);
        account.Properties.Add(Constants.Users.Covert, default);
        account.Properties.Add(Constants.Users.AntiCovert, default);       
        account.Properties.Add(Constants.Users.UnitProduction, default);
        account.Properties.Add(Constants.Users.RecruitmentId, default);

        if(gameType == Enums.Game.Type.Main)
        {
            account.Properties.Add(Constants.Users.Ascension, default);
            account.Properties.Add(Constants.Users.MsFleets, default);
            account.Properties.Add(Constants.Users.MsWeapons, default);
            account.Properties.Add(Constants.Users.MsShields, default);
            account.Properties.Add(Constants.Users.Race, default);   
        }

        return account;
    }
}
