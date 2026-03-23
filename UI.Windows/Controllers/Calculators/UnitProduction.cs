using Calculator;
using Data;
using Data.Models;
using UI.Windows.Helpers;
using Label = System.Windows.Forms.Label;
namespace UI.Windows.Controllers.Calculators;
internal sealed class UnitProduction
{
    private readonly ComboBox _races;
    private Race _selectedRace = new();
    public UnitProduction(Label currentUp, Label desiredUp, Label resToSpendText, Label upResult,
                  TextBox fromInput, TextBox toInput, TextBox resToSpend, Button calculateDesiredUp,
                  Button calculateNaqToSpend, ToolTip hints, ComboBox races, TabPage tabPage)
    {
        UIController.UpdateLayoutTabPage(tabPage, Constants.GUI.Labels.UnitProduction);

        UIController.UpdateLabel(currentUp, Constants.GUI.Labels.CurrentUp);
        UIController.UpdateLabel(desiredUp, Constants.GUI.Labels.DesiredUp);
        UIController.UpdateLabel(resToSpendText, Constants.GUI.Labels.ResourcesToSpend);
        UIController.UpdateLabel(upResult, string.Empty);

        UIController.UpdateTextBox(fromInput, string.Empty);
        UIController.UpdateTextBox(toInput, string.Empty);
        UIController.UpdateTextBox(resToSpend, string.Empty);

        _races = races;
        _races.SelectedIndexChanged += (s, e) => UpdateSelectedRace(resToSpendText);

        calculateDesiredUp.Click += (s, e) =>
        {
            (string results, string multiplier, string formattedLeftInput, string formattedRightInput)
                = Calc.CalculateDesiredUp(fromInput.Text, toInput.Text);

            if (results != upResult.Text)
            {
                string hint = Data.Hints.DesiredUp(formattedLeftInput, formattedRightInput, results, multiplier, _selectedRace.Currency.Name);
                UIController.UpdateLabel(upResult, hint);
                hints.SetToolTip(upResult, hint);
            }
        };

        calculateNaqToSpend.Click += (s, e) =>
        {
            (string results, string multiplier, string formattedLeftInput, string formattedRightInput)
                = Calc.CalculatePossibleUpUpgrade(fromInput.Text, resToSpend.Text);

            if (results != upResult.Text)
            {
                string hint = Data.Hints.ResourcesToSpend(formattedLeftInput, formattedRightInput, results, multiplier, _selectedRace.Currency.Name);
                UIController.UpdateLabel(upResult, hint);
                hints.SetToolTip(upResult, hint);
            }
        };

        upResult.Click += (s, e) => UIController.CopyToClipboard(upResult.Text);
        currentUp.Click += (s, e) => UIController.CopyToClipboard(currentUp.Text);

        UpdateSelectedRace(resToSpendText);
    }
    private void UpdateSelectedRace(Label label)
    {
        if (_races.SelectedItem != null && _selectedRace != null)
        {
            _selectedRace = (Race)_races.SelectedItem;
            UIController.UpdateLabel(label, $"{_selectedRace.Currency.Name} {Constants.GUI.Labels.ResourcesToSpend}");
        }
    }
}
