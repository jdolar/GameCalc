using Data.Enums;

namespace UI.Windows;
partial class Display
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        _races = new ComboBox();
        _getGotItemTypes = new ComboBox();
        _getGotUserInput = new TextBox();
        _getGotSelectedItems = new ComboBox();
        _commandsLayout = new TableLayoutPanel();
        _getGotAbleToBuy = new Label();
        _getGotCostToBuy = new Label();
        _getGotCostToReassign = new Label();
        _simpleSum = new Button();
        _simpleDeduct = new Button();
        _simpleMultiply = new Button();
        _simpleDivide = new Button();
        _simpleLeftInput = new TextBox();
        _simpleRightInput = new TextBox();
        _simpleResult = new Label();
        _toolTips = new ToolTip(components);
        _games = new ComboBox();
        _upperLayout = new TableLayoutPanel();
        _getGotItemPurposes = new ComboBox();
        _user = new Label();
        _game = new Label();
        _race = new Label();
        _unitProductionResult = new Label();
        _unitProductionToInput = new TextBox();
        _unitProductionFromInput = new TextBox();
        _unitProductionCalculateDesiredUp = new Button();
        _unitProductionLayout = new TableLayoutPanel();
        _unitProductionCalculateNaqToSpend = new Button();
        _unitProductionResourcesToSpendInput = new TextBox();
        _unitProductionCurrentUp = new Label();
        _unitProductionDesiredUp = new Label();
        _unitProductionResToSpend = new Label();
        _tab = new TabControl();
        _tabPageGetGot = new TabPage();
        _tabPageUp = new TabPage();
        _tabPageSimple = new TabPage();
        _simpleClearHistory = new Button();
        _simpleClear = new Button();
        _simpleHistory = new ListBox();
        _raceLayout = new TableLayoutPanel();
        _bottomLayout = new TableLayoutPanel();
        _amountToCopy = new ComboBox();
        _valueToCopy = new ComboBox();
        _generatePersonalLog = new Button();
        _copyToClipBoard = new Button();
        _commandsLayout.SuspendLayout();
        _upperLayout.SuspendLayout();
        _unitProductionLayout.SuspendLayout();
        _tab.SuspendLayout();
        _tabPageGetGot.SuspendLayout();
        _tabPageUp.SuspendLayout();
        _tabPageSimple.SuspendLayout();
        _raceLayout.SuspendLayout();
        _bottomLayout.SuspendLayout();
        SuspendLayout();
        // 
        // _races
        // 
        _races.DropDownStyle = ComboBoxStyle.DropDownList;
        _races.Location = new Point(374, 8);
        _races.Name = "_races";
        _races.Size = new Size(149, 23);
        _races.TabIndex = 0;
        // 
        // _getGotItemTypes
        // 
        _getGotItemTypes.DropDownStyle = ComboBoxStyle.DropDownList;
        _getGotItemTypes.Location = new Point(272, 45);
        _getGotItemTypes.Margin = new Padding(20, 3, 0, 0);
        _getGotItemTypes.Name = "_getGotItemTypes";
        _getGotItemTypes.Size = new Size(220, 23);
        _getGotItemTypes.TabIndex = 0;
        // 
        // _getGotUserInput
        // 
        _getGotUserInput.Location = new Point(20, 88);
        _getGotUserInput.Name = "_getGotUserInput";
        _getGotUserInput.Size = new Size(484, 23);
        _getGotUserInput.TabIndex = 1;
        // 
        // _getGotSelectedItems
        // 
        _getGotSelectedItems.DropDownStyle = ComboBoxStyle.DropDownList;
        _getGotSelectedItems.Location = new Point(8, 45);
        _getGotSelectedItems.Name = "_getGotSelectedItems";
        _getGotSelectedItems.Size = new Size(220, 23);
        _getGotSelectedItems.TabIndex = 2;
        // 
        // _commandsLayout
        // 
        _commandsLayout.ColumnCount = 1;
        _commandsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _commandsLayout.Controls.Add(_getGotAbleToBuy, 0, 0);
        _commandsLayout.Controls.Add(_getGotCostToBuy, 0, 1);
        _commandsLayout.Controls.Add(_getGotCostToReassign, 0, 2);
        _commandsLayout.Location = new Point(20, 117);
        _commandsLayout.Name = "_commandsLayout";
        _commandsLayout.Padding = new Padding(5);
        _commandsLayout.RowCount = 3;
        _commandsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        _commandsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        _commandsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        _commandsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        _commandsLayout.Size = new Size(484, 104);
        _commandsLayout.TabIndex = 3;
        // 
        // _getGotAbleToBuy
        // 
        _getGotAbleToBuy.AutoSize = true;
        _getGotAbleToBuy.Location = new Point(8, 5);
        _getGotAbleToBuy.Name = "_getGotAbleToBuy";
        _getGotAbleToBuy.Size = new Size(91, 15);
        _getGotAbleToBuy.TabIndex = 10;
        _getGotAbleToBuy.Text = "AbleToBuyValue";
        // 
        // _getGotCostToBuy
        // 
        _getGotCostToBuy.AutoSize = true;
        _getGotCostToBuy.Location = new Point(8, 36);
        _getGotCostToBuy.Name = "_getGotCostToBuy";
        _getGotCostToBuy.Size = new Size(91, 15);
        _getGotCostToBuy.TabIndex = 13;
        _getGotCostToBuy.Text = "CostToBuyValue";
        // 
        // _getGotCostToReassign
        // 
        _getGotCostToReassign.AutoSize = true;
        _getGotCostToReassign.Location = new Point(8, 67);
        _getGotCostToReassign.Name = "_getGotCostToReassign";
        _getGotCostToReassign.Size = new Size(117, 15);
        _getGotCostToReassign.TabIndex = 14;
        _getGotCostToReassign.Text = "CostToReassignValue";
        // 
        // _simpleSum
        // 
        _simpleSum.Location = new Point(107, 53);
        _simpleSum.Name = "_simpleSum";
        _simpleSum.Size = new Size(41, 23);
        _simpleSum.TabIndex = 4;
        _simpleSum.Text = "+";
        _simpleSum.UseVisualStyleBackColor = true;
        // 
        // _simpleDeduct
        // 
        _simpleDeduct.Location = new Point(154, 53);
        _simpleDeduct.Name = "_simpleDeduct";
        _simpleDeduct.Size = new Size(41, 23);
        _simpleDeduct.TabIndex = 5;
        _simpleDeduct.Text = "-";
        _simpleDeduct.UseVisualStyleBackColor = true;
        // 
        // _simpleMultiply
        // 
        _simpleMultiply.Location = new Point(60, 53);
        _simpleMultiply.Name = "_simpleMultiply";
        _simpleMultiply.Size = new Size(41, 23);
        _simpleMultiply.TabIndex = 6;
        _simpleMultiply.Text = "x";
        _simpleMultiply.UseVisualStyleBackColor = true;
        // 
        // _simpleDivide
        // 
        _simpleDivide.Location = new Point(13, 53);
        _simpleDivide.Name = "_simpleDivide";
        _simpleDivide.Size = new Size(41, 23);
        _simpleDivide.TabIndex = 7;
        _simpleDivide.Text = "/";
        _simpleDivide.UseVisualStyleBackColor = true;
        // 
        // _simpleLeftInput
        // 
        _simpleLeftInput.Location = new Point(13, 82);
        _simpleLeftInput.Name = "_simpleLeftInput";
        _simpleLeftInput.Size = new Size(182, 23);
        _simpleLeftInput.TabIndex = 8;
        // 
        // _simpleRightInput
        // 
        _simpleRightInput.Location = new Point(13, 111);
        _simpleRightInput.Name = "_simpleRightInput";
        _simpleRightInput.Size = new Size(182, 23);
        _simpleRightInput.TabIndex = 9;
        // 
        // _simpleResult
        // 
        _simpleResult.AutoSize = true;
        _simpleResult.Font = new Font("Segoe UI", 20F);
        _simpleResult.Location = new Point(13, 13);
        _simpleResult.Name = "_simpleResult";
        _simpleResult.Size = new Size(169, 37);
        _simpleResult.TabIndex = 12;
        _simpleResult.Text = "SimpleResult";
        // 
        // _games
        // 
        _games.DropDownStyle = ComboBoxStyle.DropDownList;
        _games.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
        _games.Location = new Point(60, 8);
        _games.Name = "_games";
        _games.Size = new Size(151, 25);
        _games.TabIndex = 27;
        // 
        // _upperLayout
        // 
        _upperLayout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _upperLayout.ColumnCount = 2;
        _upperLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _upperLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _upperLayout.Controls.Add(_getGotSelectedItems, 0, 1);
        _upperLayout.Controls.Add(_getGotItemPurposes, 1, 0);
        _upperLayout.Controls.Add(_user, 0, 0);
        _upperLayout.Controls.Add(_getGotItemTypes, 1, 1);
        _upperLayout.Location = new Point(12, 6);
        _upperLayout.Margin = new Padding(0);
        _upperLayout.Name = "_upperLayout";
        _upperLayout.Padding = new Padding(5, 10, 5, 5);
        _upperLayout.RowCount = 2;
        _upperLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        _upperLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        _upperLayout.Size = new Size(505, 79);
        _upperLayout.TabIndex = 28;
        // 
        // _getGotItemPurposes
        // 
        _getGotItemPurposes.DropDownStyle = ComboBoxStyle.DropDownList;
        _getGotItemPurposes.Location = new Point(272, 13);
        _getGotItemPurposes.Margin = new Padding(20, 3, 0, 0);
        _getGotItemPurposes.Name = "_getGotItemPurposes";
        _getGotItemPurposes.Size = new Size(220, 23);
        _getGotItemPurposes.TabIndex = 0;
        // 
        // _user
        // 
        _user.AutoSize = true;
        _user.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
        _user.Location = new Point(8, 10);
        _user.Name = "_user";
        _user.Size = new Size(50, 25);
        _user.TabIndex = 11;
        _user.Text = "User";
        // 
        // _game
        // 
        _game.AutoSize = true;
        _game.Location = new Point(8, 5);
        _game.Name = "_game";
        _game.Size = new Size(38, 15);
        _game.TabIndex = 10;
        _game.Text = "Game";
        // 
        // _race
        // 
        _race.AutoSize = true;
        _race.Location = new Point(322, 5);
        _race.Name = "_race";
        _race.Size = new Size(32, 15);
        _race.TabIndex = 13;
        _race.Text = "Race";
        // 
        // _unitProductionResult
        // 
        _unitProductionResult.AutoSize = true;
        _unitProductionResult.Location = new Point(3, 108);
        _unitProductionResult.Name = "_unitProductionResult";
        _unitProductionResult.Size = new Size(135, 15);
        _unitProductionResult.TabIndex = 36;
        _unitProductionResult.Text = "FromValueToValueResult";
        // 
        // _unitProductionToInput
        // 
        _unitProductionToInput.Location = new Point(156, 35);
        _unitProductionToInput.Name = "_unitProductionToInput";
        _unitProductionToInput.Size = new Size(194, 23);
        _unitProductionToInput.TabIndex = 35;
        // 
        // _unitProductionFromInput
        // 
        _unitProductionFromInput.Location = new Point(156, 3);
        _unitProductionFromInput.Name = "_unitProductionFromInput";
        _unitProductionFromInput.Size = new Size(194, 23);
        _unitProductionFromInput.TabIndex = 34;
        // 
        // _unitProductionCalculateDesiredUp
        // 
        _unitProductionCalculateDesiredUp.Location = new Point(412, 35);
        _unitProductionCalculateDesiredUp.Name = "_unitProductionCalculateDesiredUp";
        _unitProductionCalculateDesiredUp.Size = new Size(75, 23);
        _unitProductionCalculateDesiredUp.TabIndex = 30;
        _unitProductionCalculateDesiredUp.Text = "Calculate";
        _unitProductionCalculateDesiredUp.UseVisualStyleBackColor = true;
        // 
        // _unitProductionLayout
        // 
        _unitProductionLayout.ColumnCount = 3;
        _unitProductionLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        _unitProductionLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _unitProductionLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        _unitProductionLayout.Controls.Add(_unitProductionCalculateNaqToSpend, 2, 2);
        _unitProductionLayout.Controls.Add(_unitProductionResourcesToSpendInput, 1, 2);
        _unitProductionLayout.Controls.Add(_unitProductionCurrentUp, 0, 0);
        _unitProductionLayout.Controls.Add(_unitProductionDesiredUp, 0, 1);
        _unitProductionLayout.Controls.Add(_unitProductionCalculateDesiredUp, 2, 1);
        _unitProductionLayout.Controls.Add(_unitProductionToInput, 1, 1);
        _unitProductionLayout.Controls.Add(_unitProductionResToSpend, 0, 2);
        _unitProductionLayout.Controls.Add(_unitProductionFromInput, 1, 0);
        _unitProductionLayout.Location = new Point(3, 6);
        _unitProductionLayout.Name = "_unitProductionLayout";
        _unitProductionLayout.RowCount = 3;
        _unitProductionLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.0043869F));
        _unitProductionLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.0043869F));
        _unitProductionLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.9912224F));
        _unitProductionLayout.Size = new Size(513, 99);
        _unitProductionLayout.TabIndex = 37;
        // 
        // _unitProductionCalculateNaqToSpend
        // 
        _unitProductionCalculateNaqToSpend.Location = new Point(412, 67);
        _unitProductionCalculateNaqToSpend.Name = "_unitProductionCalculateNaqToSpend";
        _unitProductionCalculateNaqToSpend.Size = new Size(75, 23);
        _unitProductionCalculateNaqToSpend.TabIndex = 38;
        _unitProductionCalculateNaqToSpend.Text = "Calculate";
        _unitProductionCalculateNaqToSpend.UseVisualStyleBackColor = true;
        // 
        // _unitProductionResourcesToSpendInput
        // 
        _unitProductionResourcesToSpendInput.Location = new Point(156, 67);
        _unitProductionResourcesToSpendInput.Name = "_unitProductionResourcesToSpendInput";
        _unitProductionResourcesToSpendInput.Size = new Size(194, 23);
        _unitProductionResourcesToSpendInput.TabIndex = 36;
        // 
        // _unitProductionCurrentUp
        // 
        _unitProductionCurrentUp.AutoSize = true;
        _unitProductionCurrentUp.Location = new Point(3, 0);
        _unitProductionCurrentUp.Name = "_unitProductionCurrentUp";
        _unitProductionCurrentUp.Size = new Size(128, 15);
        _unitProductionCurrentUp.TabIndex = 10;
        _unitProductionCurrentUp.Text = "CurrentUnitProduction";
        // 
        // _unitProductionDesiredUp
        // 
        _unitProductionDesiredUp.AutoSize = true;
        _unitProductionDesiredUp.Location = new Point(3, 32);
        _unitProductionDesiredUp.Name = "_unitProductionDesiredUp";
        _unitProductionDesiredUp.Size = new Size(127, 15);
        _unitProductionDesiredUp.TabIndex = 13;
        _unitProductionDesiredUp.Text = "DesiredUnitProduction";
        // 
        // _unitProductionResToSpend
        // 
        _unitProductionResToSpend.AutoSize = true;
        _unitProductionResToSpend.Location = new Point(3, 64);
        _unitProductionResToSpend.Name = "_unitProductionResToSpend";
        _unitProductionResToSpend.Size = new Size(136, 15);
        _unitProductionResToSpend.TabIndex = 14;
        _unitProductionResToSpend.Text = "ResourcesToSpendOnUP";
        // 
        // _tab
        // 
        _tab.Controls.Add(_tabPageGetGot);
        _tab.Controls.Add(_tabPageUp);
        _tab.Controls.Add(_tabPageSimple);
        _tab.Location = new Point(7, 55);
        _tab.Name = "_tab";
        _tab.SelectedIndex = 0;
        _tab.Size = new Size(536, 257);
        _tab.TabIndex = 38;
        // 
        // _tabPageGetGot
        // 
        _tabPageGetGot.Controls.Add(_commandsLayout);
        _tabPageGetGot.Controls.Add(_upperLayout);
        _tabPageGetGot.Controls.Add(_getGotUserInput);
        _tabPageGetGot.Location = new Point(4, 24);
        _tabPageGetGot.Name = "_tabPageGetGot";
        _tabPageGetGot.Padding = new Padding(3);
        _tabPageGetGot.Size = new Size(528, 229);
        _tabPageGetGot.TabIndex = 0;
        _tabPageGetGot.Text = "getGot";
        _tabPageGetGot.UseVisualStyleBackColor = true;
        // 
        // _tabPageUp
        // 
        _tabPageUp.Controls.Add(_unitProductionLayout);
        _tabPageUp.Controls.Add(_unitProductionResult);
        _tabPageUp.Location = new Point(4, 24);
        _tabPageUp.Name = "_tabPageUp";
        _tabPageUp.Padding = new Padding(3);
        _tabPageUp.Size = new Size(528, 229);
        _tabPageUp.TabIndex = 1;
        _tabPageUp.Text = "UnitProduction";
        _tabPageUp.UseVisualStyleBackColor = true;
        // 
        // _tabPageSimple
        // 
        _tabPageSimple.Controls.Add(_simpleClearHistory);
        _tabPageSimple.Controls.Add(_simpleClear);
        _tabPageSimple.Controls.Add(_simpleHistory);
        _tabPageSimple.Controls.Add(_simpleLeftInput);
        _tabPageSimple.Controls.Add(_simpleSum);
        _tabPageSimple.Controls.Add(_simpleDeduct);
        _tabPageSimple.Controls.Add(_simpleMultiply);
        _tabPageSimple.Controls.Add(_simpleDivide);
        _tabPageSimple.Controls.Add(_simpleResult);
        _tabPageSimple.Controls.Add(_simpleRightInput);
        _tabPageSimple.Location = new Point(4, 24);
        _tabPageSimple.Name = "_tabPageSimple";
        _tabPageSimple.Padding = new Padding(3);
        _tabPageSimple.Size = new Size(528, 229);
        _tabPageSimple.TabIndex = 2;
        _tabPageSimple.Text = "Simple";
        _tabPageSimple.UseVisualStyleBackColor = true;
        // 
        // _simpleClearHistory
        // 
        _simpleClearHistory.Location = new Point(240, 13);
        _simpleClearHistory.Name = "_simpleClearHistory";
        _simpleClearHistory.Size = new Size(19, 23);
        _simpleClearHistory.TabIndex = 15;
        _simpleClearHistory.Text = "C";
        _simpleClearHistory.UseVisualStyleBackColor = true;
        // 
        // _simpleClear
        // 
        _simpleClear.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
        _simpleClear.Location = new Point(218, 53);
        _simpleClear.Name = "_simpleClear";
        _simpleClear.Size = new Size(41, 52);
        _simpleClear.TabIndex = 14;
        _simpleClear.Text = "C";
        _simpleClear.UseVisualStyleBackColor = true;
        // 
        // _simpleHistory
        // 
        _simpleHistory.FormattingEnabled = true;
        _simpleHistory.Location = new Point(265, 6);
        _simpleHistory.Name = "_simpleHistory";
        _simpleHistory.Size = new Size(254, 199);
        _simpleHistory.TabIndex = 13;
        // 
        // _raceLayout
        // 
        _raceLayout.ColumnCount = 5;
        _raceLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        _raceLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        _raceLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        _raceLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        _raceLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        _raceLayout.Controls.Add(_race, 3, 0);
        _raceLayout.Controls.Add(_races, 4, 0);
        _raceLayout.Controls.Add(_games, 1, 0);
        _raceLayout.Controls.Add(_game, 0, 0);
        _raceLayout.Location = new Point(7, 6);
        _raceLayout.Margin = new Padding(0);
        _raceLayout.Name = "_raceLayout";
        _raceLayout.Padding = new Padding(5);
        _raceLayout.RowCount = 1;
        _raceLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _raceLayout.Size = new Size(536, 46);
        _raceLayout.TabIndex = 39;
        // 
        // _bottomLayout
        // 
        _bottomLayout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _bottomLayout.ColumnCount = 2;
        _bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _bottomLayout.Controls.Add(_amountToCopy, 0, 0);
        _bottomLayout.Controls.Add(_valueToCopy, 1, 0);
        _bottomLayout.Location = new Point(9, 315);
        _bottomLayout.Margin = new Padding(0);
        _bottomLayout.Name = "_bottomLayout";
        _bottomLayout.Padding = new Padding(5, 10, 5, 5);
        _bottomLayout.RowCount = 2;
        _bottomLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _bottomLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        _bottomLayout.Size = new Size(261, 47);
        _bottomLayout.TabIndex = 40;
        // 
        // _amountToCopy
        // 
        _amountToCopy.DropDownStyle = ComboBoxStyle.DropDownList;
        _amountToCopy.Items.AddRange(new object[] { "1", "5", "10", "20", "25", "50", "100", "200", "250", "500" });
        _amountToCopy.Location = new Point(25, 13);
        _amountToCopy.Margin = new Padding(20, 3, 0, 0);
        _amountToCopy.Name = "_amountToCopy";
        _amountToCopy.Size = new Size(98, 23);
        _amountToCopy.TabIndex = 0;
        // 
        // _valueToCopy
        // 
        _valueToCopy.DropDownStyle = ComboBoxStyle.DropDownList;
        _valueToCopy.Items.AddRange(new object[] { "Billion", "Trillion" });
        _valueToCopy.Location = new Point(150, 13);
        _valueToCopy.Margin = new Padding(20, 3, 0, 0);
        _valueToCopy.Name = "_valueToCopy";
        _valueToCopy.Size = new Size(97, 23);
        _valueToCopy.TabIndex = 0;
        // 
        // _generatePersonalLog
        // 
        _generatePersonalLog.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
        _generatePersonalLog.Location = new Point(381, 315);
        _generatePersonalLog.Name = "_generatePersonalLog";
        _generatePersonalLog.Size = new Size(158, 47);
        _generatePersonalLog.TabIndex = 41;
        _generatePersonalLog.Text = "GeneratePersonalLog";
        _generatePersonalLog.UseVisualStyleBackColor = true;
        _generatePersonalLog.Click += _generatePersonalLog_Click;
        // 
        // _copyToClipBoard
        // 
        _copyToClipBoard.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
        _copyToClipBoard.Location = new Point(34, 365);
        _copyToClipBoard.Name = "_copyToClipBoard";
        _copyToClipBoard.Size = new Size(222, 28);
        _copyToClipBoard.TabIndex = 15;
        _copyToClipBoard.Text = "Copy";
        _copyToClipBoard.UseVisualStyleBackColor = true;
        // 
        // Display
        // 
        ClientSize = new Size(551, 402);
        Controls.Add(_generatePersonalLog);
        Controls.Add(_bottomLayout);
        Controls.Add(_copyToClipBoard);
        Controls.Add(_raceLayout);
        Controls.Add(_tab);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Display";
        ShowIcon = false;
        _commandsLayout.ResumeLayout(false);
        _commandsLayout.PerformLayout();
        _upperLayout.ResumeLayout(false);
        _upperLayout.PerformLayout();
        _unitProductionLayout.ResumeLayout(false);
        _unitProductionLayout.PerformLayout();
        _tab.ResumeLayout(false);
        _tabPageGetGot.ResumeLayout(false);
        _tabPageGetGot.PerformLayout();
        _tabPageUp.ResumeLayout(false);
        _tabPageUp.PerformLayout();
        _tabPageSimple.ResumeLayout(false);
        _tabPageSimple.PerformLayout();
        _raceLayout.ResumeLayout(false);
        _raceLayout.PerformLayout();
        _bottomLayout.ResumeLayout(false);
        ResumeLayout(false);
    }
    internal TextBox _getGotUserInput;
    internal TableLayoutPanel _commandsLayout;
    internal ComboBox _games;
    internal TableLayoutPanel _upperLayout;
    internal Label _game;
    internal Label _race;
    internal TableLayoutPanel _unitProductionLayout;
    internal TabControl _tab;
    internal TabPage _tabPageGetGot;
    internal TabPage _tabPageUp;
    internal TabPage _tabPageSimple;
    internal Label _getGotAbleToBuy;
    internal Label _getGotCostToBuy;
    internal Label _getGotCostToReassign;
    internal Button _simpleSum;
    internal Button _simpleMultiply;
    internal Button _simpleDivide;
    internal TextBox _simpleLeftInput;
    internal TextBox _simpleRightInput;
    internal Button _simpleDeduct;
    internal Label _simpleResult;
    internal ListBox _simpleHistory;
    internal Button _simpleClearHistory;
    internal Button _simpleClear;
    internal Label _unitProductionResult;
    internal TextBox _unitProductionToInput;
    internal TextBox _unitProductionFromInput;
    internal Button _unitProductionCalculateDesiredUp;
    internal TextBox _unitProductionResourcesToSpendInput;
    internal Button _unitProductionCalculateNaqToSpend;
    internal ToolTip _toolTips;
    internal ComboBox _races;
    internal Label _unitProductionCurrentUp;
    internal Label _unitProductionDesiredUp;
    internal Label _unitProductionResToSpend;
    internal TableLayoutPanel _raceLayout;
    internal ComboBox _getGotItemTypes;
    internal ComboBox _getGotSelectedItems;
    internal ComboBox _getGotItemPurposes;
    internal Label _user;
    internal TableLayoutPanel _bottomLayout;
    internal ComboBox _amountToCopy;
    internal ComboBox _valueToCopy;
    internal Button _generatePersonalLog;
    internal Button _copyToClipBoard;
}