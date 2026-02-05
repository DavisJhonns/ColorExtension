using ColorExtension.Abstractions;
using ColorExtension.Models;

namespace ColorExtension.Core;

/// <summary>
/// Default implementation of <see cref="IColorConverter{TColor}"/> that
/// converts between hexadecimal strings and platform-specific color types
/// using injected parsing and factory components.
/// </summary>
/// <typeparam name="TColor">
/// The platform-specific color type.
/// </typeparam>
public sealed class ColorConverter<TColor> : IColorConverter<TColor>
{
    private readonly IHexColorParser _parser;
    private readonly IColorFactory<TColor> _factory;
    private readonly Func<TColor, Rgba>? _reverse;

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorConverter{TColor}"/> class.
    /// </summary>
    /// <param name="parser">
    /// The parser used to convert hexadecimal strings into RGBA values.
    /// </param>
    /// <param name="factory">
    /// The factory used to create color instances from RGBA values.
    /// </param>
    /// <param name="reverse">
    /// Optional function used to convert a color instance back into RGBA values.
    /// Required for hexadecimal output.
    /// </param>
    public ColorConverter(
        IHexColorParser parser,
        IColorFactory<TColor> factory,
        Func<TColor, Rgba>? reverse = null)
    {
        _parser = parser;
        _factory = factory;
        _reverse = reverse;
    }

    /// <inheritdoc />
    public TColor FromHex(string hex)
    {
        var rgba = _parser.Parse(hex);
        return _factory.Create(rgba);
    }

    /// <inheritdoc />
    public bool TryFromHex(string hex, out TColor color)
    {
        if (_parser.TryParse(hex, out var rgba))
        {
            color = _factory.Create(rgba);
            return true;
        }

        color = default!;
        return false;
    }

    /// <inheritdoc />
    public string ToHex(TColor color, bool includeAlpha = false)
    {
        if (_reverse == null)
            throw new NotSupportedException("Reverse conversion is not configured.");

        var rgba = _reverse(color);

        return includeAlpha
            ? $"#{rgba.A:X2}{rgba.R:X2}{rgba.G:X2}{rgba.B:X2}"
            : $"#{rgba.R:X2}{rgba.G:X2}{rgba.B:X2}";
    }
}
