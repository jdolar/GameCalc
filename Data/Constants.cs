using Data.Models;

namespace Data;

public static class Constants
{
    public static class Files
    {
        public const string TessDataLocation = "C:\\Program Files\\Tesseract-OCR\\tessdata";
        public const string DataDirectory = "C:\\Users\\InR\\Desktop";
    }
    public static class GUI
    {
        public static class ComboBox
        {
            public const string DisplayName = "Name";
        }
        public static class Labels
        {
            public const string TheCalc = "GetGot";
            public const string UpCalc = "Unit Production";
            public const string SimpleCalc = "Simple";
            public const string Strenght = nameof(Strenght);
            public const string Purpose = nameof(Purpose);
            public const string Type = nameof(Type);
            public const string SelectedItem = "Selected";
            public const string CostPerUnit = "Cost/Unit(buy)";
            public const string CostPerUnitReassign = "Cost/Unit(reassign)";
            public const string CostToBuy = "Cost to Buy";
            public const string CostToReassign = "Cost to Reassign";
            public const string AbleTobuy = "Able to Buy";
            public const string CurrentUp = "Current Unit Production";
            public const string DesiredUp = "Desired Unit Production";
            public const string ResourcesToSpend = " to spend on UP";
        }
        public static class Results
        {
            public const string UpToBuy = "UP to Buy";
            public const string UpToReassign = "UP to Reassign";
            public const string TotalUp = "Total UP";
        }
    }
}
