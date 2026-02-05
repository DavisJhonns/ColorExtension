# Architecture

ColorExtension is designed around a small set of composable abstractions that separate **color parsing**, **color creation**, and **conversion orchestration**.

The goal is to support hex color conversion **without introducing platform dependencies** or forcing consumers into a specific color model.

---

## Core Problem

In .NET ecosystems, color types are fragmented:

- `System.Drawing.Color`
- `Microsoft.Maui.Graphics.Color`
- `Windows.UI.Color`
- Custom domain-specific color models

Each platform represents colors differently, yet hex color strings (`#RRGGBB`, `#AARRGGBB`) are universal.

ColorExtension bridges this gap by:
- Parsing hex once
- Delegating color creation to the consumer
- Remaining completely platform-agnostic

---

## Key Abstractions

### `IHexColorParser`

Responsible for converting hex strings into a neutral RGBA representation.

**Why it exists**
- Parsing rules are independent of color types
- Keeps string parsing logic isolated and testable
- Allows alternative parsers if formats change

---

### `Rgba`

A simple, immutable value type representing color components.

**Why it exists**
- Acts as a shared contract between parsing and color creation
- Avoids leaking platform color models into core logic
- Makes testing and debugging trivial

---

### `IColorFactory<TColor>`

Responsible for creating platform-specific color instances from RGBA values.

**Why it exists**
- Color creation is platform-specific
- Keeps framework references out of the core library
- Encourages explicit mapping between RGBA and target color types

---

### `IColorConverter<TColor>`

High-level API that orchestrates parsing and color creation.

**Why it exists**
- Provides a simple consumer-facing interface
- Centralizes error handling and conversion logic
- Allows optional reverse conversion (color → hex)

---

## Composition over Inheritance

ColorExtension avoids base classes and static helpers in favor of:
- Constructor injection
- Explicit dependencies
- Clear responsibility boundaries

This makes the library:
- Easy to extend
- Easy to test
- Easy to integrate into DI containers

---

## Optional Reverse Conversion

Reverse conversion is intentionally optional.

Not all color types:
- Expose RGBA components
- Preserve original alpha values
- Represent colors losslessly

By requiring an explicit reverse function, ColorExtension avoids unsafe assumptions.
