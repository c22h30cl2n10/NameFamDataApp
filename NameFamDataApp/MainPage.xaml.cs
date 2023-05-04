using NameFamDataApp.ViewModel;

namespace NameFamDataApp;

public partial class MainPage : ContentPage
{
    private MainPageViewModel _viewModel = new MainPageViewModel();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = _viewModel;
    }
}