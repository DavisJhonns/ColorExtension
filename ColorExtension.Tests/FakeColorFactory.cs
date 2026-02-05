using ColorExtension.Abstractions;
using ColorExtension.Models;
using ColorExtension.Tests;

public sealed class FakeColorFactory : IColorFactory<FakeColor>
{
    public FakeColor Create(Rgba rgba) => new(rgba.A, rgba.R, rgba.G, rgba.B);
}
