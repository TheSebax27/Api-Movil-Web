using System.Collections.ObjectModel;
using System.Windows.Input;
using MovilAlmacen.Models;
using MovilAlmacen.Services;

namespace MovilAlmacen.ViewModels
{
    public class ClientesViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        private ObservableCollection<AsignacionCliente> _clientesAsignados;
        private AsignacionCliente _clienteSeleccionado;
        private string _mensajeEstado;
        private bool _isRefreshing;

        public ObservableCollection<AsignacionCliente> ClientesAsignados
        {
            get => _clientesAsignados;
            set => SetProperty(ref _clientesAsignados, value);
        }

        public AsignacionCliente ClienteSeleccionado
        {
            get => _clienteSeleccionado;
            set => SetProperty(ref _clienteSeleccionado, value);
        }

        public string MensajeEstado
        {
            get => _mensajeEstado;
            set => SetProperty(ref _mensajeEstado, value);
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public ICommand RefreshCommand { get; }
        public ICommand SeleccionarClienteCommand { get; }
        public ICommand CerrarSesionCommand { get; }

        public ClientesViewModel(ApiService apiService)
        {
            Title = "Clientes Asignados";
            _apiService = apiService;
            ClientesAsignados = new ObservableCollection<AsignacionCliente>();

            RefreshCommand = new Command(async () => await CargarClientesAsignados());
            SeleccionarClienteCommand = new Command<AsignacionCliente>(async (cliente) => await SeleccionarCliente(cliente));
            CerrarSesionCommand = new Command(async () => await CerrarSesion());

            // Cargar datos iniciales
            Task.Run(async () => await CargarClientesAsignados());
        }

        private async Task CargarClientesAsignados()
        {
            if (IsBusy)
                return;

            try
            {
                IsRefreshing = true;
                IsBusy = true;
                MensajeEstado = "Cargando clientes...";

                int idVendedor = Preferences.Get("IdUsuario", 0);
                if (idVendedor == 0)
                {
                    MensajeEstado = "Error: No se ha iniciado sesión";
                    return;
                }

                var clientes = await _apiService.GetClientesAsignados(idVendedor);

                ClientesAsignados.Clear();
                if (clientes.Any())
                {
                    foreach (var cliente in clientes)
                    {
                        ClientesAsignados.Add(cliente);
                    }
                    MensajeEstado = $"Se encontraron {clientes.Count} clientes asignados";
                }
                else
                {
                    MensajeEstado = "No tiene clientes asignados";
                }
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        private async Task SeleccionarCliente(AsignacionCliente cliente)
        {
            if (cliente == null)
                return;

            ClienteSeleccionado = cliente;

            // Navegar a la página de detalle pasando el ID del cliente
            var navigationParameter = new Dictionary<string, object>
            {
                { "IdAsignacion", cliente.IdAsignacion },
                { "IdCliente", cliente.IdCliente }
            };

            await Shell.Current.GoToAsync($"DetalleClientePage", navigationParameter);
        }

        private async Task CerrarSesion()
        {
            // Limpiar las preferencias
            Preferences.Clear();

            // Volver a la página de login
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}