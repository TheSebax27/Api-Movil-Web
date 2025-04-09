using MovilAlmacen.Models;
using MovilAlmacen.Services;
using System.Windows.Input;
using System.Diagnostics;

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

                Debug.WriteLine($"Intentando login con documento: {Documento}");

                var usuario = await _apiService.Login(Documento, Clave);

                if (usuario != null)
                {
                    Debug.WriteLine($"Login exitoso para usuario: {usuario.Nombres} {usuario.Apellidos}");

                    Preferences.Set("IdUsuario", usuario.IdUsuario);
                    Preferences.Set("NombreUsuario", $"{usuario.Nombres} {usuario.Apellidos}");
                   
                    Preferences.Set("TipoUsuario", usuario.IdTipo.HasValue ? usuario.IdTipo.Value.ToString() : "0");

                   
                    if (usuario.IdTipo == 2) 
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

                   
                    await Shell.Current.GoToAsync("//ClientesPage");
                }
                else
                {
                    MensajeError = "Documento o clave incorrectos";
                    Debug.WriteLine("Login fallido: usuario es null");
                }
            }
            catch (Exception ex)
            {
                MensajeError = $"Error: {ex.Message}";
                Debug.WriteLine($"Error en login: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}