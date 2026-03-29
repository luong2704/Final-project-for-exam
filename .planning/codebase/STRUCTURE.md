# Codebase Structure

**Analysis Date:** 2026-03-28

## Directory Layout

```
[project-root]/
├── Campus.csproj              # Project file (single project)
├── MauiProgram.cs             # MAUI app builder configuration
├── App.xaml / App.xaml.cs    # Application entry point
├── AppShell.xaml / AppShell.xaml.cs  # Shell navigation
├── MainPage.xaml / MainPage.xaml.cs  # Default/main page
├── Finals.cs                  # Placeholder class (unused)
├── Views/                     # UI pages
│   ├── LoginPage.xaml / LoginPage.xaml.cs
│   └── ProfilePage.xaml / ProfilePage.xaml.cs
├── Resources/                 # App resources
│   ├── Images/                # Image assets
│   ├── Fonts/                 # Custom fonts
│   ├── Splash/                # Splash screen assets
│   ├── Raw/                   # Raw assets
│   └── Styles/                # XAML styles
│       ├── Colors.xaml
│       └── Styles.xaml
└── Images/                    # Additional image assets
```

## Directory Purposes

**Root Directory:**
- Purpose: Entry point and app configuration
- Contains: `MauiProgram.cs`, `App.xaml.cs`, project file
- Key files: `MauiProgram.cs`, `Campus.csproj`

**Views Directory:**
- Purpose: XAML page definitions and code-behind
- Contains: ContentPage implementations
- Key files: `Views/LoginPage.xaml`, `Views/ProfilePage.xaml`

**Resources Directory:**
- Purpose: App assets (images, fonts, styles)
- Contains: Image files, font files, XAML resource dictionaries
- Key files: `Resources/Styles/Colors.xaml`, `Resources/Styles/Styles.xaml`

## Key File Locations

**Entry Points:**
- `MauiProgram.cs`: MAUI app builder - configures services, fonts, logging
- `App.xaml.cs`: Application class - creates the main window

**Configuration:**
- `Campus.csproj`: Project configuration, NuGet packages, target frameworks
- `App.xaml`: Application resources, merged resource dictionaries

**Core Logic:**
- `Views/`: All UI pages (currently LoginPage, ProfilePage)
- `AppShell.xaml`: Shell navigation container

**Testing:**
- No test project present

## Naming Conventions

**Files:**
- XAML files: PascalCase (`LoginPage.xaml`, `ProfilePage.xaml`)
- Code-behind: Match XAML file (`LoginPage.xaml.cs`)
- Resource dictionaries: PascalCase (`Colors.xaml`, `Styles.xaml`)

**Directories:**
- PascalCase: `Views`, `Resources`, `Images`, `Fonts`, `Styles`
- No underscores or hyphens

**Namespaces:**
- Root: `Campus`
- Views: `Campus.Views`
- Pattern: Folder name matches namespace segment

## Where to Add New Code

**New Feature/Page:**
- Implementation: `Views/NewFeaturePage.xaml` + `.xaml.cs`
- Namespace: `Campus.Views`
- Navigation: Add route to `AppShell.xaml`

**New ViewModel (recommended for MVVM):**
- Implementation: `ViewModels/NewFeatureViewModel.cs`
- Namespace: `Campus.ViewModels`
- Pattern: Inherit from `ObservableObject` (CommunityToolkit.Mvvm)

**New Model:**
- Implementation: `Models/ModelName.cs`
- Namespace: `Campus.Models`

**New Service:**
- Implementation: `Services/ServiceName.cs`
- Namespace: `Campus.Services`
- Registration: Add to `MauiProgram.cs` builder

**New Resource:**
- Styles: `Resources/Styles/`
- Images: `Resources/Images/`
- Fonts: `Resources/Fonts/`

## Special Directories

**Resources/Styles:**
- Purpose: XAML resource dictionaries for colors and styles
- Files: `Colors.xaml`, `Styles.xaml`
- Usage: Merged in `App.xaml`

**Views:**
- Purpose: All ContentPage implementations
- Pattern: XAML + code-behind partial class

**Images:**
- Purpose: App icon and image assets
- Contains: `ictu.png` (referenced in XAML)

---

*Structure analysis: 2026-03-28*
