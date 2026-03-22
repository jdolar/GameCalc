using Data.Models;
using System.Security.Principal;
using System.Text.Json;
namespace Data;
public static class Users
{
    private static void Create(string? name, string path)
    {
        User user = new User();
        user.Name = name ?? string.Empty;

        user.Properties.Add(Constants.Users.GameId, default);
        user.Properties.Add(Constants.Users.RaceId, default);
        user.Properties.Add(Constants.Users.Id, default);
        user.Properties.Add(Constants.Users.Covert, default);
        user.Properties.Add(Constants.Users.AntiCovert, default);
        user.Properties.Add(Constants.Users.Ascension, default);
        user.Properties.Add(Constants.Users.UnitProduction, default);
        user.Properties.Add(Constants.Users.MsWeapons, default);
        user.Properties.Add(Constants.Users.MsShields, default);
        user.Properties.Add(Constants.Users.MsFleets, default);

        if (Directory.Exists(path))
            File.Delete(path);

        string json = JsonSerializer.Serialize(user);
        File.WriteAllText(path, json);
    }
    public static User Get()
    {
        string? name = WindowsIdentity.GetCurrent().User.Value ?? null;
        if (name == null)
            return new User();

        string path = Path.Combine(Directory.GetCurrentDirectory(), $"{name}.json");
        if (!File.Exists(path))
            Create(name, path);

        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<User>(json) ?? new User();
    }
}
