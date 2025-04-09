using MovilAlmacen.Models;
using MovilAlmacen.Services;
using System.Windows.Input;

namespace MovilAlmacen.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;
        private readonly LoginService _loginService;
        private string _documento;
        private string _clave;
        private string _mensajeError;

        public string Documento
        {
            get => _documento;
            set => SetProperty(ref _documento, value);
        }

        public string Clave
        {
            get => _clave;
            set => SetProperty(ref _clave, value);
        }

        public string MensajeError
        {
            get => _mensajeError;
            set => SetProperty(ref _mensajeError, value);
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(ApiService apiService, LoginService loginService)
        {
            Title = "Iniciar Sesión";
            _apiService = apiService;
            _loginService = loginService;
            LoginCommand = new Command(async () => await ExecuteLoginCommand());
        }

        private async Task ExecuteLoginCommand()
        {
            if (IsBusy)
                return;

            if (string.IsNullOrWhiteSpace(Documento) || string.IsNullOrWhiteSpace(Clave))
            {
                MensajeError = "Por favor ingrese documento y clave";
                return;
            }

            try
            {
                IsBusy = true;
                MensajeError = string.Empty;

                var usuario = await _apiService.Login(Documento, Clave);
                if (usuario != null)
                {
                    // Guardar sesión actual
                    Preferences.Set("IdUsuario", usuario.IdUsuario);
                    Preferences.Set("NombreUsuario", $"{usuario.Nombres} {usuario.Apellidos}");
                    // Guardamos el IdTipo como cadena para evitar problemas de conversión
                    Preferences.Set("TipoUsuario", usuario.IdTipo.HasValue ? usuario.IdTipo.Value.ToString() : "0");

                    // Si es vendedor, registrar en archivo JSON
                    if (usuario.IdTipo == 2) // Tipo vendedor
                    {
                        var loginInfo = new LoginInfo
                        {
                            Documento = usuario.Documento,
                            Nombres = usuario.Nombres,
                            Apellidos = usuario.Apellidos,
                            FechaHoraIngreso = DateTime.Now
                        };

                        await _loginService.GuardarRegistroLogin(loginInfo);
                    }

                    // Navegar a la página principal según el tipo de usuario
                    await Shell.Current.GoToAsync("//ClientesPage");
                }
                else
                {
                    MensajeError = "Documento o clave incorrectos";
                }
            }
            catch (Exception ex)
            {
                MensajeError = $"Error: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}