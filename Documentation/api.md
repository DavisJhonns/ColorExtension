# API Documentation

This document describes the public API exposed by **ColorExtension**, including abstractions, core implementations, and models.

---

## Namespace: `ColorExtension.Abstractions`

### `IColorConverter<TColor>`

Provides high-level conversion between hexadecimal color strings and platform-specific color types.

```csharp
public interface IColorConverter<TColor>
{
    TColor FromHex(string hex);
    bool TryFromHex(string hex, out TColor color);
    string ToHex(TColor color, bool includeAlpha = false);
}
```

#### Methods

##### `FromHex(string hex)`

Converts a hex color string into a `TColor` instance.

* Supports `#RRGGBB` and `#AARRGGBB`
* Throws if the hex string is invalid

**Parameters**

* `hex` — A hexadecimal color string

**Returns**

* A platform-specific color instance

**Exceptions**

* `ArgumentException`
* `FormatException`

---

##### `TryFromHex(string hex, out TColor color)`

Attempts to convert a hex string into a color without throwing.

**Returns**

* `true` if conversion succeeded
* `false` otherwise

---

##### `ToHex(TColor color, bool includeAlpha = false)`

Converts a color instance back into a hexadecimal string.

**Parameters**

* `color` — The color instance to convert
* `includeAlpha` — Whether to include the alpha channel

**Returns**

* A hex color string

**Exceptions**

* `NotSupportedException` if reverse conversion is not configured

---

### `IColorFactory<TColor>`

Creates platform-specific color instances from RGBA values.

```csharp
public interface IColorFactory<TColor>
{
    TColor Create(Rgba rgba);
}
```

#### Purpose

This abstraction isolates framework-specific color creation logic from the core library.

---

### `IHexColorParser`

Parses hexadecimal color strings into RGBA values.

```csharp
public interface IHexColorParser
{
    Rgba Parse(string hex);
    bool TryParse(string hex, out Rgba rgba);
}
```

#### Notes

* Parsing is independent of color types
* Consumers may replace this with custom implementations

---

## Namespace: `ColorExtension.Core`

### `ColorConverter<TColor>`

Default implementation of `IColorConverter<TColor>`.

```csharp
public sealed class ColorConverter<TColor> : IColorConverter<TColor>
```

#### Constructor

```csharp
public ColorConverter(
    IHexColorParser parser,
    IColorFactory<TColor> factory,
    Func<TColor, Rgba>? reverse = null)
```

**Parameters**

* `parser` — Parses hex strings into RGBA values
* `factory` — Creates `TColor` instances
* `reverse` — Optional function for reverse conversion

#### Behavior

* `FromHex` and `TryFromHex` always work
* `ToHex` requires the `reverse` function
* Reverse conversion is intentionally opt-in

---

### `HexColorParser`

Default hex color parser implementation.

```csharp
public sealed class HexColorParser : IHexColorParser
```

#### Supported Formats

* `#RRGGBB`
* `#AARRGGBB`
* With or without the `#` prefix

#### Behavior

* Alpha defaults to `255` if not specified
* Throws on invalid format
* `TryParse` fails gracefully

---

## Namespace: `ColorExtension.Models`

### `Rgba`

Represents a color using RGBA components.

```csharp
public readonly record struct Rgba(
    byte A,
    byte R,
    byte G,
    byte B
);
```

#### Notes

* Immutable
* Platform-neutral
* Used as the internal color representation

---

## Namespace: `ColorExtension.Exceptions`

### `InvalidHexColorException`

```csharp
public sealed class InvalidHexColorException : Exception
```

Thrown to represent invalid hexadecimal color values.

> ⚠️ **Note:**
> This exception is currently not used by `HexColorParser`, which relies on standard exceptions.
> It is available for custom parsers or future extensions.

---

## Typical Usage Flow

1. Hex string is parsed into `Rgba`
2. `Rgba` is passed to an `IColorFactory<TColor>`
3. `TColor` is returned to the caller
4. Optional reverse conversion allows hex output

---

## Thread Safety

* All components are stateless
* Safe for concurrent use

---

## Extensibility Points

You can customize:

* Hex parsing rules (`IHexColorParser`)
* Color creation (`IColorFactory<TColor>`)
* Reverse conversion (`Func<TColor, Rgba>`)
