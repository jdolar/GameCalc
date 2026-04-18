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

        var gameTypes = Enum.GetValues<Enums.Game.Type>();
        foreach (var gameType in gameTypes)
            user.Accounts.Add(CreateAccount(gameType));

        if (Directory.Exists(path))
            File.Delete(path);

        string json = JsonSerializer.Serialize(user, Constants.Json.SerializerOptions);
        File.WriteAllText(path, json);

        return user;
    }
    public static User Get(string path)
    {
        string json = File.ReadAllText(path);
        User user = JsonSerializer.Deserialize<User>(json, Constants.Json.SerializerOptions) ?? new User();

        int accountCount = user.Accounts.Count;
        for (int i= 0; i < accountCount; i++)
        {
            if(user.Accounts[i].Name == null)
                user.Accounts[i].Name = user.Accounts[i].GameType.ToString();
        }

        return user;
    }
    private static Account CreateAccount(Enums.Game.Type gameType, string? name = null)
    {
        Account account = new();
        account.GameType = gameType;
        account.Properties.Add(Constants.Users.Id, default);
     
        if (gameType == Enums.Game.Type.Main)
        {
            account.Properties.Add(Constants.Users.Covert, default);
            account.Properties.Add(Constants.Users.AntiCovert, default);
            account.Properties.Add(Constants.Users.UnitProduction, default);
            account.Properties.Add(Constants.Users.Ascension, default);
            account.Properties.Add(Constants.Users.MsFleets, default);
            account.Properties.Add(Constants.Users.MsWeapons, default);
            account.Properties.Add(Constants.Users.MsShields, default);
            account.Properties.Add(Constants.Users.RaceId, default);
        }

        if (gameType == Enums.Game.Type.Main || gameType == Enums.Game.Type.NewGrounds)
        {
            account.Properties.Add(Constants.Users.RecruitmentId, default);
        }

        return account;
    }
}
