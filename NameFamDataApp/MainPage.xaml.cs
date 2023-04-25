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

    private void OnSaveClicked(object sender, EventArgs e)
    {
        _viewModel.NameFill = Name.Text;
        _viewModel.FamFill = Fam.Text;
        _viewModel.DateFill = Date.Date;
    }

    private void OnVosstClicked(object sender, EventArgs e)
    {
        Name.Text = _viewModel.NameFill;
        Fam.Text = _viewModel.FamFill;
        Date.Date = _viewModel.DateFill;
    }

}