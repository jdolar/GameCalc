using Data;
using Data.Commands;
using System.Drawing.Imaging;
namespace UI.Windows.Helpers;

internal sealed class OcrImageInfo
{
    public string Path { get; set; } = string.Format("{0}\\{1}_{2}.{3}", AppDomain.CurrentDomain.BaseDirectory, "test_image", DateTime.Now.Ticks.ToString(), "png");
    public bool SaveCopy { get; set; } = false;
    public string Text { get; set; } = "5,234,643,322";
    public Font TextFont { get; set; } = new Font("Arial", 10, FontStyle.Bold);
    public Color TextColour { get; set; } = Color.White;
    public Color Background { get; set; } = Color.Black;
    public int Width { get; set; } = 200;
    public int Height { get; set; } = 50;
}
internal static class OcrMock
{
    /// <summary>
    /// Generates a clean test image with numbers and returns it as byte[]
    /// </summary>
    public static byte[] GenerateNumberImage(OcrImageInfo? imageInfo = null)
    {
        imageInfo ??= new OcrImageInfo();

        using var bmp = new Bitmap(imageInfo.Width, imageInfo.Height);
        using var g = Graphics.FromImage(bmp);

        g.Clear(imageInfo.Background);
        using var font = imageInfo.TextFont;
        using var brush = new SolidBrush(imageInfo.TextColour);

        var size = g.MeasureString(imageInfo.Text, font);

        float x = (imageInfo.Width - size.Width) / 2;
        float y = (imageInfo.Height - size.Height) / 2;
        g.DrawString(imageInfo.Text, font, brush, x, y);

        using var ms = new MemoryStream();
        bmp.Save(ms, ImageFormat.Png);

        if (imageInfo.SaveCopy)
        {
            using var fs = new FileStream(imageInfo.Path, FileMode.Create, FileAccess.Write);
            bmp.Save(fs, ImageFormat.Png);
        }

        return ms.ToArray();
    }
    public static string CleanImageFromMemoryMock()
    {
        OcrImageInfo info = new()
        {
            Path = Path.Combine(Constants.Files.DataDirectory, string.Format("testImage_{0}.png", DateTime.Now.Ticks.ToString())),
            Text = "1234567890",
            TextFont = new Font("Arial", 10),
            TextColour = Color.White,
            Background = Color.Black,
            Width = 180,
            Height = 11,
            SaveCopy = true
        };


        byte[] img = OcrMock.GenerateNumberImage(info);
        string ocrResult = Clean.Image(img);

        return ocrResult;
    }
    public static string CleanImageFromFileMock(string? path = null)
    {
        path ??= Path.Combine(Constants.Files.DataDirectory, string.Format("testImage_{0}.png", DateTime.Now.Ticks.ToString()));
        string ocrResult = Clean.ImageFromFile(path);

        return ocrResult;
    }
}

