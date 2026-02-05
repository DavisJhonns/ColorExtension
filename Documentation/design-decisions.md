# Design Decisions

This document explains the reasoning behind key design choices in ColorExtension.

---

## Why Interfaces Instead of Static Helpers?

Static helpers:
- Are difficult to test
- Cannot be substituted
- Encourage hidden dependencies

Interfaces enable:
- Dependency injection
- Swappable implementations
- Clear responsibility boundaries

---

## Why RGBA Instead of Platform Color Types?

Platform color types:
- Differ in structure and precision
- Introduce framework dependencies
- Are not always available in non-UI contexts

`Rgba` is:
- Minimal
- Immutable
- Platform-neutral

---

## Supported Hex Formats

ColorExtension supports:
- `#RRGGBB`
- `#AARRGGBB`
- With or without the leading `#`

### Why not shorthand (`#RGB`)?

- Less explicit
- Less common in application code
- Adds parsing complexity with limited benefit

Shorthand support can be added via a custom `IHexColorParser`.

---

## Alpha Handling

- Alpha defaults to `255` (fully opaque) when not specified
- Alpha is only included in hex output when explicitly requested

```csharp
ToHex(color, includeAlpha: true)
```

This avoids surprising output like `#FFFF0000`.

---

## Why Is Reverse Conversion Optional?

Not all color types:

* Expose RGBA channels
* Preserve exact values
* Support lossless round-tripping

Requiring an explicit reverse function:

* Makes limitations visible
* Avoids unsafe assumptions
* Keeps the API honest

---

## Exceptions vs Try Methods

Both styles are supported:

* `Parse()` / `FromHex()` for fail-fast scenarios
* `TryParse()` / `TryFromHex()` for defensive parsing

This mirrors standard .NET patterns.

---

## Scope Control

ColorExtension intentionally does NOT:

* Validate CSS color names
* Handle HSL/HSV conversions
* Provide UI-specific helpers

Those concerns belong in separate, opt-in extensions.
