using ColorExtension.Core;
using ColorExtension.Models;

namespace ColorExtension.Tests;

public class ColorConverterTests
{
    [Fact]
    public void FromHex_CreatesColorUsingFactory()
    {
        var parser = new HexColorParser();
        var factory = new FakeColorFactory();

        var converter = new ColorConverter<FakeColor>(parser, factory);

        var color = converter.FromHex("#FF2196F3");

        Assert.Equal(new FakeColor(255, 33, 150, 243), color);
    }

    [Fact]
    public void ToHex_WithReverseConverter_Works()
    {
        var parser = new HexColorParser();
        var factory = new FakeColorFactory();

        var converter =
            new ColorConverter<FakeColor>(
                parser,
                factory,
                c => new Rgba(c.A, c.R, c.G, c.B));

        var hex = converter.ToHex(new FakeColor(255, 33, 150, 243));

        Assert.Equal("#2196F3", hex);
    }

    [Fact]
    public void ToHex_WithoutReverse_Throws()
    {
        var parser = new HexColorParser();
        var factory = new FakeColorFactory();

        var converter = new ColorConverter<FakeColor>(parser, factory);

        Assert.Throws<NotSupportedException>(() => converter.ToHex(default));
    }
}
