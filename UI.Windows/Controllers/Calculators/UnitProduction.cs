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
                  Button calculateNaqToSpend, ToolTip hints, ComboBox races)
    {
        UIData.UpdateLabel(currentUp, Constants.GUI.Labels.CurrentUp);
        UIData.UpdateLabel(desiredUp, Constants.GUI.Labels.DesiredUp);
        UIData.UpdateLabel(resToSpendText, Constants.GUI.Labels.ResourcesToSpend);
        UIData.UpdateLabel(upResult, string.Empty);

        UIData.UpdateTextBox(fromInput, string.Empty);
        UIData.UpdateTextBox(toInput, string.Empty);
        UIData.UpdateTextBox(resToSpend, string.Empty);

        _races = races;
        _races.SelectedIndexChanged += (s, e) => UpdateSelectedRace(resToSpendText);

        calculateDesiredUp.Click += (s, e) =>
        {
            (string results, string multiplier, string formattedLeftInput, string formattedRightInput)
                = Calc.CalculateDesiredUp(fromInput.Text, toInput.Text);

            if (results != upResult.Text)
            {
                string hint = Hints.DesiredUp(formattedLeftInput, formattedRightInput, results, multiplier, _selectedRace.Currency.Name);
                UIData.UpdateLabel(upResult, hint);
                hints.SetToolTip(upResult, hint);
            }
        };

        calculateNaqToSpend.Click += (s, e) =>
        {
            (string results, string multiplier, string formattedLeftInput, string formattedRightInput)
                = Calc.CalulatePossibleUpUpgrade(fromInput.Text, resToSpend.Text);

            if (results != upResult.Text)
            {
                string hint = Hints.ResourcesToSpend(formattedLeftInput, formattedRightInput, results, multiplier, _selectedRace.Currency.Name);
                UIData.UpdateLabel(upResult, hint);
                hints.SetToolTip(upResult, hint);
            }
        };

        upResult.Click += (s, e) => UIData.CopyToClipboard(upResult.Text);
        currentUp.Click += (s, e) => UIData.CopyToClipboard(currentUp.Text);

        UpdateSelectedRace(resToSpendText);
    }
    private void UpdateSelectedRace(Label label)
    {
        if (_races.SelectedItem != null && _selectedRace != null)
        {
            _selectedRace = (Race)_races.SelectedItem;
            UIData.UpdateLabel(label, $"{_selectedRace.Currency.Name} {Constants.GUI.Labels.ResourcesToSpend}");
        }
    }
}
