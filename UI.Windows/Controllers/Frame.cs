using Data;
using Data.Enums.Unit;
using Data.Models;
using UI.Windows.Helpers;
using UI.Windows.Properties;
namespace UI.Windows.Controllers;
internal sealed class Frame
{
    private readonly Display _form;
    public Frame(Display form)
    {
        _form = form;

        UIData.SetGamesComboBox(_form._games, _form._enabledGames);
        UIData.SetRacesComboBox(_form._races, _form._selectedGame.Races);

        _form.Text = $"{AppInfo.Name} v{AppInfo.Version} [{AppInfo.InfoVersion}]";
        _form._tabPageTheCalc.Text = Constants.GUI.Labels.TheCalc;
        _form._tabPageUpCalc.Text = Constants.GUI.Labels.UpCalc;
        _form._tabPageSimpleCalc.Text = Constants.GUI.Labels.SimpleCalc;

        _form._games.SelectedIndexChanged += (s, e) => UpdateSelectedGame();
        _form._races.SelectedIndexChanged += (s, e) => UpdateSelectedRace();

        _form._hint.InitialDelay = 0;
        _form._hint.ReshowDelay = 0;
        _form._hint.AutoPopDelay = 8000;
        _form._hint.ShowAlways = true;
    }
    public void UpdateSelectedGame()
    {
        if (_form._games.SelectedItem != null)
        {
            _form._selectedGame = (Game)_form._games.SelectedItem;

            UIData.SetRacesComboBox(_form._races, _form._selectedGame.Races);
            UpdateSelectedRace();

            _form._hint.SetToolTip(_form._games, Hints.Game(_form._selectedGame));
        }
    }
    private void UpdateSelectedRace()
    {
        if (_form._races.SelectedItem != null)
        {
            _form._selectedRace = (Race)_form._races.SelectedItem;
            _form._hint.SetToolTip(_form._races, Hints.Race(_form._selectedRace));

            UIData.UpdateLabel(_form._resToSpend, $"{_form._selectedRace.Currency.Name} {Constants.GUI.Labels.ResourcesToSpend}");
            UIData.UpdateTextBox(_form._selectedItems, _form._selectedRace.Units, (Data.Enums.Unit.Type)_form._itemTypes.SelectedItem!, (Purpose)_form._itemPurposes.SelectedItem!);
        }
    }
}
