using System.Globalization;
using ColorExtension.Abstractions;
using ColorExtension.Models;

namespace ColorExtension.Core;

/// <summary>
/// Default implementation of <see cref="IHexColorParser"/> that parses
/// hexadecimal color strings into RGBA values.
/// </summary>
public sealed class HexColorParser : IHexColorParser
{
    /// <inheritdoc />
    public Rgba Parse(string hex)
    {
        if (string.IsNullOrWhiteSpace(hex))
            throw new ArgumentException("Hex string is null or empty.", nameof(hex));

        hex = hex.TrimStart('#');

        if (hex.Length != 6 && hex.Length != 8)
            throw new FormatException("Hex color must be 6 or 8 characters long.");

        byte a = 255;
        int index = 0;

        if (hex.Length == 8)
        {
            a = byte.Parse(hex[..2], NumberStyles.HexNumber);
            index = 2;
        }

        byte r = byte.Parse(hex.Substring(index, 2), NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(index + 2, 2), NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(index + 4, 2), NumberStyles.HexNumber);

        return new Rgba(a, r, g, b);
    }

    /// <inheritdoc />
    public bool TryParse(string hex, out Rgba rgba)
    {
        try
        {
            rgba = Parse(hex);
            return true;
        }
        catch
        {
            rgba = default;
            return false;
        }
    }
}
