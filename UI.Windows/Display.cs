using Data;
using Data.Models;
using System.Text;
using UI.Windows.Controllers;
using UI.Windows.Controllers.Calculators;
namespace UI.Windows;

public partial class Display : Form
{
    public Game _activeGame = new();
    public Display()
    {
        InitializeComponent();

        _ = new Frame(_races, _games, _amountToCopy, _valueToCopy, _user, _toolTips, _copyToClipBoard, ref _activeGame);

        _ = new GetGot(_getGotItemTypes, _getGotItemPurposes, _getGotSelectedItems, _races, _getGotUserInput, _getGotAbleToBuy,
                       _getGotCostToReassign, _getGotCostToBuy, _toolTips, _tabPageGetGot);

        _ = new Simple(_simpleResult, _simpleLeftInput, _simpleRightInput, _simpleHistory, _simpleSum,
                       _simpleMultiply, _simpleDivide, _simpleDeduct, _simpleClear, _simpleClearHistory, _tabPageSimple);

        _ = new UnitProduction(_unitProductionCurrentUp, _unitProductionDesiredUp, _unitProductionResToSpend, _unitProductionResult,
                               _unitProductionFromInput, _unitProductionToInput, _unitProductionResourcesToSpendInput,
                               _unitProductionCalculateDesiredUp, _unitProductionCalculateNaqToSpend, _toolTips, _races, _tabPageUp);

    }

    private void _generatePersonalLog_Click(object sender, EventArgs e)
    {
        var personalLog = DataBuilder.GetLog();

        StringBuilder sb = new();
        int entryCount = personalLog.Entries.Count;
        for(int i=0; i< entryCount; i++)
        {
            if (personalLog.Entries[i].Type == Data.Enums.PersonalLog.EntryType.Player)
                sb.Append(Constants.PersonalLog.PlayerStats);
            else if (personalLog.Entries[i].Type == Data.Enums.PersonalLog.EntryType.Alliance)
                sb.Append(Constants.PersonalLog.AllianceStats);

            sb.Append(personalLog.Entries[i].Id);
            sb.Append('>');
            
            if (personalLog.Entries[i].Type == Data.Enums.PersonalLog.EntryType.Alliance)
                sb.Append(" [ ");
            
            sb.Append(personalLog.Entries[i].Name);
            
            if (personalLog.Entries[i].Type == Data.Enums.PersonalLog.EntryType.Alliance)
                sb.Append(" ] ");
            
            sb.Append(Constants.PersonalLog.LogEnd);

            if(i != entryCount - 1)
                sb.AppendLine();
        }
        string a = sb.ToString();   
    }
}
