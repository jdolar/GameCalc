using Calculator;
using Data;
using Data.Commands;
using Data.Enums.Unit;
using Data.Models;
using UI.Windows.Helpers;
namespace UI.Windows.Controllers.Calculators;
internal sealed class GetGot
{
    private readonly ComboBox _itemTypes, _itemPurposes, _selectedItems, _races;
    private readonly TextBox _userInput;
    private readonly Label _ableToBuy, _costToBuy, _costToReassign;
    private readonly ToolTip _hint;
    private Race _selectedRace = new();

    public GetGot(ComboBox itemTypes, ComboBox itemPurposes, ComboBox selectedItems, ComboBox races, TextBox userInput,
                   Label ableToBuy, Label costToReassign, Label costToBuy, ToolTip hint, bool? imageRecognition = null)
    {
        _itemTypes = itemTypes;
        _itemPurposes = itemPurposes;
        _selectedItems = selectedItems;
        _userInput = userInput;
        _ableToBuy = ableToBuy;
        _costToBuy = costToBuy;
        _costToReassign = costToReassign;
        _hint = hint;
        _races = races;

        UIData.SetItemTypesComboBox(_itemTypes);
        UIData.SetItemPurposeComboBox(_itemPurposes);

        _ableToBuy.Click += (s, e) => UIData.CopyToClipboard(_ableToBuy.Text);
        _costToReassign.Click += (s, e) => UIData.CopyToClipboard(_costToReassign.Text);
        _costToBuy.Click += (s, e) => UIData.CopyToClipboard(_costToBuy.Text);

        _itemTypes.SelectedIndexChanged += (s, e) => UpdateSelectedItem();
        _itemPurposes.SelectedIndexChanged += (s, e) => UpdateSelectedItem();
        _selectedItems.SelectedIndexChanged += (s, e) => DisplayResults();

        _races.SelectedIndexChanged += (s, e) => UpdateSelectedRace();

        _userInput.TextChanged += (s, e) =>
        {
            if (s is not TextBox txtBox)
                return;

            UIData.CleanTextBoxText(txtBox, [Clean.Text], DisplayResults);
        };

        _userInput.KeyDown += (s, e) =>
        {
            if (imageRecognition.HasValue && imageRecognition == false) return;

            if (s is not TextBox txtBox)
                return;

            if (e.Control && e.KeyCode == Keys.V)
            {
                if (Clipboard.ContainsImage())
                {
                    UIData.CleanTextBoxImage(txtBox, [Clean.Image]);
                    e.Handled = true;
                }
            }
        };

        UIData.UpdateLabel(_ableToBuy, string.Empty);
        UIData.UpdateLabel(_costToBuy, string.Empty);
        UIData.UpdateLabel(_costToReassign, string.Empty);

        UIData.UpdateTextBox(_userInput, string.Empty);

        UpdateSelectedRace();
        UpdateSelectedItem();
    }

    private void DisplayResults()
    {
        Unit? unit = _selectedItems.SelectedItem != null ? _selectedItems.SelectedItem as Unit : null;
        if (unit == null) return;

        (string costToBuy, string ableToBuy, string costToReassign, string input)
        = Calc.CalculateAbleToBuyAndCostToBuy(_userInput.Text, unit.CostPerUnit, unit.CostPerUnitReassign, true);

        string costToBuyLabel = string.IsNullOrEmpty(costToBuy) || costToBuy == "0" ? string.Empty : Hints.CostToBuyOrSell(input, _selectedRace.Currency.Name, costToBuy, "buy", unit);
        UIData.UpdateLabel(_costToBuy, costToBuyLabel);

        string ableToBuyLabel = string.IsNullOrEmpty(ableToBuy) || (ableToBuy == "0") ? string.Empty : Hints.AbleToBuy(input, _selectedRace.Currency.Name, ableToBuy, unit);
        UIData.UpdateLabel(_ableToBuy, ableToBuyLabel);

        string costToReassignLabel = string.IsNullOrEmpty(costToReassign) || costToReassign == "0" ? string.Empty : Hints.CostToBuyOrSell(input, _selectedRace.Currency.Name, costToReassign, "reassign", unit); ;
        UIData.UpdateLabel(_costToReassign, costToReassignLabel);

        _hint.SetToolTip(_selectedItems, Hints.Unit(unit));
        _hint.SetToolTip(_itemTypes, Hints.Units([.. _selectedRace.Units.Where(x => x.Type == (Data.Enums.Unit.Type)_itemTypes.SelectedItem!)]));
        _hint.SetToolTip(_itemPurposes, Hints.Units([.. _selectedRace.Units.Where(x => (x.Type == (Data.Enums.Unit.Type)_itemTypes.SelectedItem!) && (x.Purpose == (Data.Enums.Unit.Purpose)_itemPurposes.SelectedItem!))]));
    }

    private void UpdateSelectedItem()
    {
        if (_itemTypes.SelectedItem == null || _itemPurposes.SelectedItem == null || _selectedRace == null)
            return;

        UIData.UpdateComboBox(_selectedItems, _selectedRace.Units, (Data.Enums.Unit.Type)_itemTypes.SelectedItem, (Purpose)_itemPurposes.SelectedItem);
        DisplayResults();
    }
    private void UpdateSelectedRace()
    {
        if (_races.SelectedItem != null && _selectedRace != null)
        {
            _selectedRace = (Race)_races.SelectedItem;
            UpdateSelectedItem();
        }
    }
}
