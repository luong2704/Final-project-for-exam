# Technology Stack

**Analysis Date:** 2026-03-28

## Languages

**Primary:**
- C# 10.0 - Primary programming language for all application code

**Secondary:**
- XAML - UI markup language for defining pages and UI components

## Runtime

**Environment:**
- .NET 10.0 (net10.0-windows10.0.19041.0)
- Windows 10 (minimum version 10.0.17763.0)

**Package Manager:**
- NuGet - Standard .NET package management

## Frameworks

**Core:**
- .NET MAUI (Microsoft.Maui.Controls) - Cross-platform UI framework
  - Version: Set via `$(MauiVersion)` MSBuild property
  - Purpose: Build native Android, iOS, macOS, and Windows apps from a single codebase
  - Config: `<UseMaui>true</UseMaui>` in `Campus.csproj`

**MVVM:**
- CommunityToolkit.Mvvm 8.4.0 - MVVM framework with source generators
  - Purpose: Simplify MVVM pattern implementation

**Logging:**
- Microsoft.Extensions.Logging.Debug 10.0.0 - Debug logging provider
  - Purpose: Enable debug logging during development
  - Usage: `builder.Logging.AddDebug()` in `MauiProgram.cs`

## Key Dependencies

**UI Framework:**
- Microsoft.Maui.Controls - Cross-platform UI toolkit

**MVVM:**
- CommunityToolkit.Mvvm 8.4.0 - MVVM helpers and source generators

**Logging:**
- Microsoft.Extensions.Logging.Debug - Debug logging sink

## Configuration

**Environment:**
- No appsettings.json or environment-specific configuration detected
- Configuration appears to be compile-time via MSBuild properties in `Campus.csproj`

**Build:**
- `Campus.csproj` - Main project file
- `Finals.slnx` - Solution file

## Platform Requirements

**Development:**
- .NET 10.0 SDK
- Windows 10 version 1809 or later (for Windows development)
- Visual Studio 2022 or VS Code with MAUI extension

**Production:**
- Windows 10 (10.0.17763.0+)
- Can target: Windows, Android, iOS, macOS (via MAUI)

---

*Stack analysis: 2026-03-28*
