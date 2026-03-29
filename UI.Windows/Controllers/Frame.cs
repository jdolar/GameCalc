using Calculator;
using Data;
using Data.Commands;
using Data.Models;
using UI.Windows.Helpers;
namespace UI.Windows.Controllers;

internal sealed class Frame
{
    private const long _billion = 1_000_000_000;
    private const long _trillion = 1_000_000_000_000;
    private readonly ComboBox _games, _races, _valueToCopy, _amountToCopy;
    private readonly Label _user;
    private readonly ToolTip _hints;
    private User _activeUser = UIController.User;
    private Account _selectedAccount;
    private Game _selectedGame;
    private Race _selectedRace;
    public Frame(ComboBox races, ComboBox games, ComboBox amountToCopy, ComboBox valueToCopy, Label user, ToolTip hints, ref Game selectedGame)
    {
        _hints = hints;
        _valueToCopy = valueToCopy;
        _amountToCopy = amountToCopy;
        _user = user;
        _games = games;
        _races = races;

        List<Game> enabledGames = UIController.Games;
        var userGames = GetUserGames(enabledGames);
        
        _selectedAccount = _activeUser.Accounts[0];
        _selectedAccount.Properties.TryGetValue(Constants.Users.GameId, out int gameId);

        UIController.SetGamesComboBox(_games, userGames, gameId);
        selectedGame = (Game)_games.SelectedItem!;
        _selectedGame = selectedGame;
        _games.SelectedIndexChanged += (s, e) => UpdateSelectedGame();
       
        UIController.SetRacesComboBox(_races, selectedGame.Races);
        _selectedRace = (Race)_races.SelectedItem!;
        _races.SelectedIndexChanged += (s, e) => UpdateSelectedRace();

        UIController.SetToolTip(hints);

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
            _selectedGame = (Game)_games.SelectedItem;
            _hints.SetToolTip(_games, Data.Hints.Game(_selectedGame));

            UpdateSelectedAccount();

            UIController.SetRacesComboBox(_races, _selectedGame.Races);           
            UpdateSelectedRace();
        }
    }
    public void UpdateSelectedAccount()
    {
        _selectedAccount = _activeUser.Accounts.Find(x => x.Properties.ContainsKey(Constants.Users.GameId) && x.Properties[Constants.Users.GameId].ToString() == _selectedGame.Id.ToString()) ?? _activeUser.Accounts[0];
        UpdateUser();
    }
    private void UpdateSelectedRace()
    {
        if (_races.SelectedItem != null && _selectedRace != null)
        {
            _selectedRace = (Race)_races.SelectedItem;
            _hints.SetToolTip(_races, Data.Hints.Race(_selectedRace));
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
    private List<Game> GetUserGames(List<Game> enabledGames)
    {
        List<Game> userGames = [];
        foreach (Account account in _activeUser.Accounts)
        {
            Game? existingGame = enabledGames.Find(x => x.Type == account.GameType);
            if (existingGame != null)
            {
                account.Properties.Add(Constants.Users.GameId, existingGame.Id);
                userGames.Add(existingGame);
            }
        }

        return userGames;
    }
    private void UpdateUser()
    {
        UIController.UpdateLabel(_user, _selectedAccount.Name);
        _hints.SetToolTip(_user, Data.Hints.User(_activeUser, _selectedGame.Races, _selectedAccount.GameType));
    }
}
