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
        _itemTypes = new ComboBox();
        _userInput = new TextBox();
        _selectedItems = new ComboBox();
        _commandsLayout = new TableLayoutPanel();
        _ableToBuyValue = new Label();
        _costToBuyValue = new Label();
        _costToReassignValue = new Label();
        _sum = new Button();
        _deduct = new Button();
        _multiply = new Button();
        _divide = new Button();
        _calcInputLeft = new TextBox();
        _calcInputRight = new TextBox();
        _simpleCalcResult = new Label();
        _hint = new ToolTip(components);
        _games = new ComboBox();
        _upperLayout = new TableLayoutPanel();
        _type = new Label();
        _itemPurposes = new ComboBox();
        _game = new Label();
        _race = new Label();
        _upCalcResult = new Label();
        _toInput = new TextBox();
        _fromInput = new TextBox();
        _calculateDesiredUp = new Button();
        _upCalcLayout = new TableLayoutPanel();
        _calculateNaqToSpend = new Button();
        _resourcesToSpendInput = new TextBox();
        _currentUp = new Label();
        _desiredUp = new Label();
        _resToSpend = new Label();
        _tab = new TabControl();
        _tabPageTheCalc = new TabPage();
        _middleLayout = new TableLayoutPanel();
        _tabPageUpCalc = new TabPage();
        _tabPageSimpleCalc = new TabPage();
        _clearSimpleCalcHistory = new Button();
        _clearSimpleCalc = new Button();
        _simpleCalcResultHistory = new ListBox();
        _raceLayout = new TableLayoutPanel();
        _commandsLayout.SuspendLayout();
        _upperLayout.SuspendLayout();
        _upCalcLayout.SuspendLayout();
        _tab.SuspendLayout();
        _tabPageTheCalc.SuspendLayout();
        _tabPageUpCalc.SuspendLayout();
        _tabPageSimpleCalc.SuspendLayout();
        _raceLayout.SuspendLayout();
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
        // _itemTypes
        // 
        _itemTypes.DropDownStyle = ComboBoxStyle.DropDownList;
        _itemTypes.Location = new Point(284, 8);
        _itemTypes.Name = "_itemTypes";
        _itemTypes.Size = new Size(221, 23);
        _itemTypes.TabIndex = 0;
        // 
        // _userInput
        // 
        _userInput.Location = new Point(8, 86);
        _userInput.Name = "_userInput";
        _userInput.Size = new Size(497, 23);
        _userInput.TabIndex = 1;
        // 
        // _selectedItems
        // 
        _selectedItems.DropDownStyle = ComboBoxStyle.DropDownList;
        _selectedItems.Location = new Point(58, 37);
        _selectedItems.Name = "_selectedItems";
        _selectedItems.Size = new Size(220, 23);
        _selectedItems.TabIndex = 2;
        // 
        // _commandsLayout
        // 
        _commandsLayout.ColumnCount = 1;
        _commandsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _commandsLayout.Controls.Add(_ableToBuyValue, 0, 0);
        _commandsLayout.Controls.Add(_costToBuyValue, 0, 1);
        _commandsLayout.Controls.Add(_userInput, 0, 3);
        _commandsLayout.Controls.Add(_costToReassignValue, 0, 2);
        _commandsLayout.Location = new Point(6, 175);
        _commandsLayout.Name = "_commandsLayout";
        _commandsLayout.Padding = new Padding(5);
        _commandsLayout.RowCount = 4;
        _commandsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        _commandsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        _commandsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        _commandsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        _commandsLayout.Size = new Size(513, 116);
        _commandsLayout.TabIndex = 3;
        // 
        // _ableToBuyValue
        // 
        _ableToBuyValue.AutoSize = true;
        _ableToBuyValue.Location = new Point(8, 5);
        _ableToBuyValue.Name = "_ableToBuyValue";
        _ableToBuyValue.Size = new Size(91, 15);
        _ableToBuyValue.TabIndex = 10;
        _ableToBuyValue.Text = "AbleToBuyValue";
        // 
        // _costToBuyValue
        // 
        _costToBuyValue.AutoSize = true;
        _costToBuyValue.Location = new Point(8, 31);
        _costToBuyValue.Name = "_costToBuyValue";
        _costToBuyValue.Size = new Size(91, 15);
        _costToBuyValue.TabIndex = 13;
        _costToBuyValue.Text = "CostToBuyValue";
        // 
        // _costToReassignValue
        // 
        _costToReassignValue.AutoSize = true;
        _costToReassignValue.Location = new Point(8, 57);
        _costToReassignValue.Name = "_costToReassignValue";
        _costToReassignValue.Size = new Size(117, 15);
        _costToReassignValue.TabIndex = 14;
        _costToReassignValue.Text = "CostToReassignValue";
        // 
        // _sum
        // 
        _sum.Location = new Point(110, 73);
        _sum.Name = "_sum";
        _sum.Size = new Size(41, 23);
        _sum.TabIndex = 4;
        _sum.Text = "+";
        _sum.UseVisualStyleBackColor = true;
        // 
        // _deduct
        // 
        _deduct.Location = new Point(157, 73);
        _deduct.Name = "_deduct";
        _deduct.Size = new Size(41, 23);
        _deduct.TabIndex = 5;
        _deduct.Text = "-";
        _deduct.UseVisualStyleBackColor = true;
        // 
        // _multiply
        // 
        _multiply.Location = new Point(63, 73);
        _multiply.Name = "_multiply";
        _multiply.Size = new Size(41, 23);
        _multiply.TabIndex = 6;
        _multiply.Text = "x";
        _multiply.UseVisualStyleBackColor = true;
        // 
        // _divide
        // 
        _divide.Location = new Point(16, 73);
        _divide.Name = "_divide";
        _divide.Size = new Size(41, 23);
        _divide.TabIndex = 7;
        _divide.Text = "/";
        _divide.UseVisualStyleBackColor = true;
        // 
        // _calcInputLeft
        // 
        _calcInputLeft.Location = new Point(16, 102);
        _calcInputLeft.Name = "_calcInputLeft";
        _calcInputLeft.Size = new Size(182, 23);
        _calcInputLeft.TabIndex = 8;
        // 
        // _calcInputRight
        // 
        _calcInputRight.Location = new Point(16, 131);
        _calcInputRight.Name = "_calcInputRight";
        _calcInputRight.Size = new Size(182, 23);
        _calcInputRight.TabIndex = 9;
        // 
        // _simpleCalcResult
        // 
        _simpleCalcResult.AutoSize = true;
        _simpleCalcResult.Font = new Font("Segoe UI", 20F);
        _simpleCalcResult.Location = new Point(124, 20);
        _simpleCalcResult.Name = "_simpleCalcResult";
        _simpleCalcResult.Size = new Size(138, 37);
        _simpleCalcResult.TabIndex = 12;
        _simpleCalcResult.Text = "CalcResult";
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
        _upperLayout.ColumnCount = 3;
        _upperLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        _upperLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
        _upperLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
        _upperLayout.Controls.Add(_selectedItems, 1, 1);
        _upperLayout.Controls.Add(_type, 0, 0);
        _upperLayout.Controls.Add(_itemPurposes, 1, 0);
        _upperLayout.Controls.Add(_itemTypes, 2, 0);
        _upperLayout.Location = new Point(6, 6);
        _upperLayout.Margin = new Padding(0);
        _upperLayout.Name = "_upperLayout";
        _upperLayout.Padding = new Padding(5);
        _upperLayout.RowCount = 3;
        _upperLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        _upperLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        _upperLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        _upperLayout.Size = new Size(513, 99);
        _upperLayout.TabIndex = 28;
        // 
        // _type
        // 
        _type.AutoSize = true;
        _type.Location = new Point(8, 5);
        _type.Name = "_type";
        _type.Size = new Size(31, 15);
        _type.TabIndex = 14;
        _type.Text = "Type";
        // 
        // _itemPurposes
        // 
        _itemPurposes.DropDownStyle = ComboBoxStyle.DropDownList;
        _itemPurposes.Location = new Point(58, 8);
        _itemPurposes.Name = "_itemPurposes";
        _itemPurposes.Size = new Size(220, 23);
        _itemPurposes.TabIndex = 0;
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
        // _upCalcResult
        // 
        _upCalcResult.AutoSize = true;
        _upCalcResult.Location = new Point(3, 108);
        _upCalcResult.Name = "_upCalcResult";
        _upCalcResult.Size = new Size(135, 15);
        _upCalcResult.TabIndex = 36;
        _upCalcResult.Text = "FromValueToValueResult";
        // 
        // _toInput
        // 
        _toInput.Location = new Point(156, 35);
        _toInput.Name = "_toInput";
        _toInput.Size = new Size(194, 23);
        _toInput.TabIndex = 35;
        // 
        // _fromInput
        // 
        _fromInput.Location = new Point(156, 3);
        _fromInput.Name = "_fromInput";
        _fromInput.Size = new Size(194, 23);
        _fromInput.TabIndex = 34;
        // 
        // _calculateDesiredUp
        // 
        _calculateDesiredUp.Location = new Point(412, 35);
        _calculateDesiredUp.Name = "_calculateDesiredUp";
        _calculateDesiredUp.Size = new Size(75, 23);
        _calculateDesiredUp.TabIndex = 30;
        _calculateDesiredUp.Text = "Calculate";
        _calculateDesiredUp.UseVisualStyleBackColor = true;
        // 
        // _upCalcLayout
        // 
        _upCalcLayout.ColumnCount = 3;
        _upCalcLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        _upCalcLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _upCalcLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        _upCalcLayout.Controls.Add(_calculateNaqToSpend, 2, 2);
        _upCalcLayout.Controls.Add(_resourcesToSpendInput, 1, 2);
        _upCalcLayout.Controls.Add(_currentUp, 0, 0);
        _upCalcLayout.Controls.Add(_desiredUp, 0, 1);
        _upCalcLayout.Controls.Add(_calculateDesiredUp, 2, 1);
        _upCalcLayout.Controls.Add(_toInput, 1, 1);
        _upCalcLayout.Controls.Add(_resToSpend, 0, 2);
        _upCalcLayout.Controls.Add(_fromInput, 1, 0);
        _upCalcLayout.Location = new Point(3, 6);
        _upCalcLayout.Name = "_upCalcLayout";
        _upCalcLayout.RowCount = 3;
        _upCalcLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.0043869F));
        _upCalcLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.0043869F));
        _upCalcLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.9912224F));
        _upCalcLayout.Size = new Size(513, 99);
        _upCalcLayout.TabIndex = 37;
        // 
        // _calculateNaqToSpend
        // 
        _calculateNaqToSpend.Location = new Point(412, 67);
        _calculateNaqToSpend.Name = "_calculateNaqToSpend";
        _calculateNaqToSpend.Size = new Size(75, 23);
        _calculateNaqToSpend.TabIndex = 38;
        _calculateNaqToSpend.Text = "Calculate";
        _calculateNaqToSpend.UseVisualStyleBackColor = true;
        // 
        // _resourcesToSpendInput
        // 
        _resourcesToSpendInput.Location = new Point(156, 67);
        _resourcesToSpendInput.Name = "_resourcesToSpendInput";
        _resourcesToSpendInput.Size = new Size(194, 23);
        _resourcesToSpendInput.TabIndex = 36;
        // 
        // _currentUp
        // 
        _currentUp.AutoSize = true;
        _currentUp.Location = new Point(3, 0);
        _currentUp.Name = "_currentUp";
        _currentUp.Size = new Size(128, 15);
        _currentUp.TabIndex = 10;
        _currentUp.Text = "CurrentUnitProduction";
        // 
        // _desiredUp
        // 
        _desiredUp.AutoSize = true;
        _desiredUp.Location = new Point(3, 32);
        _desiredUp.Name = "_desiredUp";
        _desiredUp.Size = new Size(127, 15);
        _desiredUp.TabIndex = 13;
        _desiredUp.Text = "DesiredUnitProduction";
        // 
        // _resToSpend
        // 
        _resToSpend.AutoSize = true;
        _resToSpend.Location = new Point(3, 64);
        _resToSpend.Name = "_resToSpend";
        _resToSpend.Size = new Size(136, 15);
        _resToSpend.TabIndex = 14;
        _resToSpend.Text = "ResourcesToSpendOnUP";
        // 
        // _tab
        // 
        _tab.Controls.Add(_tabPageTheCalc);
        _tab.Controls.Add(_tabPageUpCalc);
        _tab.Controls.Add(_tabPageSimpleCalc);
        _tab.Location = new Point(7, 65);
        _tab.Name = "_tab";
        _tab.SelectedIndex = 0;
        _tab.Size = new Size(536, 331);
        _tab.TabIndex = 38;
        // 
        // _tabPageTheCalc
        // 
        _tabPageTheCalc.Controls.Add(_commandsLayout);
        _tabPageTheCalc.Controls.Add(_middleLayout);
        _tabPageTheCalc.Controls.Add(_upperLayout);
        _tabPageTheCalc.Location = new Point(4, 24);
        _tabPageTheCalc.Name = "_tabPageTheCalc";
        _tabPageTheCalc.Padding = new Padding(3);
        _tabPageTheCalc.Size = new Size(528, 303);
        _tabPageTheCalc.TabIndex = 0;
        _tabPageTheCalc.Text = "TheCalc";
        _tabPageTheCalc.UseVisualStyleBackColor = true;
        // 
        // _middleLayout
        // 
        _middleLayout.ColumnCount = 2;
        _middleLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _middleLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        _middleLayout.Location = new Point(55, 108);
        _middleLayout.Name = "_middleLayout";
        _middleLayout.Padding = new Padding(5);
        _middleLayout.RowCount = 1;
        _middleLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _middleLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        _middleLayout.Size = new Size(464, 58);
        _middleLayout.TabIndex = 29;
        // 
        // _tabPageUpCalc
        // 
        _tabPageUpCalc.Controls.Add(_upCalcLayout);
        _tabPageUpCalc.Controls.Add(_upCalcResult);
        _tabPageUpCalc.Location = new Point(4, 24);
        _tabPageUpCalc.Name = "_tabPageUpCalc";
        _tabPageUpCalc.Padding = new Padding(3);
        _tabPageUpCalc.Size = new Size(528, 303);
        _tabPageUpCalc.TabIndex = 1;
        _tabPageUpCalc.Text = "UPCalc";
        _tabPageUpCalc.UseVisualStyleBackColor = true;
        // 
        // _tabPageSimpleCalc
        // 
        _tabPageSimpleCalc.Controls.Add(_clearSimpleCalcHistory);
        _tabPageSimpleCalc.Controls.Add(_clearSimpleCalc);
        _tabPageSimpleCalc.Controls.Add(_simpleCalcResultHistory);
        _tabPageSimpleCalc.Controls.Add(_calcInputLeft);
        _tabPageSimpleCalc.Controls.Add(_sum);
        _tabPageSimpleCalc.Controls.Add(_deduct);
        _tabPageSimpleCalc.Controls.Add(_multiply);
        _tabPageSimpleCalc.Controls.Add(_divide);
        _tabPageSimpleCalc.Controls.Add(_simpleCalcResult);
        _tabPageSimpleCalc.Controls.Add(_calcInputRight);
        _tabPageSimpleCalc.Location = new Point(4, 24);
        _tabPageSimpleCalc.Name = "_tabPageSimpleCalc";
        _tabPageSimpleCalc.Padding = new Padding(3);
        _tabPageSimpleCalc.Size = new Size(528, 303);
        _tabPageSimpleCalc.TabIndex = 2;
        _tabPageSimpleCalc.Text = "SimpleCalc";
        _tabPageSimpleCalc.UseVisualStyleBackColor = true;
        // 
        // _clearSimpleCalcHistory
        // 
        _clearSimpleCalcHistory.Location = new Point(488, 2);
        _clearSimpleCalcHistory.Name = "_clearSimpleCalcHistory";
        _clearSimpleCalcHistory.Size = new Size(19, 23);
        _clearSimpleCalcHistory.TabIndex = 15;
        _clearSimpleCalcHistory.Text = "C";
        _clearSimpleCalcHistory.UseVisualStyleBackColor = true;
        // 
        // _clearSimpleCalc
        // 
        _clearSimpleCalc.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
        _clearSimpleCalc.Location = new Point(221, 73);
        _clearSimpleCalc.Name = "_clearSimpleCalc";
        _clearSimpleCalc.Size = new Size(41, 52);
        _clearSimpleCalc.TabIndex = 14;
        _clearSimpleCalc.Text = "C";
        _clearSimpleCalc.UseVisualStyleBackColor = true;
        // 
        // _simpleCalcResultHistory
        // 
        _simpleCalcResultHistory.FormattingEnabled = true;
        _simpleCalcResultHistory.Location = new Point(268, 31);
        _simpleCalcResultHistory.Name = "_simpleCalcResultHistory";
        _simpleCalcResultHistory.Size = new Size(239, 259);
        _simpleCalcResultHistory.TabIndex = 13;
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
        // Display
        // 
        ClientSize = new Size(551, 404);
        Controls.Add(_raceLayout);
        Controls.Add(_tab);
        Name = "Display";
        _commandsLayout.ResumeLayout(false);
        _commandsLayout.PerformLayout();
        _upperLayout.ResumeLayout(false);
        _upperLayout.PerformLayout();
        _upCalcLayout.ResumeLayout(false);
        _upCalcLayout.PerformLayout();
        _tab.ResumeLayout(false);
        _tabPageTheCalc.ResumeLayout(false);
        _tabPageUpCalc.ResumeLayout(false);
        _tabPageUpCalc.PerformLayout();
        _tabPageSimpleCalc.ResumeLayout(false);
        _tabPageSimpleCalc.PerformLayout();
        _raceLayout.ResumeLayout(false);
        _raceLayout.PerformLayout();
        ResumeLayout(false);
    }
    internal TextBox _userInput;
    private TableLayoutPanel _commandsLayout;
    private ComboBox _games;
    private TableLayoutPanel _upperLayout;
    private Label _game;
    private Label _race;
    private Label _type;
    private TableLayoutPanel _upCalcLayout;
    private TabControl _tab;
    private TabPage _tabPageTheCalc;
    private TabPage _tabPageUpCalc;
    private TabPage _tabPageSimpleCalc;
    internal Label _ableToBuyValue;
    internal Label _costToBuyValue;
    internal Label _costToReassignValue;
    internal Button _sum;
    internal Button _multiply;
    internal Button _divide;
    internal TextBox _calcInputLeft;
    internal TextBox _calcInputRight;
    internal Button _deduct;
    internal Label _simpleCalcResult;
    internal ListBox _simpleCalcResultHistory;
    internal Button _clearSimpleCalcHistory;
    internal Button _clearSimpleCalc;
    internal Label _upCalcResult;
    internal TextBox _toInput;
    internal TextBox _fromInput;
    internal Button _calculateDesiredUp;
    internal TextBox _resourcesToSpendInput;
    internal Button _calculateNaqToSpend;
    internal ToolTip _hint;
    private ComboBox _races;
    internal Label _currentUp;
    internal Label _desiredUp;
    internal Label _resToSpend;
    private TableLayoutPanel _raceLayout;
    private TableLayoutPanel _middleLayout;
    internal ComboBox _itemTypes;
    internal ComboBox _selectedItems;
    internal ComboBox _itemPurposes;
}