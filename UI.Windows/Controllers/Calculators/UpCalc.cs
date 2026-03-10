using Calculator;
using Data;
using UI.Windows.Helpers;

namespace UI.Windows.Controllers.Calculators;

internal sealed class UpCalc
{
    private readonly Display _form;
    public UpCalc(Display form)
    {
        _form = form;

        _form._currentUp.Text = Constants.GUI.Labels.CurrentUp;
        _form._desiredUp.Text = Constants.GUI.Labels.DesiredUp;
        _form._resToSpend.Text = Constants.GUI.Labels.ResourcesToSpend;
        _form ._upCalcResult.Text = string.Empty;

        _form._fromInput.Text = string.Empty;
        _form._toInput.Text = string.Empty;
        _form._resourcesToSpendInput.Text = string.Empty;

        _form._calculateDesiredUp.Click += (s, e) =>
            {
                (string results, string multiplier, string formatedLeftInput, string formattedRightInput)
                    = Calc.CalculateDesiredUp(_form._fromInput.Text, _form._toInput.Text);

                if (results != _form._upCalcResult.Text)
                {
                    string hint = Hints.UpCalcDesiredUpResults(formatedLeftInput, formattedRightInput, results, multiplier, _form._selectedRace.Currency.Name);

                    _form._upCalcResult.Text = hint;
                    _form._hint.SetToolTip(_form._upCalcResult, hint);
                }
            };
        _form._calculateNaqToSpend.Click += (s, e) =>
        {
            (string results, string multiplier, string formatedLeftInput, string formattedRightInput)
                = Calc.CalulatePossibleUpUpgrade(_form._fromInput.Text, _form._resourcesToSpendInput.Text);

            if (results != _form._upCalcResult.Text)
            {
                string hint = Hints.UpCalcResurcesToSpendResults(formatedLeftInput, formattedRightInput, results, multiplier, _form._selectedRace.Currency.Name);

                _form._upCalcResult.Text = hint;
                _form._hint.SetToolTip(_form._upCalcResult, hint);
            }
        };

        _form._upCalcResult.Click += (s, e) => UIData.CopyToClipboard(_form._upCalcResult.Text);
        _form._currentUp.Click += (s, e) => UIData.CopyToClipboard(_form._currentUp.Text);
    }
}
