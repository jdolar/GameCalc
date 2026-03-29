using Data.Enums.Race;
using Data.Enums.Unit;
using Data.Models;
using System.Text.Json;
namespace Data;

public static class DataBuilder
{
    public static List<Game> GetGames(string fileName)
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json", fileName);
        string json = File.ReadAllText(path);

        return JsonSerializer.Deserialize<List<Game>>(json, Constants.Json.SerializerOptions) ?? [];
    }
    public static List<Unit> GetDataSource(List<Unit> units, Enums.Unit.Type type, Purpose purpose)
    {
        if (!Enum.IsDefined(type))
        {
            throw new System.ComponentModel.InvalidEnumArgumentException(nameof(type), (int)type, typeof(Enums.Unit.Type));
        }

        return [.. units.Where(u => u.Type == type && u.Purpose == purpose)];
    }
    public static List<Game> GetGamesData(List<Game> gamesFromJson, string[] gamesPathFolders)
    {
        List<Race> races = GetRaces("Races2");

        List<Game> results = [];
        for (int i = 0; i < gamesPathFolders.Length; i++)
        {
            string itemTypeFromFile = Path.GetFileName(gamesPathFolders[i]);
            if (Enum.TryParse<Enums.Game.Type>(itemTypeFromFile, ignoreCase: true, out Enums.Game.Type itemType))
            {
                Game? game = gamesFromJson.Find(g => g.Type == itemType);
                if (game == null)
                    continue;

                if (game.Id == default)
                    game.Id = results.Count + 1;

                List<Unit> baseUnitsFromFiles = GetDataFromJsonFiles(gamesPathFolders[i]);
                List<Race> availableRaces = [.. races.Where(r => r.Type == game.Type)];

                game.Races = [];
                foreach (Race raceTemplate in availableRaces)
                {
                    Race race = raceTemplate.Clone();
                    List<Unit> filteredBase = FilterByEvolution(baseUnitsFromFiles, race);

                    if (race.Units == null || race.Units.Count == 0)
                        race.Units = filteredBase;
                    else
                        race.Units = race.Units.MergeWith(filteredBase, race.Evolution);

                    game.Races.Add(race);
                  //  race.Units.DumpToFile(race.Name);
                }

                results.Add(game);
            }
        }

        return results;
    }
    internal static List<Unit> FilterByEvolution(List<Unit> units, Race race)
    {
        return race.Evolution switch
        {
            Evolution.Basic => [.. units.Where(unit => unit.Evolution == Evolution.Basic || unit.Evolution == Evolution.NA)],
            Evolution.Ascended => [.. units.Where(unit => unit.Evolution == Evolution.Ascended || unit.Evolution == Evolution.NA)],
            _ => [],
        };
    }
    internal static List<Unit> GetGameDataSection(string[] files, Enums.Unit.Type itemType)
    {
        List<Unit> results = [];
        foreach (string file in files)
        {
            string itemTypeFromFile = Path.GetFileNameWithoutExtension(file);
            if (Enum.TryParse<Purpose>(itemTypeFromFile, ignoreCase: true, out Purpose itemPurpose))
            {
                string json = File.ReadAllText(file);
                List<Unit> units = JsonSerializer.Deserialize<List<Unit>>(json, Constants.Json.SerializerOptions) ?? [];

                foreach (Unit unit in units)
                {
                    unit.Type = itemType;
                    unit.Purpose = itemPurpose;
                }

                results.AddRange(units);
            }
        }
        return results;
    }
    internal static List<Unit> GetDataFromJsonFiles(string gamePath)
    {
        List<Unit> units = [];

        string[] gameDirectories = Directory.GetDirectories(gamePath);
        for (int i = 0; i < gameDirectories.Length; i++)
        {
            string unitsFolderName = Path.GetFileName(gameDirectories[i]);
            string unitsPath = Path.Combine(gamePath, unitsFolderName);

            if (Enum.TryParse<Enums.Unit.Type>(unitsFolderName, ignoreCase: true, out Enums.Unit.Type itemType))
            {
                string[] unitFiles = Directory.GetFiles(unitsPath, "*.json");
                List<Unit> unitsData = GetGameDataSection(unitFiles, itemType);
                units.AddRange(unitsData);
            }
        }

        return units;
    }
    internal static List<Race> GetRaces(string? fileName = null)
    {
        fileName ??= "Races";
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json", fileName);
        string[]? files = Directory.GetFiles(path, "*.json");

        List<Race> races = [];
        foreach (var file in files)
        {
            string json = File.ReadAllText(file);
            Race race = JsonSerializer.Deserialize<Race>(json, Constants.Json.SerializerOptions) ?? new Race();

            if (race.Enabled)
            {
                if(string.IsNullOrEmpty(race.Name))
                    race.Name = race.Type.ToString();

                if (race.Id == default)
                    race.Id = races.Count + 1;

                races.Add(race);
            }         
        }

        return races;
    }
}
