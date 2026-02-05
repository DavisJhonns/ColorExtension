namespace ColorExtension.Abstractions;

/// <summary>
/// Defines methods for converting between hexadecimal color strings
/// and platform-specific color types.
/// </summary>
/// <typeparam name="TColor">
/// The color type used by the target platform or framework.
/// </typeparam>
public interface IColorConverter<TColor>
{
    /// <summary>
    /// Converts a hexadecimal color string into a <typeparamref name="TColor"/> instance.
    /// </summary>
    /// <param name="hex">
    /// A hexadecimal color string (for example, <c>#RRGGBB</c> or <c>#AARRGGBB</c>).
    /// </param>
    /// <returns>
    /// A color instance created from the specified hexadecimal value.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="hex"/> is null or empty.
    /// </exception>
    /// <exception cref="FormatException">
    /// Thrown when <paramref name="hex"/> is not a valid hexadecimal color.
    /// </exception>
    TColor FromHex(string hex);

    /// <summary>
    /// Attempts to convert a hexadecimal color string into a <typeparamref name="TColor"/> instance.
    /// </summary>
    /// <param name="hex">
    /// A hexadecimal color string (for example, <c>#RRGGBB</c> or <c>#AARRGGBB</c>).
    /// </param>
    /// <param name="color">
    /// When this method returns <see langword="true"/>, contains the converted color;
    /// otherwise, contains the default value of <typeparamref name="TColor"/>.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the conversion succeeds; otherwise, <see langword="false"/>.
    /// </returns>
    bool TryFromHex(string hex, out TColor color);

    /// <summary>
    /// Converts a <typeparamref name="TColor"/> instance into a hexadecimal color string.
    /// </summary>
    /// <param name="color">
    /// The color value to convert.
    /// </param>
    /// <param name="includeAlpha">
    /// <see langword="true"/> to include the alpha channel in the resulting string;
    /// otherwise, <see langword="false"/>.
    /// </param>
    /// <returns>
    /// A hexadecimal color string representing the specified color.
    /// </returns>
    /// <exception cref="NotSupportedException">
    /// Thrown when reverse conversion is not configured.
    /// </exception>
    string ToHex(TColor color, bool includeAlpha = false);
}
