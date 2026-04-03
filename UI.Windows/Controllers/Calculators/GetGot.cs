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
    private string _costToBuyCache = string.Empty;
    private string _ableToBuyCache = string.Empty;
    private string _costToReassignCache= string.Empty;
    private Race _selectedRace = new();

    public GetGot(ComboBox itemTypes, ComboBox itemPurposes, ComboBox selectedItems, ComboBox races, TextBox userInput,
                   Label ableToBuy, Label costToReassign, Label costToBuy, ToolTip hint, TabPage tabPage, bool? imageRecognition = null)
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

        UIController.UpdateLayoutTabPage(tabPage, Constants.GUI.Labels.GetGot);

        UIController.SetItemTypesComboBox(_itemTypes);
        UIController.SetItemPurposeComboBox(_itemPurposes);

        _ableToBuy.Click += (s, e) => UIController.CopyToClipboard(_ableToBuyCache);
        _costToReassign.Click += (s, e) => UIController.CopyToClipboard(_costToReassignCache);
        _costToBuy.Click += (s, e) => UIController.CopyToClipboard(_costToBuyCache);

        _itemTypes.SelectedIndexChanged += (s, e) => UpdateSelectedItem();
        _itemPurposes.SelectedIndexChanged += (s, e) => UpdateSelectedItem();
        _selectedItems.SelectedIndexChanged += (s, e) => DisplayResults();
        _races.SelectedIndexChanged += (s, e) => UpdateSelectedRace();

        _userInput.TextChanged += (s, e) =>
        {
            if (s is not TextBox txtBox)
                return;

            UIController.CleanTextBoxText(txtBox, [Clean.Text], DisplayResults);
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
                    UIController.CleanTextBoxImage(txtBox, [Clean.Image]);
                    e.Handled = true;
                }
            }
        };

        UIController.UpdateLabel(_ableToBuy, string.Empty);
        UIController.UpdateLabel(_costToBuy, string.Empty);
        UIController.UpdateLabel(_costToReassign, string.Empty);
        UIController.UpdateTextBox(_userInput, string.Empty);

        UpdateSelectedRace();
    }

    private void DisplayResults()
    {
        Unit? unit = _selectedItems.SelectedItem != null ? _selectedItems.SelectedItem as Unit : null;
        if (unit == null) return;

        (string costToBuy, string ableToBuy, string costToReassign, string input)
        = Operation.CalculateAbleToBuyAndCostToBuy(_userInput.Text, unit.CostPerUnit, unit.CostPerUnitReassign, true);

        _ableToBuyCache = ableToBuy;
        _costToBuyCache = costToBuy;
        _costToReassignCache = costToReassign;

        string costToBuyLabel = string.IsNullOrEmpty(costToBuy) || costToBuy == "0" ? string.Empty : Data.Hints.CostToBuyOrSell(input, _selectedRace.Currency.Name, costToBuy, "buy", unit);
        UIController.UpdateLabel(_costToBuy, costToBuyLabel);

        string ableToBuyLabel = string.IsNullOrEmpty(ableToBuy) || (ableToBuy == "0") ? string.Empty : Data.Hints.AbleToBuy(input, _selectedRace.Currency.Name, ableToBuy, unit);
        UIController.UpdateLabel(_ableToBuy, ableToBuyLabel);

        string costToReassignLabel = string.IsNullOrEmpty(costToReassign) || costToReassign == "0" ? string.Empty : Data.Hints.CostToBuyOrSell(input, _selectedRace.Currency.Name, costToReassign, "reassign", unit); ;
        UIController.UpdateLabel(_costToReassign, costToReassignLabel);

        _hint.SetToolTip(_selectedItems, Hints.Unit(unit));
        _hint.SetToolTip(_itemTypes, Hints.Units([.. _selectedRace.Units.Where(x => x.Type == (Data.Enums.Unit.Type)_itemTypes.SelectedItem!)]));
        _hint.SetToolTip(_itemPurposes, Hints.Units([.. _selectedRace.Units.Where(x => (x.Type == (Data.Enums.Unit.Type)_itemTypes.SelectedItem!) && (x.Purpose == (Data.Enums.Unit.Purpose)_itemPurposes.SelectedItem!))]));
    }

    private void UpdateSelectedItem()
    {
        if (_itemTypes.SelectedItem == null || _itemPurposes.SelectedItem == null || _selectedRace == null)
            return;

        bool wasEmptied = UIController.UpdateComboBox(_selectedItems, _selectedRace.Units, (Data.Enums.Unit.Type)_itemTypes.SelectedItem, (Purpose)_itemPurposes.SelectedItem);
        if (wasEmptied)     
            _hint.SetToolTip(_selectedItems, string.Empty);
        else
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
