using NameFamDataApp.ViewModel;

namespace NameFamDataApp;

public partial class MainPage : ContentPage
{

    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}