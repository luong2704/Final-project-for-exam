# Coding Conventions

**Analysis Date:** 2026-03-28

## Language & Framework

**Language:**
- C# 12+ (targeting .NET 10.0)

**Framework:**
- .NET MAUI (Microsoft.Maui.Controls)
- CommunityToolkit.Mvvm 8.4.0

## Project Configuration

**Implicit Usings:** Enabled
- `ImplicitUsings>enable</ImplicitUsings>` in `.csproj`

**Nullable Reference Types:** Enabled
- `Nullable>enable</Nullable>` in `.csproj`

**Target Framework:**
- `net10.0-windows10.0.19041.0`

## Naming Patterns

### Files
- **Classes:** PascalCase, e.g., `LoginPage.xaml.cs`, `MainPage.xaml.cs`, `AppShell.xaml.cs`
- **XAML:** PascalCase matching class name, e.g., `LoginPage.xaml`, `ProfilePage.xaml`
- **Code-behind:** PascalCase matching XAML file with `.xaml.cs` suffix

### Namespaces
- **Style:** File-scoped namespace declaration
- **Pattern:** `<RootNamespace>.<SubNamespace>`, e.g., `namespace Campus.Views;`

### Classes & Types
- **PascalCase:** All class names use PascalCase
- Examples: `LoginPage`, `MainPage`, `AppShell`, `App`, `MauiProgram`

### Methods
- **PascalCase:** All method names use PascalCase
- Examples: `OnForgotPasswordTapped`, `OnCounterClicked`, `CreateMauiApp`, `InitializeComponent`
- Event handlers follow `On<EventName>Tapped/Clicked` pattern

### Variables & Fields
- **camelCase:** Local variables and fields use camelCase
- Examples: `count`, `sender`, `e`, `builder`
- No prefix notation (no `_` prefix for private fields observed)

### Properties
- **PascalCase:** Properties follow PascalCase convention (standard C#)

## Code Style

### Formatting
- **Indentation:** Spaces (default Visual Studio / .NET MAUI template)
- **Braces:** Standard C# brace style (opening brace on same line)
- **Access Modifiers:** Explicit when non-default, omitted when default (e.g., `public class`)

### Organization
- **Using Statements:** At top of file, alphabetically sorted (file-scoped namespace)
- **Order in Classes:**
  1. Fields/properties
  2. Constructors
  3. Public methods
  4. Private methods
  5. Event handlers

### Language Features
- **Record Types:** Not currently used in codebase
- **Pattern Matching:** Not observed
- **Nullability:** Enabled via `<Nullable>enable</Nullable>`
- **Target-typed new:** Not explicitly used

## XAML Conventions

### Naming
- **Pages:** `<Name>Page` pattern, e.g., `LoginPage`, `ProfilePage`
- **Code-behind:** Partial class matching XAML root element

### Structure
- **Root Element:** `ContentPage`, `Shell`, `Application`
- **Event Binding:** Code-behind event handlers via `x:Name` or direct binding
- **Resource Dictionaries:** Separate files in `Resources/Styles/` folder

## Special Patterns

### MAUI Application Structure
- **Entry Point:** `MauiProgram.cs` with `CreateMauiApp()` static method
- **App Class:** `App.xaml.cs` inherits from `Application`
- **Shell:** `AppShell.xaml.cs` inherits from `Shell`
- **Pages:** Located in `Views/` folder, each with XAML and code-behind

### Event Handlers
- **Pattern:** `private async void On<EventName>Tapped/Clicked(object sender, EventArgs e)`
- **Example:** `private async void OnForgotPasswordTapped(object sender, EventArgs e)`

## Dependencies

**NuGet Packages:**
- `CommunityToolkit.Mvvm` (8.4.0) - MVVM toolkit
- `Microsoft.Maui.Controls` - MAUI UI framework
- `Microsoft.Extensions.Logging.Debug` (10.0.0) - Debug logging

## Recommendations

1. **Add .editorconfig:** Create `.editorconfig` to enforce consistent formatting across team
2. **Add StyleCop/Analyser:** Consider adding style analyzers for enforcement
3. **Document XAML Patterns:** Add conventions for resource usage, bindings, and converters

---

*Convention analysis: 2026-03-28*
