namespace UI.Windows.Calculators;
using Calculator;
using Data.Commands;
using UI.Windows;
using UI.Windows.Helpers;

internal sealed class SimpleCalc
{
    private readonly Display _form;
    public SimpleCalc(Display form)
    {
        _form = form;

        _form._simpleCalcResult.Text = string.Empty;
        _form._calcInputLeft.Text = string.Empty;
        _form._calcInputRight.Text = string.Empty;

        _form._sum.Click += (s, e) =>
        {
            string result = Calc.Sum(_form._calcInputLeft.Text, _form._calcInputRight.Text, true);
            if (!string.IsNullOrEmpty(result))
            {
                _form._simpleCalcResult.Text = result;
                _form._simpleCalcResultHistory.Items.Add($"{Clean.Text(_form._calcInputLeft.Text)}+{Clean.Text(_form._calcInputRight.Text)}={result}");
            }
        };
        _form._deduct.Click += (s, e) =>
        {
            string result = Calc.Deduct(_form._calcInputLeft.Text, _form._calcInputRight.Text);
            if (!string.IsNullOrEmpty(result))
            {
                _form._simpleCalcResult.Text = result;
                _form._simpleCalcResultHistory.Items.Add($"{Clean.Text(_form._calcInputLeft.Text)}-{Clean.Text(_form._calcInputRight.Text)}={result}");
            }
        };
        _form._divide.Click += (s, e) =>
        {
            string result = Calc.Divide(_form._calcInputLeft.Text, _form._calcInputRight.Text);
            if (!string.IsNullOrEmpty(result))
            {
                _form._simpleCalcResult.Text = result;
                _form._simpleCalcResultHistory.Items.Add($"{Clean.Text(_form._calcInputLeft.Text)}/{Clean.Text(_form._calcInputRight.Text)}={result}");
            }
        };
        _form._multiply.Click += (s, e) =>
        {
            string result = Calc.Multiply(_form._calcInputLeft.Text, _form._calcInputRight.Text);
            if (!string.IsNullOrEmpty(result))
            {
                _form._simpleCalcResult.Text = result;
                _form._simpleCalcResultHistory.Items.Add($"{Clean.Text(_form._calcInputLeft.Text)}x{Clean.Text(_form._calcInputRight.Text)}={result}");
            }
        };

        _form._clearSimpleCalc.Click += (s, e) =>
        {
            _form._simpleCalcResult.Text = string.Empty;
            _form._calcInputLeft.Text = string.Empty;
            _form._calcInputRight.Text = string.Empty;
        };

        _form._clearSimpleCalcHistory.Click += (s, e) => _form._simpleCalcResultHistory.Items.Clear();

        _form._simpleCalcResult.Click += (s, e) => UIData.CopyToClipboard(_form._simpleCalcResult.Text);
    }
}

