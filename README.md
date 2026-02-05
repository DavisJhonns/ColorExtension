# ColorExtension

A lightweight, platform-agnostic color conversion library for .NET.

**ColorExtension** provides a clean abstraction for converting hexadecimal color strings into strongly-typed color objects — and back again — without tying your code to a specific UI framework or platform.

## Why ColorExtension?

- **Platform-agnostic** works with any color type
- **Dependency-injection friendly**
- **Optional reverse conversion** (color → hex)
- **Testable** by design
- **Minimal API surface**

If you’ve ever wanted to convert `#FF5733` into a `System.Drawing.Color`, `Microsoft.Maui.Graphics.Color`, or your own custom color type without hard-coding framework logic this is for you.

---

## Installation

```bash
dotnet add package ColorExtension --version 1.0.0
