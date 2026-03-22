using Calculator;
using Data;
using Data.Commands;
using UI.Windows.Helpers;
namespace UI.Windows.Controllers.Calculators;
internal sealed class Simple
{
    public Simple(Label result, TextBox inputLeft, TextBox inputRight, ListBox history,
                      Button sum, Button multiply, Button divide, Button deduct, Button clear, Button clearHistory, TabPage tabPage)
    {
        UIController.UpdateLayoutTabPage(tabPage, Constants.GUI.Labels.Simple);

        UIController.UpdateLabel(result, string.Empty);
        UIController.UpdateTextBox(inputLeft, string.Empty);
        UIController.UpdateTextBox(inputRight, string.Empty);

        sum.Click += (s, e) =>
        {
            string calculation = Calc.Sum(inputLeft.Text, inputRight.Text, true);
            if (!string.IsNullOrEmpty(calculation))
            {
                UIController.UpdateLabel(result, calculation);
                history.Items.Add($"{Clean.Text(inputLeft.Text)}+{Clean.Text(inputRight.Text)}={calculation}");
            }
        };
        
        deduct.Click += (s, e) =>
        {
            string calculation = Calc.Deduct(inputLeft.Text, inputRight.Text);
            if (!string.IsNullOrEmpty(calculation))
            {
                UIController.UpdateLabel(result, calculation);
                history.Items.Add($"{Clean.Text(inputLeft.Text)}-{Clean.Text(inputRight.Text)}={result}");
            }
        };
        
        divide.Click += (s, e) =>
        {
            string calculation = Calc.Divide(inputLeft.Text, inputRight.Text);
            if (!string.IsNullOrEmpty(calculation))
            {
                UIController.UpdateLabel(result, calculation);
                history.Items.Add($"{Clean.Text(inputLeft.Text)}/{Clean.Text(inputRight.Text)}={result}");
            }
        };
        
        multiply.Click += (s, e) =>
        {
            string calculation = Calc.Multiply(inputLeft.Text, inputRight.Text);
            if (!string.IsNullOrEmpty(calculation))
            {
                UIController.UpdateLabel(result, calculation);
                history.Items.Add($"{Clean.Text(inputLeft.Text)}x{Clean.Text(inputRight.Text)}={result}");
            }
        };

        clear.Click += (s, e) =>
        {
            UIController.UpdateLabel(result, string.Empty);
            UIController.UpdateTextBox(inputLeft, string.Empty);
            UIController.UpdateTextBox(inputRight, string.Empty);
        };

        clearHistory.Click += (s, e) => history.Items.Clear();
        result.Click += (s, e) => UIController.CopyToClipboard(result.Text);
    }
}