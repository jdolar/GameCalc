using Calculator;
using Data;
using Data.Commands;
using Data.Enums.Unit;
using Data.Models;
using UI.Windows.Helpers;

namespace UI.Windows.Controllers.Calculators;
internal sealed class TheCalc
{
    private readonly Display _form;
    public TheCalc(Display form, bool? imageRecognition = null)
    {
        _form = form;
        UIData.SetItemTypesComboBox(_form._itemTypes);
        UIData.SetItemPurposeComboBox(_form._itemPurposes);

        _form._ableToBuyValue.Click += (s, e) => UIData.CopyToClipboard(_form._ableToBuyValue.Text);
        _form._costToReassignValue.Click += (s, e) => UIData.CopyToClipboard(_form._costToReassignValue.Text);
        _form._costToBuyValue.Click += (s, e) => UIData.CopyToClipboard(_form._costToBuyValue.Text);

        _form._itemTypes.SelectedIndexChanged += (s, e) => UpdateSelectedItem();
        _form._itemPurposes.SelectedIndexChanged += (s, e) => UpdateSelectedItem();
        _form._selectedItems.SelectedIndexChanged += (s, e) => DisplayResults();

        _form._userInput.TextChanged += (s, e) =>
        {
            if (s is not TextBox txtBox)
                return;

            UIData.CleanTextBoxText(
                    txtBox,
                    [Clean.Text],
                    DisplayResults);
        };
        _form._userInput.KeyDown += (s, e) =>
        {
            if (imageRecognition.HasValue && imageRecognition == false) return;

            if (s is not TextBox txtBox)
                return;

            if (e.Control && e.KeyCode == Keys.V)
            {
                if (Clipboard.ContainsImage())
                {
                    UIData.CleanTextBoxImage(
                    txtBox,
                    [Clean.Image]);

                    e.Handled = true;
                }
            }
        };

        _form._ableToBuyValue.Text = string.Empty;
        _form._costToBuyValue.Text = string.Empty;
        _form._costToReassignValue.Text = string.Empty;

        _form._userInput.Text = string.Empty;
        _form._costToBuyValue.Text = string.Empty;
        _form._ableToBuyValue.Text = string.Empty;
        _form._costToReassignValue.Text = string.Empty;
    }

    private void DisplayResults()
    {
        Unit? unit = _form._selectedItems.SelectedItem != null ? _form._selectedItems.SelectedItem as Unit : null;
        if (unit == null) return;

        (string costToBuy, string ableToBuy, string costToReassign, string input)
        = Calc.CalculateAbleToBuyAndCostToBuy(_form._userInput.Text, unit.CostPerUnit, unit.CostPerUnitReassign, true);

        _form._costToBuyValue.Text = string.IsNullOrEmpty(costToBuy) ? string.Empty : Hints.GetCostToBuyHint(input, _form._selectedRace.Currency.Name, costToBuy, "buy", unit);
        _form._ableToBuyValue.Text = string.IsNullOrEmpty(ableToBuy) ? string.Empty : Hints.GetAbleToBuyHint(input, _form._selectedRace.Currency.Name, ableToBuy, unit); ;
        _form._costToReassignValue.Text = string.IsNullOrEmpty(costToReassign) ? string.Empty : Hints.GetCostToBuyHint(input, _form._selectedRace.Currency.Name, costToReassign, "sell", unit); ;

        _form._hint.SetToolTip(_form._selectedItems, Hints.GetUnit(unit));
        _form._hint.SetToolTip(_form._itemTypes, Hints.GetUnits([.. _form._selectedRace.Units.Where(x => x.Type == (Data.Enums.Unit.Type)_form._itemTypes.SelectedItem!)]));
        _form._hint.SetToolTip(_form._itemPurposes, Hints.GetUnits([.. _form._selectedRace.Units.Where(x => (x.Type == (Data.Enums.Unit.Type)_form._itemTypes.SelectedItem!) && (x.Purpose == (Data.Enums.Unit.Purpose)_form._itemPurposes.SelectedItem!))]));
    }

    private void UpdateSelectedItem()
    {
        if (_form._itemTypes.SelectedItem == null || _form._itemPurposes.SelectedItem == null || _form._selectedRace == null)
            return;

        UIData.UpdateTextBox(_form._selectedItems, _form._selectedRace.Units, (Data.Enums.Unit.Type)_form._itemTypes.SelectedItem, (Purpose)_form._itemPurposes.SelectedItem);

        DisplayResults();
    }
}
