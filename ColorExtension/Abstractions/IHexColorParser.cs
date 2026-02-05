using ColorExtension.Models;

namespace ColorExtension.Abstractions;

/// <summary>
/// Provides functionality for parsing hexadecimal color strings into RGBA values.
/// </summary>
public interface IHexColorParser
{
    /// <summary>
    /// Parses a hexadecimal color string into an <see cref="Rgba"/> value.
    /// </summary>
    /// <param name="hex">
    /// A hexadecimal color string (for example, <c>#RRGGBB</c> or <c>#AARRGGBB</c>).
    /// </param>
    /// <returns>
    /// An <see cref="Rgba"/> value representing the parsed color.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="hex"/> is null or empty.
    /// </exception>
    /// <exception cref="FormatException">
    /// Thrown when <paramref name="hex"/> is not a valid hexadecimal color.
    /// </exception>
    Rgba Parse(string hex);

    /// <summary>
    /// Attempts to parse a hexadecimal color string into an <see cref="Rgba"/> value.
    /// </summary>
    /// <param name="hex">
    /// A hexadecimal color string.
    /// </param>
    /// <param name="rgba">
    /// When this method returns <see langword="true"/>, contains the parsed RGBA value;
    /// otherwise, contains the default value.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if parsing succeeds; otherwise, <see langword="false"/>.
    /// </returns>
    bool TryParse(string hex, out Rgba rgba);
}
