# External Integrations

**Analysis Date:** 2026-03-28

## APIs & External Services

**No external APIs detected:**
- Application does not integrate with any third-party APIs
- No HTTP client configurations found
- No REST API service references

## Data Storage

**Databases:**
- None detected - No database providers (SQL Server, SQLite, PostgreSQL, etc.)
- No ORM packages (Entity Framework, Dapper, etc.)

**File Storage:**
- Local filesystem only
- App uses MAUI resource system for images, fonts, and assets
- Resources located in `Resources/` directory

**Caching:**
- None - No caching frameworks detected

## Authentication & Identity

**Auth Provider:**
- None - Custom authentication not implemented
- Login page (`Views/LoginPage.xaml.cs`) contains stub for "Forgot Password" feature
- No authentication libraries (Auth0, Firebase Auth, Microsoft Identity, etc.)

## Monitoring & Observability

**Error Tracking:**
- None - No error tracking services integrated
- Only basic debug logging via `Microsoft.Extensions.Logging.Debug`

**Logs:**
- Debug logging to Visual Studio Output window
- No external logging services (Serilog, NLog, Application Insights, etc.)

## CI/CD & Deployment

**Hosting:**
- Not specified - Standard .NET MAUI deployment targets apply
- Can deploy to: Microsoft Store, sideloading, or platform-specific stores

**CI Pipeline:**
- None detected - No GitHub Actions, Azure DevOps, or other CI configurations

## Environment Configuration

**Required env vars:**
- None detected - No environment variables referenced

**Secrets location:**
- None - No secrets management implemented

## Webhooks & Callbacks

**Incoming:**
- None - No webhook endpoints

**Outgoing:**
- None - No outgoing HTTP calls to external services

## Summary

This is a **standalone .NET MAUI application** with no external integrations. The application:
- Does not connect to any backend API
- Does not use any database
- Does not integrate with cloud services
- Does not implement authentication
- Uses only local resources (fonts, images) bundled with the app

The only "integration" is with the MAUI framework itself and the CommunityToolkit.Mvvm package for MVVM pattern support.

---

*Integration audit: 2026-03-28*
