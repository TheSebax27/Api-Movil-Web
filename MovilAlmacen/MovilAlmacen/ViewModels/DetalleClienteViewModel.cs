using System.Windows.Input;
using MovilAlmacen.Models;
using MovilAlmacen.Services;

namespace MovilAlmacen.ViewModels
{
    [QueryProperty(nameof(IdAsignacion), "IdAsignacion")]
    [QueryProperty(nameof(IdCliente), "IdCliente")]
    public class DetalleClienteViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        private int _idAsignacion;
        private int _idCliente;
        private Usuario _cliente;
        private AsignacionCliente _asignacion;
        private string _mensajeEstado;
        private bool _puedeMarcarVisitado;

        public int IdAsignacion
        {
            get => _idAsignacion;
            set
            {
                _idAsignacion = value;
                CargarDatosAsignacion();
            }
        }

        public int IdCliente
        {
            get => _idCliente;
            set
            {
                _idCliente = value;
                CargarDatosCliente();
            }
        }

        public Usuario Cliente
        {
            get => _cliente;
            set => SetProperty(ref _cliente, value);
        }

        public AsignacionCliente Asignacion
        {
            get => _asignacion;
            set => SetProperty(ref _asignacion, value);
        }

        public string MensajeEstado
        {
            get => _mensajeEstado;
            set => SetProperty(ref _mensajeEstado, value);
        }

        public bool PuedeMarcarVisitado
        {
            get => _puedeMarcarVisitado;
            set => SetProperty(ref _puedeMarcarVisitado, value);
        }

        public ICommand MarcarVisitadoCommand { get; }
        public ICommand VolverCommand { get; }

        public DetalleClienteViewModel(ApiService apiService)
        {
            Title = "Detalle del Cliente";
            _apiService = apiService;

            MarcarVisitadoCommand = new Command(async () => await ExecuteMarcarVisitadoCommand());
            VolverCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
        }

        private async void CargarDatosCliente()
        {
            if (IdCliente <= 0)
                return;

            try
            {
                IsBusy = true;
                MensajeEstado = "Cargando información del cliente...";

                Cliente = await _apiService.GetUsuarioById(IdCliente);

                if (Cliente != null)
                {
                    Title = Cliente.NombreCompleto;
                    MensajeEstado = "Información cargada correctamente";
                }
                else
                {
                    MensajeEstado = "No se pudo obtener la información del cliente";
                }
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void CargarDatosAsignacion()
        {
            if (IdAsignacion <= 0)
                return;

            try
            {
                IsBusy = true;

                // Obtener la asignación de la lista de clientes asignados
                var vendedorId = Preferences.Get("IdUsuario", 0);
                var asignaciones = await _apiService.GetClientesAsignados(vendedorId);
                Asignacion = asignaciones.FirstOrDefault(a => a.IdAsignacion == IdAsignacion);

                if (Asignacion != null)
                {
                    PuedeMarcarVisitado = !Asignacion.Visitado;
                }
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ExecuteMarcarVisitadoCommand()
        {
            if (IsBusy || IdAsignacion <= 0)
                return;

            try
            {
                IsBusy = true;
                MensajeEstado = "Registrando visita...";

                bool resultado = await _apiService.MarcarClienteVisitado(IdAsignacion);

                if (resultado)
                {
                    Asignacion.Visitado = true;
                    Asignacion.FechaVisita = DateTime.Now;
                    PuedeMarcarVisitado = false;
                    MensajeEstado = "Visita registrada correctamente";

                    // Mostrar alerta de éxito
                    await Application.Current.MainPage.DisplayAlert("Éxito", "Visita registrada correctamente", "OK");
                }
                else
                {
                    MensajeEstado = "No se pudo registrar la visita";
                    await Application.Current.MainPage.DisplayAlert("Error", "No se pudo registrar la visita", "OK");
                }
            }
            catch (Exception ex)
            {
                MensajeEstado = $"Error: {ex.Message}";
                await Application.Current.MainPage.DisplayAlert("Error", $"Error: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}