# Platform Examples

This document shows how to integrate ColorExtension with common .NET platforms.

---

## .NET MAUI

```csharp
using Microsoft.Maui.Graphics;

public sealed class MauiColorFactory : IColorFactory<Color>
{
    public Color Create(Rgba rgba)
        => Color.FromRgba(rgba.R, rgba.G, rgba.B, rgba.A);
}
```

```csharp
var converter = new ColorConverter<Color>(
    new HexColorParser(),
    new MauiColorFactory(),
    color => new Rgba(
        (byte)(color.Alpha * 255),
        (byte)(color.Red * 255),
        (byte)(color.Green * 255),
        (byte)(color.Blue * 255)
    )
);
```

## WPF (System.Windows.Media.Color)

```csharp
using System.Windows.Media;

public sealed class WpfColorFactory : IColorFactory<Color>
{
    public Color Create(Rgba rgba)
        => Color.FromArgb(rgba.A, rgba.R, rgba.G, rgba.B);
}
```

```csharp
var converter = new ColorConverter<Color>(
    new HexColorParser(),
    new WpfColorFactory(),
    color => new Rgba(color.A, color.R, color.G, color.B)
);
```

## WinUI / UWP

```csharp
using Windows.UI;

public sealed class WinUIColorFactory : IColorFactory<Color>
{
    public Color Create(Rgba rgba)
        => Color.FromArgb(rgba.A, rgba.R, rgba.G, rgba.B);
}
```

## System.Drawing

```csharp
using System.Drawing;

public sealed class DrawingColorFactory : IColorFactory<Color>
{
    public Color Create(Rgba rgba)
        => Color.FromArgb(rgba.A, rgba.R, rgba.G, rgba.B);
}
```

## Custom Domain Color

```csharp
public record MyColor(byte A, byte R, byte G, byte B);

public sealed class MyColorFactory : IColorFactory<MyColor>
{
    public MyColor Create(Rgba rgba)
        => new(rgba.A, rgba.R, rgba.G, rgba.B);
}
```