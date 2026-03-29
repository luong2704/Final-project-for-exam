# Architecture

**Analysis Date:** 2026-03-28

## Pattern Overview

**Overall:** MVVM (Model-View-ViewModel) with .NET MAUI

**Key Characteristics:**
- Cross-platform mobile application using .NET MAUI framework
- XAML-based UI with code-behind pattern
- Shell-based navigation for routing
- CommunityToolkit.Mvvm included for MVVM support (not yet actively used)

## Layers

**Presentation Layer:**
- Location: `Views/`
- Contains: XAML pages and code-behind files
- Examples: `Views/LoginPage.xaml`, `Views/ProfilePage.xaml`
- Used by: AppShell navigation

**Application Layer:**
- Location: Root namespace (`Campus`)
- Contains: `App.xaml.cs`, `MauiProgram.cs`, `AppShell.xaml.cs`
- Responsibilities: App initialization, DI configuration, Shell navigation setup
- Depends on: Microsoft.Extensions.DependencyInjection

**Entry Point:**
- Location: `App.xaml.cs`
- Triggers: Application startup
- Responsibilities: Window creation, Shell initialization

## Data Flow

**Navigation Flow:**
1. App starts → `App.xaml.cs` creates `Window(new AppShell())`
2. AppShell loads → navigates to default page
3. User interacts → XAML event handlers in code-behind execute

**State Management:**
- Uses MAUI's built-in state management via XAML bindings
- CommunityToolkit.Mvvm available for `ObservableObject`, `[ObservableProperty]` source generators
- Currently: No explicit ViewModels implemented

## Key Abstractions

**Shell Navigation:**
- Purpose: Declarative routing and flyout navigation
- Location: `AppShell.xaml`
- Pattern: Shell-based navigation with routes

**ContentPage:**
- Purpose: Individual screens/pages
- Examples: `LoginPage`, `ProfilePage`
- Pattern: XAML + code-behind (partial class)

## Entry Points

**MauiProgram.cs:**
- Location: `MauiProgram.cs`
- Responsibilities: MAUI app builder configuration, font setup, logging configuration
- Pattern: Fluent builder pattern

**App.xaml.cs:**
- Location: `App.xaml.cs`
- Responsibilities: Application initialization, window creation
- Pattern: Application base class

## Error Handling

**Strategy:** Try-catch in event handlers, DisplayAlert for user feedback

**Patterns:**
- `try-catch` blocks in async event handlers
- `DisplayAlert` for showing errors to users
- `SemanticScreenReader` for accessibility announcements

## Cross-Cutting Concerns

**Logging:** Microsoft.Extensions.Logging with Debug provider (Debug builds only)

**Validation:** XAML-based validation (input types like `Keyboard="Email"`)

**Authentication:** Placeholder UI in LoginPage (not implemented)

---

*Architecture analysis: 2026-03-28*
