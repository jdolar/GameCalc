namespace UI.Windows.Helpers;
public static class Extensions
{
    public static void ConfigureTooltip(this ToolTip tooltip)
    {
        tooltip.InitialDelay = 0;
        tooltip.ReshowDelay = 0;
        tooltip.AutoPopDelay = 8000;
        tooltip.ShowAlways = true;
    }
}
