# Roadmap - Milestone v1.1: UI Optimization

## Epic: v1.1 - UI Optimization
## Timeline: March 31 - April 4, 2026 (5 days)

---

## Phase 7: Navigation & UI Fixes (UI/UX)
**Duration**: Day 1 (Mar 31)
**Owner**: caoanh10 (Frontend)
**Status**: Planned

### Tasks
- [x] **UI-01**: Fix route navigation
  - Đổi AppShell route từ "CategoryFilterView" → "categoryfilter"
  - Verify navigation hoạt động
- [x] **UI-02**: Dynamic empty state
  - Tạo IValueConverter cho CollectionView empty state
  - Bind IsVisible với FilteredEvents.Count
- [x] **UI-04**: Visual feedback verification
  - Verify SelectedCategory label hoạt động

### Deliverables
- `AppShell.xaml` - Fixed route
- `Converters/EmptyCollectionConverter.cs` - Empty state converter
- `CategoryFilterView.xaml` - Updated bindings

### Hours: 2h

### Plans
- [x] 07-01-PLAN.md — Route fix + EmptyCollectionConverter

---

## Phase 10: Loading States & Animations (Backend - Optional)
**Duration**: Day 2-3 (Apr 1-2) - OPTIONAL
**Owner**: Nguyenvu32 (Backend)
**Status**: Optional

### Tasks
- [ ] **UI-03**: Loading indicator
  - Thêm ActivityIndicator trong CategoryFilterView
  - Thêm IsLoading property trong CategoryViewModel
- [ ] **LOGIC-01**: Async loading verification
  - Verify LoadEventsAsync và LoadCategoriesAsync chạy async
  - Thêm try-catch cho error handling
- [ ] **LOGIC-02**: Filter animations
  - Thêm fade animation khi filter results thay đổi
  - Smooth transition cho CollectionView

### Deliverables
- `CategoryViewModel.cs` - Updated với IsLoading
- `CategoryFilterView.xaml` - Loading indicator
- Animation effects

### Hours: 4h

### Plans
- [ ] 10-01-PLAN.md — IsLoading + ActivityIndicator + Animations

---

## Phase 9: Testing & Polish
**Duration**: Day 4-5 (Apr 3-4)
**Owner**: quanghai2k4 (Leader)

### Tasks
- [ ] Build verification
- [ ] Manual testing
- [ ] Fix any remaining issues
- [ ] Code review
- [ ] Merge to main

### Deliverables
- All issues fixed
- PR to main
- Final demo ready

### Hours: 3h

---

## Milestones

| Milestone | Date | Criteria |
|-----------|------|----------|
| M1: Navigation Fix | Mar 31 | UI-01 complete |
| M2: Loading States | Apr 2 | UI-03, LOGIC-01 complete |
| M3: Animations | Apr 2 | LOGIC-02 complete |
| M4: Final | Apr 4 | Merged to main |

---

## Requirements Mapping

| Requirement | Phase |
|------------|-------|
| UI-01 | 07 |
| UI-02 | 07 |
| UI-04 | 07 |
| UI-03 | 10 (optional) |
| LOGIC-01 | 10 (optional) |
| LOGIC-02 | 10 (optional) |

---

## Dependencies Graph

```
UI-01 ─┬─> UI-02 ─┬─> UI-04
        │          │
        └────────> Phase 7 (UI/UX)
                    │
                    v
         ┌──────────────────────┐
         │                      │
         v                      v
   Phase 8 (Testing)    Phase 10 (Optional: Backend)
   UI-03, LOGIC-01, LOGIC-02
```

---

## Notes

- Daily standups để track progress
- Commit sau mỗi task hoàn thành
- All PRs reviewed by Leader (quanghai2k4)
- Use commit format: `<type>: <short description> on <file>`
