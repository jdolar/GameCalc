using Calculator;
using Data.Commands;
using Data.Models;
using UI.Windows.Helpers;
namespace UI.Windows.Controllers;

internal sealed class Frame
{
    public Game SelectedGame { get; set; }
    public Race SelectedRace { get; set; }

    private const long _billion = 1_000_000_000;
    private const long _trillion = 1_000_000_000_000;
    private readonly ComboBox _games, _races, _valueToCopy, _amountToCopy;
    private readonly Label _user;
    private User _activeUser = new();
    private readonly ToolTip _hints;
    public Frame(ComboBox races, ComboBox games, ComboBox amountToCopy, ComboBox valueToCopy, Label user, ToolTip hints, ref Game selectedGame)
    {
        SetUser();

        List<Game> enabledGames = UIController.Games;
        _hints = hints;
        _valueToCopy = valueToCopy;
        _amountToCopy = amountToCopy;
        _user = user;

        _games = games;
        UIController.SetGamesComboBox(_games, enabledGames);
        selectedGame = (Game)_games.SelectedItem!;
        SelectedGame = selectedGame;
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

        _amountToCopy.SelectedIndex = 0;
        _amountToCopy.SelectedIndexChanged += (s, e) => CopyToClipBoard();
        _amountToCopy.Click += (s, e) => CopyToClipBoard();

        _valueToCopy.SelectedIndex = 0;
        _valueToCopy.SelectedIndexChanged += (s, e) => CopyToClipBoard();
        _valueToCopy.Click += (s, e) => CopyToClipBoard();

        UpdateSelectedGame();
        UpdateUser();

        CopyToClipBoard();
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
    private void CopyToClipBoard()
    {
        long right = 0;
        if (_valueToCopy.SelectedItem?.ToString() == "Billion")
            right = _billion;
        else if (_valueToCopy.SelectedItem?.ToString() == "Trillion")
            right = _trillion;

        long left = Data.Commands.Convert.ToNumber(Clean.Text(_amountToCopy.Text));
        long result = Calc.Multiply(left, right);

        UIController.CopyToClipboard(result.ToString());

        _hints.SetToolTip(_amountToCopy, Data.Hints.CopyToClipBoard(Data.Commands.Convert.ToLabel(result)));
        _hints.SetToolTip(_valueToCopy, Data.Commands.Convert.ToLabel(right));
    }
    private void SetUser()
    {
        _activeUser = UIController.GetUser();
    }
    private void UpdateUser()
    {
        UIController.UpdateLabel(_user, _activeUser.Name);
        _hints.SetToolTip(_user, Data.Hints.User(_activeUser, SelectedGame.Races));
    }
}
