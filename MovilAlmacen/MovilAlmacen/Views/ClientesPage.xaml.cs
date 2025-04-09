using MovilAlmacen.ViewModels;

namespace MovilAlmacen.Views;

public partial class ClientesPage : ContentPage
{
    private readonly ClientesViewModel _viewModel;

    public ClientesPage(ClientesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Verificar si hay sesión activa, de lo contrario redirigir a login
        var idUsuario = Preferences.Get("IdUsuario", 0);
        if (idUsuario == 0)
        {
            Shell.Current.GoToAsync("//LoginPage");
            return;
        }

        // Refrescar la lista de clientes
        _viewModel.RefreshCommand.Execute(null);
    }
}