namespace ColorExtension.Models;

/// <summary>
/// Represents a color using RGBA (Red, Green, Blue, Alpha) components.
/// </summary>
/// <param name="A">The alpha (opacity) component.</param>
/// <param name="R">The red component.</param>
/// <param name="G">The green component.</param>
/// <param name="B">The blue component.</param>
public readonly record struct Rgba(
    byte A,
    byte R,
    byte G,
    byte B
);
