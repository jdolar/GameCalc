using Data.Models;
using UI.Windows.Controllers;
using UI.Windows.Controllers.Calculators;
using UI.Windows.Helpers;
namespace UI.Windows;
public partial class Display : Form
{
    public Game _selectedGame = new();
    public Race _selectedRace = new();
    public readonly List<Game> _enabledGames = UIData.GetGames();

    private readonly Frame _frame = null!;
    private readonly TheCalc _theCalc = null!;
    private readonly UpCalc _upCalc = null!;
    private readonly SimpleCalc _simpleCalc = null!;
    
    public Display()
    {
        InitializeComponent();

        _frame = new Frame(this);
        _theCalc = new TheCalc(this);
        _simpleCalc = new SimpleCalc(this);
        _upCalc = new UpCalc(this);
        _frame.UpdateSelectedGame();
    }
}
