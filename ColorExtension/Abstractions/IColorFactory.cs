using ColorExtension.Models;

namespace ColorExtension.Abstractions;

/// <summary>
/// Creates platform-specific color instances from RGBA values.
/// </summary>
/// <typeparam name="TColor">
/// The color type produced by the factory.
/// </typeparam>
public interface IColorFactory<TColor>
{
    /// <summary>
    /// Creates a new <typeparamref name="TColor"/> instance
    /// from the specified RGBA components.
    /// </summary>
    /// <param name="rgba">
    /// The RGBA color values used to create the color instance.
    /// </param>
    /// <returns>
    /// A new color instance corresponding to the specified RGBA values.
    /// </returns>
    TColor Create(Rgba rgba);
}
