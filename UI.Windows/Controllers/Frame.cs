using Calculator;
using Data;
using Data.Commands;
using Data.Models;
using UI.Windows.Helpers;
namespace UI.Windows.Controllers;
internal sealed class Frame
{
    private readonly ComboBox _games, _races, _multipliers, _weights;
    private readonly Label _user;
    private readonly ToolTip _hints;
    private readonly TabControl _tab;
    private readonly Session _session = UIController.CreateSession();
    private readonly List<TabPage> _pages;
    public Frame(ComboBox races, ComboBox games, ComboBox amountToCopy, ComboBox valueToCopy, Label user, Button copyToClipBoardPersonalLog, Button copyToClipBoard, System.Windows.Forms.ToolTip hints, TabControl tab, ref Game selectedGame)
    {
        _hints = hints;
        _multipliers = valueToCopy;
        _weights = amountToCopy;
        _user = user;
        _games = games;
        _races = races;
        _tab = tab;
        _pages = _tab.TabPages.Cast<TabPage>().ToList();

        int gameId = _session.ActiveAccount.Properties.TryGetValue(Constants.Users.GameId, out gameId) ? gameId : 0;
        UIController.SetGames(_games, _session.Games, gameId);
        selectedGame = (Game)_games.SelectedItem!;
        _session.ActiveGame = selectedGame;
        _games.SelectedIndexChanged += (s, e) => UpdateSelectedGame();

        int raceId = _session.ActiveAccount.Properties.TryGetValue(Constants.Users.RaceId, out raceId) ? raceId : 0;
        UIController.SetRaces(_races, _session.ActiveGame.Races, raceId);
        _session.ActiveRace = (Race)_races.SelectedItem!;
        _races.SelectedIndexChanged += (s, e) => UpdateSelectedRace();

        UIController.SetToolTip(hints);

        copyToClipBoard.Click += (s, e) => CopyToClipBoard();

        string log = Hints.PersonalLog(DataBuilder.GetLog(_session.User.Name));
        copyToClipBoardPersonalLog.Click += (s, e) => UIController.CopyToClipboard(log, false);
        _hints.SetToolTip(copyToClipBoardPersonalLog, log);

        UpdateSelectedGame();
        UpdateUser();

        UIController.SetWeights(_weights);
        UIController.SetMultipliers(_multipliers);
    }
    public void UpdateSelectedGame()
    {
        if (_games.SelectedItem != null)
        {
            _session.ActiveGame = (Game)_games.SelectedItem;

            UIController.AddTabs(_tab, _pages, _session.ActiveGame.Calculators);
            
            _hints.SetToolTip(_games, Hints.Game(_session.ActiveGame));

            UpdateSelectedAccount();
            UIController.SetRaces(_races, _session.ActiveGame.Races, _session.ActiveRace.Id);               
            UpdateSelectedRace();
        }
    }
    public void UpdateSelectedAccount()
    {
        _session.ActiveAccount = _session.User.Accounts.Find(x => x.Properties.ContainsKey(Constants.Users.GameId)
                                                                     && x.Properties[Constants.Users.GameId].ToString() == _session.ActiveGame.Id.ToString())
                                                                     ?? _session.User.Accounts[0];
        UpdateUser();
    }
    private void UpdateSelectedRace()
    {
        if (_races.SelectedItem != null && _session.ActiveRace != null)
        {
            _session.ActiveRace = (Race)_races.SelectedItem;
            _hints.SetToolTip(_races, Hints.Race(_session.ActiveRace));
        }
    }
    private void CopyToClipBoard()
    {
        string? value = _multipliers.SelectedItem?.ToString();
        if (string.IsNullOrEmpty(value)) return;

        Constants.Multipliers.TryGetValue(value!, out long right);

        long left = Data.Commands.Convert.ToNumber(Clean.Text(_weights.Text));
        long result = Operation.Multiply(left, right);

        UIController.CopyToClipboard(result.ToString());

        _hints.SetToolTip(_weights, Hints.CopyToClipBoard(Data.Commands.Convert.ToLabel(result)));
        _hints.SetToolTip(_multipliers, Data.Commands.Convert.ToLabel(right));
    }
    private void UpdateUser()
    {
        UIController.UpdateLabel(_user, _session.ActiveAccount.Name ?? "Unknown");
        _hints.SetToolTip(_user, Hints.User(_session.User, _session.ActiveGame.Races, _session.ActiveAccount.GameType));
    }
}
