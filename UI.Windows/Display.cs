using Calculator;
using Data;
using Data.Commands;
using Data.Enums.Unit;
using Data.Models;
using UI.Windows.Helpers;
namespace UI.Windows;

public partial class Display : Form
{
    readonly bool _imageRecognitionEnabled = false;
    readonly List<Game> _enabledGames = UIData.GetGames();

    Race _selectedRace = new();
    Game _selectedGame = new();

    public Display()
    {
        InitializeComponent();

        UIData.SetGamesComboBox(_games, _enabledGames);
        UIData.SetRacesComboBox(_races, _selectedGame.Races);
        UIData.SetItemTypesComboBox(_itemTypes);
        UIData.SetItemPurposeComboBox(_itemPurposes);

        SetTextBoxes();
        WireTextBoxes();
        WireComboBoxes();
        WireClipboard();
        WireSimpleCalc();
        WireUpCalc();
        SetLabels();

        UpdateSelectedGame();

        _hint.ConfigureTooltip();
    }

    #region Display
    private void DisplayResults()
    {
        Unit? unit = _selectedItems.SelectedItem != null ? _selectedItems.SelectedItem as Unit : null;
        if (unit == null) return;

        (string costToBuy, string ableToBuy, string costToReassign, string input)
        = Calc.CalculateAbleToBuyAndCostToBuy(_userInput.Text, unit.CostPerUnit, unit.CostPerUnitReassign, true);

        _costToBuyValue.Text = string.IsNullOrEmpty(costToBuy) ? string.Empty : Hints.GetCostToBuyHint(input, _selectedRace.Currency.Name, costToBuy, "buy", unit);
        _ableToBuyValue.Text = string.IsNullOrEmpty(ableToBuy) ? string.Empty : Hints.GetAbleToBuyHint(input, _selectedRace.Currency.Name, ableToBuy, unit); ;
        _costToReassignValue.Text = string.IsNullOrEmpty(costToReassign) ? string.Empty : Hints.GetCostToBuyHint(input, _selectedRace.Currency.Name, costToReassign, "sell", unit); ;

        _hint.SetToolTip(_selectedItems, Hints.GetUnit(unit));
        _hint.SetToolTip(_itemTypes, Hints.GetUnits([.. _selectedRace.Units.Where(x => x.Type == (Data.Enums.Unit.Type)_itemTypes.SelectedItem!)]));
        _hint.SetToolTip(_itemPurposes, Hints.GetUnits([.. _selectedRace.Units.Where(x => (x.Type == (Data.Enums.Unit.Type)_itemTypes.SelectedItem!) && (x.Purpose == (Data.Enums.Unit.Purpose)_itemPurposes.SelectedItem!))]));
    }
    #endregion

