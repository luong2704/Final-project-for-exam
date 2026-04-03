using Campus.ViewModels;

namespace Campus.Views;

public partial class MyEventsPage : ContentPage
{
   private readonly EventViewModels _viewModel;


   public MyEventsPage(EventViewModels viewModel)
   {
       InitializeComponent();
      
       // Gán ViewModel làm BindingContext cho toàn bộ giao diện XAML
       _viewModel = viewModel;
       BindingContext = _viewModel;
   }


   protected override void OnAppearing()
   {
       base.OnAppearing();
      
       // Tự động tải danh sách sự kiện mỗi khi trang này hiển thị lên màn hình
       if (_viewModel.LoadMyEventsCommand.CanExecute(null))
       {
           _viewModel.LoadMyEventsCommand.Execute(null);
       }
   }
}