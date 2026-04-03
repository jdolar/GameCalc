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
            string calculation = Operation.Sum(inputLeft.Text, inputRight.Text, true);
            AddToHistory(history, inputLeft.Text, inputRight.Text, "+", calculation);
        };
        
        deduct.Click += (s, e) =>
        {
            string calculation = Operation.Deduct(inputLeft.Text, inputRight.Text, true);
            AddToHistory(history, inputLeft.Text, inputRight.Text, "-", calculation);
        };
        
        divide.Click += (s, e) =>
        {
            string calculation = Operation.Divide(inputLeft.Text, inputRight.Text, true);
            AddToHistory(history, inputLeft.Text, inputRight.Text, "/", calculation);
        };
        
        multiply.Click += (s, e) =>
        {
            string calculation = Operation.Multiply(inputLeft.Text, inputRight.Text, true);
            AddToHistory(history, inputLeft.Text, inputRight.Text, "x", calculation);
        };

        clear.Click += (s, e) =>
        {
            UIController.UpdateLabel(result, string.Empty);
            UIController.UpdateTextBox(inputLeft, string.Empty);
            UIController.UpdateTextBox(inputRight, string.Empty);
        };

        history.Click += (s, e) =>
        {
            string? item = history.SelectedItem?.ToString()?.Split('=')[1];
            if (!string.IsNullOrEmpty(item))
                UIController.CopyToClipboard(item);
        };

        clearHistory.Click += (s, e) => history.Items.Clear();
        result.Click += (s, e) => UIController.CopyToClipboard(result.Text);
    }
    private void AddToHistory(ListBox history, string left, string right, string operation, string result) => history.Items.Add($"{Clean.Text(left)}{operation}{Clean.Text(right)}={result}");
}