using System.Text.Json;
using System.Text.Json.Serialization;
namespace Data;
public static class Constants
{
    public static class Files
    {
        public const string TessDataLocation = "C:\\Program Files\\Tesseract-OCR\\tessdata";
        public const string DataDirectory = "C:\\Users\\InR\\Desktop";
    }
    public static class Json
    {
        public static readonly JsonSerializerOptions SerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };
    }
    public static class GUI
    {
        public static class ComboBox
        {
            public const string DisplayName = "Name";
        }
        public static class Hints
        {
            public const string Strength = nameof(Strength);
            public const string Purpose = nameof(Purpose);
            public const string Type = nameof(Type);
            public const string Slot = nameof(Slot);
            public const string DesiredUpPreText = "From {0}" + Labels.Up + " to reach {1} you will need...";
            public const string ResourcesToSpendPreText = "From {0} " + Labels.Up + " with {1} {2} you can upgrade to...";
            public const string MultiplierToEnter = "Multiplier to enter is {0}.";
            public const string ItWouldCost = "It would cost {0} {1} to {2} {3} {4}(s).";
            public const string YouCanBuy = "You can buy {0} {1}(s) for {2} {3}.";
            public const string CostPerUnit = "Cost/Unit(buy)";
            public const string CostPerUnitReassign = "Cost/Unit(reassign)";
        }
        public static class Labels
        {
            //Tabs
            public const string getGot = "GetGot";
            public const string UnitProduction = UP;
            public const string Simple = "Calculator";

            public const string UP = "Unit Production";
            public const string Up = "unit production";
            
            //UP Calc
            public const string CurrentUp = "Current " + UP;
            public const string DesiredUp = "Desired " + UP;
            public const string ResourcesToSpend = " to spend on " + UP;

            public const string NotAvailable = "No {0} available.";
        }
    }
}
