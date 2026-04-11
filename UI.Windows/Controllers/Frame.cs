using Calculator;
using Data;
using Data.Commands;
using Data.Models;
using UI.Windows.Helpers;
namespace UI.Windows.Controllers;

internal sealed class Frame
{
    private readonly ComboBox _games, _races, _valueToCopy, _amountToCopy;
    private readonly Label _user;
    private readonly ToolTip _hints;
    private readonly ActiveUser _activeUser = UIController.GetUser();
    public Frame(ComboBox races, ComboBox games, ComboBox amountToCopy, ComboBox valueToCopy, Label user, Button generatePersonalLog, Button copyToClipBoard, ToolTip hints, ref Game selectedGame)
    {
        _hints = hints;
        _valueToCopy = valueToCopy;
        _amountToCopy = amountToCopy;
        _user = user;
        _games = games;
        _races = races;

        int gameId = _activeUser.ActiveAccount.Properties.TryGetValue(Constants.Users.GameId, out gameId) ? gameId : 0;
        UIController.SetGamesComboBox(_games, _activeUser.Games, gameId);
        selectedGame = (Game)_games.SelectedItem!;
        _activeUser.ActiveGame = selectedGame;
        _games.SelectedIndexChanged += (s, e) => UpdateSelectedGame();

        int raceId = _activeUser.ActiveAccount.Properties.TryGetValue(Constants.Users.RaceId, out raceId) ? raceId : 0;
        UIController.SetRacesComboBox(_races, _activeUser.ActiveGame.Races, raceId);
        _activeUser.ActiveRace = (Race)_races.SelectedItem!;
        _races.SelectedIndexChanged += (s, e) => UpdateSelectedRace();

        UIController.SetToolTip(hints);

        _valueToCopy.SelectedIndex = 0;
        _amountToCopy.SelectedIndex = 0;
        copyToClipBoard.Click += (s, e) => CopyToClipBoard();

        string log = Hints.PersonalLog(DataBuilder.GetLog(_activeUser.User.Name));
        generatePersonalLog.Click += (s, e) => UIController.CopyToClipboard(log, false);
        _hints.SetToolTip(generatePersonalLog, log);

        UpdateSelectedGame();
        UpdateUser();
    }
    public void UpdateSelectedGame()
    {
        if (_games.SelectedItem != null)
        {
            _activeUser.ActiveGame = (Game)_games.SelectedItem;
            _hints.SetToolTip(_games, Hints.Game(_activeUser.ActiveGame));

            UpdateSelectedAccount();

            UIController.SetRacesComboBox(_races, _activeUser.ActiveGame.Races, _activeUser.ActiveRace.Id);           
            UpdateSelectedRace();
        }
    }
    public void UpdateSelectedAccount()
    {
        _activeUser.ActiveAccount = _activeUser.User.Accounts.Find(x => x.Properties.ContainsKey(Constants.Users.GameId)
                                                                     && x.Properties[Constants.Users.GameId].ToString() == _activeUser.ActiveGame.Id.ToString())
                                                                     ?? _activeUser.User.Accounts[0];
        UpdateUser();
    }
    private void UpdateSelectedRace()
    {
        if (_races.SelectedItem != null && _activeUser.ActiveRace != null)
        {
            _activeUser.ActiveRace = (Race)_races.SelectedItem;
            _hints.SetToolTip(_races, Hints.Race(_activeUser.ActiveRace));
        }
    }
    private void CopyToClipBoard()
    {
        long right = 0;
        string? value = _valueToCopy.SelectedItem?.ToString();
        if (value != null) return;

        if (value == "Million")
            right = 1_000_000;
        else if (value == "Billion")
            right = 1_000_000_000;
        else if (value == "Trillion")
            right = 1_000_000_000_000;

        long left = Data.Commands.Convert.ToNumber(Clean.Text(_amountToCopy.Text));
        long result = Operation.Multiply(left, right);

        UIController.CopyToClipboard(result.ToString());

        _hints.SetToolTip(_amountToCopy, Data.Hints.CopyToClipBoard(Data.Commands.Convert.ToLabel(result)));
        _hints.SetToolTip(_valueToCopy, Data.Commands.Convert.ToLabel(right));
    }
    private void UpdateUser()
    {
        UIController.UpdateLabel(_user, _activeUser.ActiveAccount.Name);
        _hints.SetToolTip(_user, Hints.User(_activeUser.User, _activeUser.ActiveGame.Races, _activeUser.ActiveAccount.GameType));
    }
}
