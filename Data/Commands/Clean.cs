using Tesseract;
namespace Data.Commands;
public static class Clean
{
    public static string Text(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;

        int len = input.Length;

       
        if (len <= 1_000_000) 
        {
            Span<char> buffer = stackalloc char[len];
            int idx = 0;
            for (int i = 0; i < len; i++)
            {
                char c = input[i];
                if ((uint)(c - '0') <= 9) buffer[idx++] = c;
            }
            return new string(buffer[..idx]);
        }
        else 
        {
            char[] buffer = new char[len];
            int idx = 0;
            for (int i = 0; i < len; i++)
            {
                char c = input[i];
                if ((uint)(c - '0') <= 9) buffer[idx++] = c;
            }
            return new string(buffer, 0, idx);
        }
    }
    public static string Image(byte[]? image)
    {
        if (image == null || image.Length == 0)
            return string.Empty;        

        using var engine = new TesseractEngine(Constants.Files.TessDataLocation, "eng", EngineMode.Default);
        using var img = Pix.LoadFromMemory(image);
        using var page = engine.Process(img);

        return page.GetText().Trim();
    }
    public static string ImageFromFile(string filePath)
    {
        using var engine = new TesseractEngine(Constants.Files.TessDataLocation, "eng", EngineMode.Default);
        using var img = Pix.LoadFromFile(filePath);
        using var page = engine.Process(img);

        return page.GetText().Trim();
    }
}
