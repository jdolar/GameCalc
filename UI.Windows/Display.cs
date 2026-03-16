using UI.Windows.Controllers;
using UI.Windows.Controllers.Calculators;
namespace UI.Windows;
public partial class Display : Form
{
    public Display()
    {
        InitializeComponent();

        _ = new Frame(_races, _games, _toolTips);
        
        _ = new GetGot(_getGotItemTypes, _getGotItemPurposes, _getGotSelectedItems, _races, _getGotUserInput, _getGotAbleToBuy,
                       _getGotCostToReassign, _getGotCostToBuy, _toolTips);
        
        _ = new Simple(_simpleResult, _simpleLeftInput, _simpleRightInput, _simpleHistory, _simpleSum,
                       _simpleMultiply, _simpleDivide, _simpleDeduct, _simpleClear, _simpleClearHistory);
        
        _ = new UnitProduction(_unitProductionCurrentUp, _unitProductionDesiredUp, _unitProductionResToSpend, _unitProductionResult, 
                               _unitProductionFromInput, _unitProductionToInput, _unitProductionResourcesToSpendInput, 
                               _unitProductionCalculateDesiredUp, _unitProductionCalculateNaqToSpend, _toolTips, _races);
    }
}
