using Data.Models;
using UI.Windows.Controllers;
using UI.Windows.Controllers.Calculators;
using UI.Windows.Properties;
namespace UI.Windows;

public partial class Display : Form
{
    public Game _activeGame = new();
    public Display()
    {
        InitializeComponent();
        SetTitle();

        _ = new Frame(_races, _games, _amountToCopy, _valueToCopy, _user, _copyToClipBoardPersonalLog, _copyToClipBoard, _toolTips, ref _activeGame);

        _ = new GetGot(_getGotItemTypes, _getGotItemPurposes, _getGotSelectedItems, _races, _getGotUserInput, _getGotAbleToBuy,
                       _getGotCostToReassign, _getGotCostToBuy, _toolTips, _tabPageGetGot);

        _ = new Simple(_simpleResult, _simpleLeftInput, _simpleRightInput, _simpleHistory, _simpleSum,
                       _simpleMultiply, _simpleDivide, _simpleDeduct, _simpleClear, _simpleClearHistory, _tabPageSimple);

        _ = new UnitProduction(_unitProductionCurrentUp, _unitProductionDesiredUp, _unitProductionResToSpend, _unitProductionResult,
                               _unitProductionFromInput, _unitProductionToInput, _unitProductionResourcesToSpendInput,
                               _unitProductionCalculateDesiredUp, _unitProductionCalculateNaqToSpend, _toolTips, _races, _tabPageUp);

    }

    private void SetTitle() => this.Text = $"{AppInfo.Name} {AppInfo.Version} [{AppInfo.InfoVersion}]";
}
