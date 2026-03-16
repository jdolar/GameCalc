using Data.Models;
using UI.Windows.Controllers;
using UI.Windows.Controllers.Calculators;
namespace UI.Windows;

public partial class Display : Form
{
    public static Race SelectedRace { get; private set; } = null!;
    public Display()
    {
        InitializeComponent();

        Frame _frame = new(_races, _games, _toolTips, _unitProductionResToSpend);
        SelectedRace = _frame.SelectedRace;

        GetGot _the = new(_getGotItemTypes, _getGotItemPurposes, _getGotSelectedItems, _races, _getGotUserInput, _getGotAbleToBuy,
                       _getGotCostToReassign, _getGotCostToBuy, _toolTips);

        Simple _simple = new(_simpleResult, _simpleLeftInput, _simpleRightInput, _simpleHistory, _simpleSum,
                          _simpleMultiply, _simpleDivide, _simpleDeduct, _simpleClear, _simpleClearHistory);

        UnitProduction _up = new (_unitProductionCurrentUp, _unitProductionDesiredUp, _unitProductionResToSpend, _unitProductionResult, _unitProductionFromInput, _unitProductionToInput,
                      _unitProductionResourcesToSpendInput, _unitProductionCalculateDesiredUp, _unitProductionCalculateNaqToSpend, _toolTips, _races);

    }
}
