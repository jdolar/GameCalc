using Calculator;
using Data;
using Data.Commands;
using Data.Enums.Unit;
using Data.Models;
using UI.Windows.Calculators;
using UI.Windows.Helpers;
namespace UI.Windows;

public partial class Display : Form
{
    internal Race _selectedRace = new();
    readonly List<Game> _enabledGames = UIData.GetGames();
    Game _selectedGame = new();
    internal TheCalc _theCalc = null!;
    internal UpCalc _upCalc = null!;
    internal SimpleCalc _simpleCalc = null!;
    public Display()
    {
        InitializeComponent();

        UIData.SetGamesComboBox(_games, _enabledGames);
        UIData.SetRacesComboBox(_races, _selectedGame.Races);

        Text = $"{AppInfo.Name} v{AppInfo.Version}";
        _tabPageTheCalc.Text = Constants.GUI.Labels.TheCalc;
        _tabPageUpCalc.Text = Constants.GUI.Labels.UpCalc;
        _tabPageSimpleCalc.Text = Constants.GUI.Labels.SimpleCalc;

        _games.SelectedIndexChanged += (s, e) => UpdateSelectedGame();
        _races.SelectedIndexChanged += (s, e) => UpdateSelectedRace();

        _theCalc = new TheCalc(this);
        _simpleCalc = new SimpleCalc(this);
        _upCalc = new UpCalc(this);

        UpdateSelectedGame();

        _hint.ConfigureTooltip();
    }

    private void UpdateSelectedRace()
    {
        if (_races.SelectedItem != null)
        {
            _selectedRace = (Race)_races.SelectedItem;
            _hint.SetToolTip(_races, Hints.GetRace(_selectedRace));

            UIData.UpdateLabel(_resToSpend, $"{_selectedRace.Currency.Name} {Constants.GUI.Labels.ResourcesToSpend}");
            UIData.UpdateTextBox(_selectedItems, _selectedRace.Units, (Data.Enums.Unit.Type)_itemTypes.SelectedItem!, (Purpose)_itemPurposes.SelectedItem!);
        }
    }
    private void UpdateSelectedGame()
    {
        if (_games.SelectedItem != null)
        {
            _selectedGame = (Game)_games.SelectedItem;

            UIData.SetRacesComboBox(_races, _selectedGame.Races);
            _hint.SetToolTip(_games, Hints.GetGame(_selectedGame));
            UpdateSelectedRace();
        }
    }
}
