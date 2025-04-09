using MovilAlmacen.ViewModels;

namespace MovilAlmacen.Views;

public partial class DetalleClientePage : ContentPage
{
    public DetalleClientePage(DetalleClienteViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}