    #region Update
    private void UpdateSelectedItem()
    {
        if (_itemTypes.SelectedItem == null || _itemPurposes.SelectedItem == null || _selectedRace == null)
            return;

        UIData.UpdateTextBox(_selectedItems, _selectedRace.Units, (Data.Enums.Unit.Type)_itemTypes.SelectedItem, (Purpose)_itemPurposes.SelectedItem);

        DisplayResults();
    }
    private void UpdateSelectedRace()
    {
        if (_races.SelectedItem != null)
        {
            _selectedRace = (Race)_races.SelectedItem;
            _hint.SetToolTip(_races, Hints.GetRace(_selectedRace));

            UIData.UpdateLabel(_resToSpend, string.Format("{0} {1}", _selectedRace.Currency.Name, Constants.GUI.Labels.ResourcesToSpend));
            UpdateSelectedItem();
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
    #endregion

    #region Event Wiring
    private void WireSimpleCalc()
    {
        _sum.Click += (s, e) =>
        {
            string result = Calc.Sum(_calcInputLeft.Text, _calcInputRight.Text, true);
            if (!string.IsNullOrEmpty(result))
            {
                _simpleCalcResult.Text = result;
                _simpleCalcResultHistory.Items.Add($"{Clean.Text(_calcInputLeft.Text)}+{Clean.Text(_calcInputRight.Text)}={result}");
            }
        };
        _deduct.Click += (s, e) =>
        {
            string result = Calc.Deduct(_calcInputLeft.Text, _calcInputRight.Text);
            if (!string.IsNullOrEmpty(result))
            {
                _simpleCalcResult.Text = result;
                _simpleCalcResultHistory.Items.Add($"{Clean.Text(_calcInputLeft.Text)}-{Clean.Text(_calcInputRight.Text)}={result}");
            }
        };
        _divide.Click += (s, e) =>
        {
            string result = Calc.Divide(_calcInputLeft.Text, _calcInputRight.Text);
            if (!string.IsNullOrEmpty(result))
            {
                _simpleCalcResult.Text = result;
                _simpleCalcResultHistory.Items.Add($"{Clean.Text(_calcInputLeft.Text)}/{Clean.Text(_calcInputRight.Text)}={result}");
            }
        };
        _multiply.Click += (s, e) =>
        {
            string result = Calc.Multiply(_calcInputLeft.Text, _calcInputRight.Text);
            if (!string.IsNullOrEmpty(result))
            {
                _simpleCalcResult.Text = result;
                _simpleCalcResultHistory.Items.Add($"{Clean.Text(_calcInputLeft.Text)}x{Clean.Text(_calcInputRight.Text)}={result}");
            }
        };

        _clearSimpleCalc.Click += (s, e) =>
        {
            _simpleCalcResult.Text = string.Empty; 
            _calcInputLeft.Text = string.Empty;
            _calcInputRight.Text = string.Empty;
        };
        _clearSimpleCalcHistory.Click += (s, e) => _simpleCalcResultHistory.Items.Clear();
    }
    private void WireUpCalc()
    {
        _calculateDesiredUp.Click += (s, e) =>
        {
            (string results, string multiplier, string formatedLeftInput, string formattedRightInput)
                = Calc.CalculateDesiredUp(_fromInput.Text, _toInput.Text);

            if (results != _upCalcResult.Text)
            {
                string hint = Hints.UpCalcDesiredUpResults(formatedLeftInput, formattedRightInput, results, multiplier, _selectedRace.Currency.Name);

                _upCalcResult.Text = hint;
                _hint.SetToolTip(_upCalcResult, hint);
            }
        };
        _calculateNaqToSpend.Click += (s, e) =>
        {
            (string results, string multiplier, string formatedLeftInput, string formattedRightInput)
                = Calc.CalulatePossibleUpUpgrade(_fromInput.Text, _resourcesToSpendInput.Text);

            if (results != _upCalcResult.Text)
            {
                string hint = Hints.UpCalcResurcesToSpendResults(formatedLeftInput, formattedRightInput, results, multiplier, _selectedRace.Currency.Name);

                _upCalcResult.Text = hint;
                _hint.SetToolTip(_upCalcResult, hint);
            }
        };

        _upCalcResult.Click += (s, e) => UIData.CopyToClipboard(_upCalcResult.Text);
    }
    private void WireClipboard()
    {
        //The Calc
        _ableToBuyValue.Click += (s, e) => UIData.CopyToClipboard(_ableToBuyValue.Text);
        _costToReassignValue.Click += (s, e) => UIData.CopyToClipboard(_costToReassignValue.Text);
        _costToBuyValue.Click += (s, e) => UIData.CopyToClipboard(_costToBuyValue.Text);

        //Up Calc
        _currentUp.Click += (s, e) => UIData.CopyToClipboard(_currentUp.Text);

        //Simple Calc
        _simpleCalcResult.Click += (s, e) => UIData.CopyToClipboard(_simpleCalcResult.Text);
    }
    private void WireComboBoxes()
    {
        _games.SelectedIndexChanged += (s, e) => UpdateSelectedGame();
        _races.SelectedIndexChanged += (s, e) => UpdateSelectedRace();
        _itemTypes.SelectedIndexChanged += (s, e) => UpdateSelectedItem();
        _itemPurposes.SelectedIndexChanged += (s, e) => UpdateSelectedItem();
        _selectedItems.SelectedIndexChanged += (s, e) => DisplayResults();
    }
    private void WireTextBoxes()
    {
        _userInput.TextChanged += (s, e) =>
        {
            if (s is not System.Windows.Forms.TextBox txtBox)
                return;

            UIData.CleanTextBoxText(
                    txtBox,
                    [Clean.Text],
                    DisplayResults);
        };
        _userInput.KeyDown += (s, e) =>
        {
            if (!_imageRecognitionEnabled) return;

            if (s is not System.Windows.Forms.TextBox txtBox)
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
    }
    private void SetLabels()
    {
        // Form
        Text = $"{AppInfo.Name} v{AppInfo.Version}";

        // Tabs
        _tabPageTheCalc.Text = Constants.GUI.Labels.TheCalc;
        _tabPageUpCalc.Text = Constants.GUI.Labels.UpCalc;
        _tabPageSimpleCalc.Text = Constants.GUI.Labels.SimpleCalc;

        //The Calc
        //  _ableToBuy.Text = Constants.GUI.Labels.AbleTobuy;
        _ableToBuyValue.Text = string.Empty;
        //_costToBuy.Text = Constants.GUI.Labels.CostToBuy;
        _costToBuyValue.Text = string.Empty;
        //_costToReassign.Text = Constants.GUI.Labels.CostToReassign;
        _costToReassignValue.Text = string.Empty;

        //UP Calc
        _currentUp.Text = Constants.GUI.Labels.CurrentUp;
        _desiredUp.Text = Constants.GUI.Labels.DesiredUp;
        _resToSpend.Text = Constants.GUI.Labels.ResourcesToSpend;
        _upCalcResult.Text = string.Empty;

        //Simple Calc
        _simpleCalcResult.Text = string.Empty;
    }
    private void SetTextBoxes()
    {
        //The Calc
        _userInput.Text = string.Empty;
        _costToBuyValue.Text = string.Empty;
        _ableToBuyValue.Text = string.Empty;
        _costToReassignValue.Text = string.Empty;

        //UP Calc    
        _fromInput.Text = string.Empty;
        _toInput.Text = string.Empty;
        _resourcesToSpendInput.Text = string.Empty;

        //Simple Calc
        _calcInputLeft.Text = string.Empty;
        _calcInputRight.Text = string.Empty;
    }
    #endregion
}
