namespace ColorExtension.Exceptions;

/// <summary>
/// Represents an error that occurs when a hexadecimal color value is invalid.
/// </summary>
public sealed class InvalidHexColorException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidHexColorException"/> class.
    /// </summary>
    /// <param name="hex">
    /// The invalid hexadecimal color string.
    /// </param>
    public InvalidHexColorException(string hex)
        : base($"Invalid hex color value: {hex}")
    {
    }
}
