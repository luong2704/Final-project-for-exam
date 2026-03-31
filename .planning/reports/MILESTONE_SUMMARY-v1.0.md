# Milestone v1.0 — Event Categories Module Summary

**Generated:** 2026-03-31
**Purpose:** Team onboarding and project review

---

## 1. Project Overview

Campus Activity Manager là ứng dụng .NET MAUI để quản lý sự kiện trong khuôn viên trường với tính năng phân loại sự kiện theo danh mục (Category).

**Team 6 Responsibilities:**
- Tạo Category model và CategoryType enum
- Implement CategoryService với các phương thức filter
- Tạo CategoryFilterView UI với CommunityToolkit.Mvvm
- Implement filtering logic và display filtered events

**Target Users:** Sinh viên và nhân viên trong khuôn viên trường

---

## 2. Architecture & Technical Decisions

- **Framework:** .NET MAUI (net10.0-windows10.0.19041.0)
- **Pattern:** MVVM với CommunityToolkit.Mvvm
- **DI:** Microsoft.Extensions.DependencyInjection
- **Navigation:** .NET MAUI Shell

### Key Decisions

| Decision | Why | Phase |
|----------|-----|-------|
| CommunityToolkit.Mvvm | Source generators cho ObservableProperty, RelayCommand | Phase 3 |
| Border thay vì Frame | Frame obsolete trong .NET 9 | Phase 3 |
| ItemDisplayBinding trên Picker | Hiển thị CategoryName từ model | Phase 3 |
| Static methods cho filter | Filter logic có thể reuse không cần instance | Phase 4 |
| Case-insensitive matching | Filter linh hoạt hơn | Phase 4 |

---

## 3. Phases Delivered

| Phase | Name | Status | One-Liner |
|-------|------|--------|-----------|
| 01 | Data Models | ✅ Complete | Category model, CategoryType enum |
| 02 | Service Layer | ✅ Complete | ICategoryService, CategoryService với mock data |
| 03 | UI/Frontend | ✅ Complete | CategoryFilterView XAML với picker, apply/clear buttons |
| 04 | Business Logic | ✅ Complete | FilterEventsByCategory, FilterEventsByType methods |
| 05 | Display | ✅ Complete | FilteredEvents CollectionView binding |
| 06 | Integration | ✅ Complete | Merged to main via PR #98 |

---

## 4. Requirements Coverage

- ✅ **#39: Create Category model** - Category.cs với CategoryId, CategoryName, CategoryType, IsActive
- ✅ **#40: Implement category data source** - CategoryService với GetAllCategoriesAsync, GetCategoriesByTypeAsync
- ✅ **#41: Design category filter UI** - CategoryFilterView với Border card layout, Picker, buttons
- ✅ **#42: Bind category selection to ViewModel** - CategoryViewModel với SelectedCategory, ApplyFilterCommand
- ✅ **#43: Implement filtering logic** - FilterEventsByCategory và FilterEventsByType static methods
- ✅ **#44: Display filtered events** - CollectionView bind đến FilteredEvents

---

## 5. Key Decisions Log

| ID | Description | Phase | Rationale |
|----|-------------|-------|-----------|
| DEC-01 | Border card layout pattern | Phase 3 | Frame obsolete trong .NET 9, dùng Border thay thế |
| DEC-02 | ItemDisplayBinding cho Picker | Phase 3 | Hiển thị CategoryName thay vì toString() mặc định |
| DEC-03 | Static filter methods | Phase 4 | Reusable, không cần instance service |
| DEC-04 | Case-insensitive filter | Phase 4 | User-friendly, không phân biệt hoa thường |
| DEC-05 | HashSet cho type lookup | Phase 4 | Performance optimization khi filter theo CategoryType |

---

## 6. Tech Debt & Deferred Items

### Warnings (Build)
- **MVVMTK0045:** ObservableProperty fields not AOT compatible in WinRT (chỉ ảnh hưởng UWP/WinUI, không ảnh hưởng MAUI)
- **CS8618:** Non-nullable properties in Event.cs (nullable reference types)
- **CS0618:** Frame is obsolete (dùng Border, nhưng ProfilePage vẫn dùng Frame)

### Deferred
- Dynamic empty state label (hiện tại hardcoded `IsVisible="False"`)
- Value converter cho collection count check
- Nullable reference types configuration

---

## 7. Getting Started

### Run the Project
```bash
dotnet build Campus.csproj -f net10.0-windows10.0.19041.0
dotnet run --project Campus.csproj
```

### Key Directories
```
Models/
  - Category.cs, CategoryType.cs (Event Categories)
  - Event.cs, Registration.cs (Events module)

Services/
  - ICategoryService.cs, CategoryService.cs (Category logic)
  - IEventService.cs, MockEventService.cs (Event data)

ViewModels/
  - CategoryViewModel.cs (Filter logic)

Views/
  - CategoryFilterView.xaml/.cs (Filter UI)
```

### Tests
- Build verification: `dotnet build`
- Manual testing: Chạy app, navigate đến Categories tab, select category và click Apply Filter

### Where to Look First
1. `Views/CategoryFilterView.xaml` - UI cho filter
2. `ViewModels/CategoryViewModel.cs` - Logic filter binding
3. `Services/CategoryService.cs` - Filter methods
4. `AppShell.xaml` - Navigation routes

---

## Stats

- **Timeline:** Mar 3, 2026 → Mar 30, 2026 (~27 days)
- **Phases:** 6/6 complete
- **Commits:** 195 total, ~25 Team 6
- **Files changed:** 6 source files (+115 lines)
- **Contributors (Team 6):**
  - quanghai2k4 (Leader, Model coordination)
  - caoanh10 (Frontend, UI/ViewModel)
  - Nguyenvu32 (Backend, Service/Logic)

---

## GitHub PRs Merged

| PR | Description | Date |
|----|-------------|------|
| #66 | Team 6 initial merge | Mar 28 |
| #81 | Event Categories to team6 | Mar 29 |
| #96 | FilterEvents methods (Nguyenvu) | Mar 30 |
| #98 | Team 6 → main (final) | Mar 30 |
