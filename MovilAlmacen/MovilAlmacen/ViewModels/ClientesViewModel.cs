using System.Collections.ObjectModel;
using System.Windows.Input;
using MovilAlmacen.Models;
using MovilAlmacen.Services;
using System.Diagnostics;

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

           
            Task.Run(async () => await CargarClientesAsignados());
        }

        public async Task CargarClientesAsignados()
        {
            if (IsBusy)
                return;

            try
            {
                IsRefreshing = true;
                IsBusy = true;
                MensajeEstado = "Cargando clientes...";

                int idVendedor = Preferences.Get("IdUsuario", 0);
                Debug.WriteLine($"ID de vendedor recuperado: {idVendedor}");

                if (idVendedor == 0)
                {
                    MensajeEstado = "Error: Usuario no identificado. Intente iniciar sesión nuevamente.";
                    Debug.WriteLine("Error: ID de vendedor es 0");
                    return;
                }

                var clientes = await _apiService.GetClientesAsignados(idVendedor);
                Debug.WriteLine($"Se obtuvieron {clientes.Count} clientes");

                ClientesAsignados.Clear();
                if (clientes.Any())
                {
                    foreach (var cliente in clientes)
                    {
                        Debug.WriteLine($"Agregando cliente: {cliente.NombreCliente}, ID: {cliente.IdCliente}");
                        ClientesAsignados.Add(cliente);
                    }
                    MensajeEstado = $"Se encontraron {clientes.Count} clientes asignados";
                }
                else
                {
                    MensajeEstado = "No tiene clientes asignados";
                    Debug.WriteLine("No se encontraron clientes asignados");
                }
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error: {ex.Message}";
                Debug.WriteLine($"Error al cargar clientes: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"InnerException: {ex.InnerException.Message}");
                }
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

            Debug.WriteLine($"Cliente seleccionado: {cliente.NombreCliente}, ID: {cliente.IdCliente}");
            ClienteSeleccionado = cliente;

           
            var navigationParameter = new Dictionary<string, object>
            {
                { "IdAsignacion", cliente.IdAsignacion },
                { "IdCliente", cliente.IdCliente }
            };

            await Shell.Current.GoToAsync($"DetalleClientePage", navigationParameter);
        }

        private async Task CerrarSesion()
        {
            
            Preferences.Clear();
            Debug.WriteLine("Cerrando sesión, preferencias borradas");

           
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}