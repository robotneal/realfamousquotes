using SixLabors;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;
using System.IO;

namespace Quotes;

public class ImageWriter
{
    private readonly Random _rnd;
    public ImageWriter(Random rnd)
    {
        _rnd = rnd;
    }

    public async Task<byte[]> GenerateImage(Author author, string quote)
    {
        var authorNameAndDate = $"{author.DisplayName} - {_rnd.Next(author.YearFrom, author.YearTo)}";
        using var img = await Image.LoadAsync($"{author.Name}.jpg");


        FontCollection collection = new();
        var family = collection.Add("Gabrielle.ttf");
        var font = family.CreateFont(45, FontStyle.Regular);
        var subfont = family.CreateFont(32, FontStyle.Italic);

        img.Mutate(x => x.DrawText($"\"{quote}\"", font, Color.White, new PointF(10, 580)));

        var quoteSize = TextMeasurer.Measure(quote, new TextOptions(font));
        var authorSize = TextMeasurer.Measure(authorNameAndDate, new TextOptions(subfont));

        img.Mutate(x => x.DrawText(authorNameAndDate, subfont, Color.White, new PointF(GetSubLeft(quoteSize.Right - authorSize.Width), 640)));

        using var mem = new MemoryStream();
        await img.SaveAsPngAsync(mem);

        var result = mem.ToArray();
        return result;
    }

    private float GetSubLeft(float x) => x < 10f ? 10f : x;
}
