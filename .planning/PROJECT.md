# Project Context

## Campus Activity Manager - Event Categories Module

### Overview

.NET MAUI mobile application for managing campus events with a focus on event categorization functionality.

### Team

| Role | Member | Branch |
|------|--------|--------|
| Leader | quanghai2k4 | quanghai2k4-leader |
| Frontend | caoanh10 | caoanh10-frontend |
| Backend | Nguyenvu32 | Nguyenvu32-backend |

### Timeline

- **Start**: March 3, 2026
- **End**: March 14, 2026
- **Duration**: 12 days

### Technical Stack

- **Framework**: .NET MAUI
- **Target**: net10.0-windows10.0.19041.0
- **Pattern**: MVVM
- **Package**: CommunityToolkit.Mvvm

### GitHub Issues

- **Epic**: #6 - Event Categories (assigned to quanghai2k4)
- **Sub-issues**: #39-44

### Git Branches

```
main
  └── team6-event-categories
      ├── quanghai2k4-leader (Model + Interface + Coordination)
      ├── caoanh10-frontend (View + ViewModel)
      └── Nguyenvu32-backend (Service + Logic + Testing)
```

### Key Tasks (GitHub Issues)

| Issue # | Description | Assignee | Hours |
|---------|-------------|----------|-------|
| #39 | Create Category model | quanghai2k4 | 2h |
| #40 | Implement category data source (interface) | quanghai2k4 | 2h |
| #41 | Design category filter UI | caoanh10 | 6h |
| #42 | Bind category selection to ViewModel | caoanh10 | 4h |
| #43 | Implement filtering logic | Nguyenvu32 | 4h |
| #44 | Display filtered events | caoanh10 | 3h |

### Commit Convention

Format: `<type>(#<issue>): <short description>`

Types: feat, ui, logic, service, model, test, fix, refactor, docs, chore
Scope: Use GitHub issue number (e.g., #39, #40)
