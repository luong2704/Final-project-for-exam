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
- **End**: March 14, 2026 (v1.0)
- **Current**: v1.1 - UI Optimization

### Technical Stack

- **Framework**: .NET MAUI
- **Target**: net10.0-windows10.0.19041.0
- **Pattern**: MVVM
- **Package**: CommunityToolkit.Mvvm

### Git Branches

```
main
  └── team6-event-categories
      ├── quanghai2k4-leader (Model + Interface + Coordination)
      ├── caoanh10-frontend (View + ViewModel)
      └── Nguyenvu32-backend (Service + Logic + Testing)
```

### Commit Convention

Format: `<type>: <short description> on <file>`

Examples:
- `fix: fix route navigation on AppShell.xaml`
- `ui: add dynamic empty state on CategoryFilterView.xaml`
- `logic: add loading indicator on CategoryViewModel.cs`
- `docs: update project documentation`

---

## Current Milestone: v1.1 - UI Optimization

**Goal:** Cải thiện trải nghiệm người dùng và chức năng lọc sự kiện theo danh mục

**Target features:**
- Fix route navigation (CategoryFilterView route mismatch với AppShell)
- Tối ưu UI: dynamic empty state, visual feedback
- Cải thiện filter functionality
- Performance optimization

---

## Evolution

This document evolves at phase transitions and milestone boundaries.

**After each phase transition** (via `/gsd-transition`):
1. Requirements invalidated? → Move to Out of Scope with reason
2. Requirements validated? → Move to Validated with phase reference
3. New requirements emerged? → Add to Active
4. Decisions to log? → Add to Key Decisions
5. "What This Is" still accurate? → Update if drifted

**After each milestone** (via `/gsd-complete-milestone`):
1. Full review of all sections
2. Core Value check — still the right priority?
3. Audit Out of Scope — reasons still valid?
4. Update Context with current state

---

## Last Updated

2026-03-31 - Milestone v1.1 started
