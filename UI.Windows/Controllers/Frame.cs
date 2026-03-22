using Data.Models;
using UI.Windows.Helpers;
namespace UI.Windows.Controllers;
internal sealed class Frame
{
    public Game SelectedGame { get; set; }
    public Race SelectedRace { get; set; }

    private readonly ComboBox _games, _races;
    private readonly ToolTip _hints;
   
    public Frame(ComboBox races, ComboBox games, ToolTip hints)
    {
        List<Game> enabledGames = UIController.GetGames();
        _hints = hints;

        _games = games;
        UIController.SetGamesComboBox(_games, enabledGames);
        SelectedGame = (Game)_games.SelectedItem!;
        _games.SelectedIndexChanged += (s, e) => UpdateSelectedGame();

        _races = races;
        UIController.SetRacesComboBox(_races, SelectedGame.Races);
        SelectedRace = (Race)_races.SelectedItem!;
        _races.SelectedIndexChanged += (s, e) => UpdateSelectedRace();

        hints.InitialDelay = 0;
        hints.ReshowDelay = 0;
        hints.AutoPopDelay = 8000;
        hints.ShowAlways = true;
        hints.OwnerDraw = true;

        hints.Popup += (s, e) =>
        {
            using Font font = new("Consolas", 9);

            Size size = TextRenderer.MeasureText(
                hints.GetToolTip(e.AssociatedControl),
                font);

            e.ToolTipSize = size;
        };

        hints.Draw += (s, e) =>
        {
            using Font font = new("Consolas", 9);
            e.DrawBackground();
            e.DrawBorder();

            TextRenderer.DrawText(
                e.Graphics,
                e.ToolTipText,
                font,
                e.Bounds,
                Color.Black,
                TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix);
        };

        UpdateSelectedGame();
        
    }
    public void UpdateSelectedGame()
    {
        if (_games.SelectedItem != null)
        {
            SelectedGame = (Game)_games.SelectedItem;
            _hints.SetToolTip(_games, Data.Hints.Game(SelectedGame));

            UIController.SetRacesComboBox(_races, SelectedGame.Races);
            UpdateSelectedRace();
        }
    }
    private void UpdateSelectedRace()
    {
        if (_races.SelectedItem != null && SelectedRace != null)
        {
            SelectedRace = (Race)_races.SelectedItem;
            _hints.SetToolTip(_races, Data.Hints.Race(SelectedRace));
        }
    }
}
