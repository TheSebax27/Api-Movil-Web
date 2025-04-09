using MovilAlmacen.ViewModels;

namespace MovilAlmacen.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Limpiar campos si hay datos guardados
        var vm = (LoginViewModel)BindingContext;
        vm.Documento = string.Empty;
        vm.Clave = string.Empty;
        vm.MensajeError = string.Empty;
    }
}