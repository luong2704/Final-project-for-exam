# Codebase Concerns

**Analysis Date:** 2026-03-28

## Missing Files

**HomePage.xaml Missing:**
- Issue: `.csproj` references `Views\HomePage.xaml` but the file does not exist
- Files: `Campus.csproj` (line 73)
- Impact: Build may fail or produce unexpected behavior
- Fix approach: Create the missing `Views/HomePage.xaml` file or remove reference from `.csproj`

## Incomplete Features

**Forgot Password:**
- Issue: Displays placeholder "coming soon" message instead of actual functionality
- Files: `Views/LoginPage.xaml.cs` (line 11)
- Impact: User experience expectation mismatch
- Fix approach: Implement password recovery flow or remove the UI element

**Profile Page:**
- Issue: XAML file exists without code-behind (`ProfilePage.xaml.cs` missing)
- Files: `Views/ProfilePage.xaml`
- Impact: Page cannot handle events or contain logic
- Fix approach: Create `Views/ProfilePage.xaml.cs` with proper code-behind

## Dead/Stub Code

**Finals.cs:**
- Issue: Empty placeholder class with no implementation
- Files: `Finals.cs`
- Impact: Confuses developers, unclear purpose
- Fix approach: Either implement functionality or remove file

## Technical Debt

**No Service Layer:**
- Issue: No separation of concerns - all logic appears in page code-behinds
- Files: All `.xaml.cs` files
- Impact: Difficult to test, maintain, and reuse code
- Fix approach: Create `Services/` folder with business logic classes

**No Data Models:**
- Issue: No domain models or entities defined
- Impact: No structured data representation
- Fix approach: Create `Models/` folder with DTOs/entities

**No Dependency Injection:**
- Issue: `MauiProgram.cs` does not register any services with the DI container
- Files: `MauiProgram.cs`
- Impact: Cannot leverage DI for testability and loose coupling
- Fix approach: Register services using `builder.Services.AddSingleton<T>()`

## Security Concerns

**Hardcoded UI Strings:**
- Issue: User-facing messages directly in code-behind
- Files: `Views/LoginPage.xaml.cs` (line 11)
- Impact: Cannot easily translate or customize without code changes
- Fix approach: Use resource files or localization system

## Error Handling

**No Exception Handling:**
- Issue: No try-catch blocks visible in any code files
- Impact: Unhandled exceptions crash the app without graceful degradation
- Fix approach: Add global exception handler in `App.xaml.cs` and per-operation try-catch

**No Validation:**
- Issue: No input validation on user forms
- Impact: Invalid data could cause crashes or corruption
- Fix approach: Implement validation attributes or manual validation

## Testing

**No Test Project:**
- Issue: No test project exists in solution
- Files: None
- Impact: Cannot verify correctness of business logic
- Fix approach: Add `Campus.Tests` project with xUnit/NUnit

## Architecture Gaps

**No API Integration:**
- Issue: No HTTP client or REST service integration
- Impact: App cannot communicate with backend services
- Fix approach: Add `HttpClient` service and API client classes

**No Authentication:**
- Issue: Login is placeholder only, no real auth flow
- Files: `Views/LoginPage.xaml.cs`
- Impact: No user identity management
- Fix approach: Implement auth service or integrate identity provider

**No Logging:**
- Issue: Only Debug-level logging enabled, no production logging
- Files: `MauiProgram.cs` (lines 18-20)
- Impact: Difficult to diagnose production issues
- Fix approach: Add proper logging framework (Serilog, Application Insights)

## Project Configuration

**Target Framework:**
- Issue: Uses `.NET 10` (preview/beta version)
- Files: `Campus.csproj` (line 4)
- Risk: Stability issues, limited library support
- Fix approach: Consider downgrading to `.NET 8` LTS

**Package Version Mismatch:**
- Issue: `Microsoft.Extensions.Logging.Debug` version 10.0.0 may not align with Maui version
- Files: `Campus.csproj` (line 69)
- Risk: Runtime compatibility issues
- Fix approach: Use consistent versioning or align with `$(MauiVersion)`

## Summary

| Category | Count | Priority |
|----------|-------|----------|
| Missing Files | 2 | High |
| Incomplete Features | 2 | High |
| Technical Debt | 3 | Medium |
| Security | 1 | Low |
| Error Handling | 2 | Medium |
| Testing | 1 | High |
| Architecture Gaps | 3 | High |

---

*Concerns audit: 2026-03-28*
