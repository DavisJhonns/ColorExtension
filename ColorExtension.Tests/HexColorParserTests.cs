using ColorExtension.Core;
using ColorExtension.Models;

namespace ColorExtension.Tests;

public class HexColorParserTests
{
    private readonly HexColorParser _parser = new();

    [Fact]
    public void Parse_6CharHex_ReturnsCorrectRgba()
    {
        var rgba = _parser.Parse("#FF5733");

        Assert.Equal(new Rgba(255, 255, 87, 51), rgba);
    }

    [Fact]
    public void Parse_8CharHex_ReturnsCorrectRgba()
    {
        var rgba = _parser.Parse("#80FF5733");

        Assert.Equal(new Rgba(128, 255, 87, 51), rgba);
    }

    [Fact]
    public void Parse_WithoutHash_Works()
    {
        var rgba = _parser.Parse("2196F3");

        Assert.Equal(new Rgba(255, 33, 150, 243), rgba);
    }

    [Fact]
    public void Parse_InvalidLength_Throws()
    {
        Assert.Throws<FormatException>(() => _parser.Parse("123"));
    }

    [Fact]
    public void TryParse_Invalid_ReturnsFalse()
    {
        var result = _parser.TryParse("ZZZZZZ", out var rgba);

        Assert.False(result);
        Assert.Equal(default, rgba);
    }
}
