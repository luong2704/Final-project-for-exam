# Roadmap - Event Categories Module

## Epic: #6 - Event Categories (Team 6)
## Timeline: March 3-14, 2026 (12 days)

---

## Phase 1: Data Models
**Duration**: Day 1 (Mar 3)
**Owner**: quanghai2k4 (Leader)
**Status**: Planned

### Tasks
- [ ] #39: Create Category model with properties
- [ ] Add validation rules to Category

### Deliverables
- `Models/Category.cs`
- `Models/CategoryType.cs` (inline enum)
- Validation attributes on Category

### Hours: 2h

### Plans
- [ ] 01-01-PLAN.md — Create Category model and CategoryType enum

---

---

## Phase 2: Service Layer
**Duration**: Day 2-3 (Mar 4-5)
**Owner**: Nguyenvu32 (Backend)
**Plans**: 2 plans
- [ ] 02-01-PLAN.md — Create ICategoryService interface and implementation stub
- [ ] 02-02-PLAN.md — Implement MockCategoryDataProvider and finalize service logic

### Tasks
- [ ] #40: Implement ICategoryService interface
- [ ] Create CategoryService class
- [ ] Create mock data provider
- [ ] Add JSON serialization

### Deliverables
- `Services/ICategoryService.cs`
- `Services/CategoryService.cs`
- `Data/MockCategoryDataProvider.cs`
- JSON data file

### Hours: 4h

---

## Phase 3: UI/Frontend
**Duration**: Day 4-6 (Mar 6-8)
**Owner**: caoanh10 (Frontend)
**Plans**: 2 plans
- [x] 03-01-PLAN.md — Create CategoryViewModel with CommunityToolkit.Mvvm
- [x] 03-02-PLAN.md — Create CategoryFilterView XAML page and wire Shell navigation

### Tasks
- [ ] #41: Design category filter UI
  - Filter button in toolbar
  - Dropdown/list layout
  - Styling
- [ ] #42: Bind category selection to ViewModel
  - CategoryViewModel
  - Commands
  - Data binding
- [ ] CategoryFilterView XAML

### Deliverables
- `Views/CategoryFilterView.xaml`
- `ViewModels/CategoryViewModel.cs`

### Hours: 10h

---

## Phase 4: Business Logic
**Duration**: Day 7-8 (Mar 9-10)
**Owner**: Nguyenvu32 (Backend)
**Status**: Planned
**Plans**: 1 plan

### Tasks
- [ ] #43: Implement filter by category method
- [ ] Handle edge cases (null, empty)
- [ ] Performance optimization

### Deliverables
- Filter logic in service/ViewModel
- Updated IEventService with GetAllEventsAsync
- FilterEventsByCategory methods in CategoryService

### Hours: 4h

### Plans
- [x] 04-01-PLAN.md — Implement filtering logic with IEventService, CategoryService filters, and CategoryViewModel integration

---

## Phase 5: Display
**Duration**: Day 9-10 (Mar 11-12)
**Owner**: caoanh10 (Frontend)
**Status**: In Progress
**Plans**: 1 plan

### Tasks
- [x] #44: Display filtered events
  - Update event list after filter
  - Show "no results" message
  - Clear filter restores full list

### Deliverables
- UI updates for filtered events
- CategoryFilterView.xaml with CollectionView

### Hours: 3h

### Plans
- [x] 05-01-PLAN.md — Create CategoryFilterView XAML with CollectionView bound to FilteredEvents

---

## Phase 6: Integration & Final
**Duration**: Day 11-12 (Mar 13-14)
**Owner**: quanghai2k4 (Leader)
**Status**: Planned
**Plans**: 1 plan

### Tasks
- [ ] Code review coordination
- [ ] Merge personal branches to team6-event-categories
- [ ] Integration testing
- [ ] Final demo preparation
- [ ] Merge to main branch

### Deliverables
- All branches merged to team6-event-categories
- Final build verification
- PR to main

### Hours: 5h

### Plans
- [x] 06-01-PLAN.md — Integration, code review, build verification, PR to main

---

## Milestones

| Milestone | Date | Criteria |
|-----------|------|----------|
| M1: Models Complete | Mar 3 | #39 - Category.cs created |
| M2: Service Complete | Mar 5 | #40 - CategoryService returns mock data |
| M3: UI Complete | Mar 8 | #41, #42 - Filter UI functional |
| M4: Logic Complete | Mar 10 | #43 - Filter works correctly |
| M5: Display Complete | Mar 12 ✓ | #44 - Filtered events display |
| M6: Final | Mar 14 | Merged to main, demo ready |

---

## Dependencies Graph

```
#39 ──> #40 ──> #41, #42, #43
                │         │
                └────────> #44
```

---

## Notes

- Daily standups to track progress
- Commit after each subtask per TEAM6_GIT_WORKFLOW.md
- All PRs reviewed by Leader (quanghai2k4)
- Use commit format: `type(#39): description`
