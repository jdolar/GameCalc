using Data;
using Data.Commands;
using Data.Enums.Unit;
using Data.Models;
namespace UI.Windows.Helpers;
internal static class UIController
{
    internal static readonly Data.Enums.Unit.Type[] _itemTypes = Enum.GetValues<Data.Enums.Unit.Type>();
    internal static readonly Purpose[] _itemPurposes = Enum.GetValues<Purpose>();
    internal static ComboBox SetItemTypesComboBox(ComboBox input)
    {
        input.Items.Clear();

        foreach (Data.Enums.Unit.Type item in _itemTypes)
            input.Items.Add(item);

        input.SelectedIndex = 0;

        return input;
    }
    internal static ComboBox SetItemPurposeComboBox(ComboBox input)
    {
        input.Items.Clear();

        foreach (Purpose item in _itemPurposes)
            input.Items.Add(item);

        input.SelectedIndex = 0;

        return input;
    }
    internal static List<Game> GetGames()
    {
        string[] jsonFiles = Directory.GetDirectories(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json", "Games"));
        return DataBuilder.GetGamesData(DataBuilder.GetGames("Games.json"), jsonFiles);
    }
    internal static void UpdateLabel(Label input, string upgradeText)
    {
        if (input == null || input.Text == upgradeText) return;

        input.Text = upgradeText;
    }
    internal static void UpdateLayoutTabPage(TabPage input, string upgradeText)
    {
        if (input == null || input.Text == upgradeText) return;

        input.Text = upgradeText;
    }
    internal static void UpdateTextBox(TextBox input, string upgradeText)
    {
        if (input == null || input.Text == upgradeText) return;

        input.Text = upgradeText;
    }
    internal static void SetRacesComboBox(ComboBox input, List<Race> races)
    {
        input.DataSource = races;
        input.DisplayMember = Constants.GUI.ComboBox.DisplayName;
    }
    internal static void SetGamesComboBox(ComboBox input, List<Game> games)
    {
        input.DataSource = games;
        input.DisplayMember = Constants.GUI.ComboBox.DisplayName;
    }
    internal static bool UpdateComboBox(ComboBox input, List<Unit> units, Data.Enums.Unit.Type type, Purpose purpose)
    {
        List<Unit> filteredUnits = DataBuilder.GetDataSource(units, type, purpose);
        
        if (filteredUnits.Count == 0)
        {
            input.DataSource = null;
            input.Items.Add(string.Format(Constants.GUI.Labels.NotAvailable, $"{purpose} {type}"));
            input.SelectedIndex = 0;
            return true;
        }
        else if (filteredUnits.Count > 0)
        {
            input.DataSource = filteredUnits;
            input.DisplayMember = Constants.GUI.ComboBox.DisplayName;         
        }

        return false;// returns if it was emptied (for other controls to know)
    }
    internal static void CleanTextBoxText(TextBox txtBox, IEnumerable<Func<string, string>> cleaners, Action? onChanged = null)
    {
        if (txtBox == null || cleaners == null) return;

        if (txtBox.Tag is bool isFixing && isFixing) return;

        txtBox.Tag = true;

        int caret = txtBox.SelectionStart;
        string text = txtBox.Text;

        foreach (var cleaner in cleaners)
            text = cleaner(text);

        if (txtBox.Text != text)
        {
            txtBox.Text = text;
            int newCaret = Math.Max(0, caret - 1);
            txtBox.SelectionStart = Math.Min(newCaret, text.Length);
        }

        txtBox.Tag = false;
        onChanged?.Invoke();
    }
    internal static void CleanTextBoxImage(TextBox txtBox, IEnumerable<Func<byte[], string>> cleaners)
    {
        using Image? img = Clipboard.GetImage();
        if (img is null) return;

        byte[]? imgBytes = ImageToBytes(img);
        if (imgBytes is null) return;

        byte[] image = imgBytes;
        string text = string.Empty;
        foreach (var cleaner in cleaners)
        {
            text = cleaner(image);
        }

        if (txtBox.Text != text)
            txtBox.Text = text;
    }
    internal static void CopyToClipboard(string text)
    {
        if (string.IsNullOrEmpty(text))
            return;

        Clipboard.SetText(Clean.Text(text));
    }
    internal static byte[] ImageToBytes(Image image)
    {
        using var ms = new MemoryStream();
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        return ms.ToArray();
    }
}
