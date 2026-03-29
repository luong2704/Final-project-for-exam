# Testing Patterns

**Analysis Date:** 2026-03-28

## Test Framework Status

**No test project detected in this codebase.**

The project currently has:
- No `.Tests.csproj` file
- No test project directory
- No test framework packages (xUnit, NUnit, MSTest, Moq) in `Campus.csproj`

## Project Analysis

### Main Project
- **Location:** `D:\Workspace\dotNET\Final-project-for-exam\Campus.csproj`
- **Type:** .NET MAUI Application
- **Target Framework:** `net10.0-windows10.0.19041.0`

### Current Dependencies
```xml
<PackageReference Include="CommunityToolkit.Mvvm" Version="8.4.0" />
<PackageReference Include="Microsoft.Maui.Controls" Version="$(MauiVersion)" />
<PackageReference Include="Microsoft.Extensions.Logging.Debug" Version="10.0.0" />
```

### Source Files
- `App.xaml.cs` - Application entry point
- `AppShell.xaml.cs` - Shell navigation
- `MainPage.xaml.cs` - Main counter page
- `Views/LoginPage.xaml.cs` - Login page code-behind
- `Views/ProfilePage.xaml` - Profile page (XAML only)
- `MauiProgram.cs` - MAUI app configuration
- `Finals.cs` - Placeholder class (empty implementation)

## Recommendations

### 1. Add Test Project

Create a separate test project:
```bash
dotnet new xunit -n Campus.Tests
```

Reference from main solution:
```bash
dotnet sln add Campus.Tests/Campus.Tests.csproj
dotnet add Campus.Tests/Campus.Tests.csproj reference Campus/Campus.csproj
```

### 2. Recommended Test Framework Packages

For a .NET MAUI project, use:
- **xUnit** - Modern, popular .NET testing framework
- **Moq** - Mocking framework for interfaces
- **FluentAssertions** - Better assertion syntax

Example `.csproj` for test project:
```xml
<PackageReference Include="xunit" Version="2.9.0" />
<PackageReference Include="xunit.runner.visualstudio" Version="2.8.2" />
<PackageReference Include="Moq" Version="4.20.70" />
<PackageReference Include="FluentAssertions" Version="6.12.0" />
```

### 3. Test Organization

For MAUI projects, recommended structure:
```
Campus.Tests/
├── UnitTests/
│   ├── ViewModels/
│   ├── Services/
│   └── Models/
├── IntegrationTests/
└── UITests/  (for platform-specific UI testing)
```

### 4. What to Test

Based on current codebase, priority areas for testing:
- **ViewModels** (once MVVM pattern is applied using CommunityToolkit.Mvvm)
- **Services** - Any service classes added for business logic
- **Models** - Model validation and serialization

### 5. MAUI-Specific Testing Considerations

- **Platform Code:** MAUI has platform-specific code that may require different testing approaches
- **UI Testing:** Consider Xamarin.UITest or MAUI-specific UI testing frameworks
- **Device Emulation:** Some tests may require running on device/emulator

## Current Testing Commands

Since there is no test project, no testing commands are currently available.

---

*Testing analysis: 2026-03-28*
