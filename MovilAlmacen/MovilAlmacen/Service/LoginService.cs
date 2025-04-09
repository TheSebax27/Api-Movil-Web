using System.Text.Json;
using MovilAlmacen.Models;
using System.Runtime.InteropServices;

namespace MovilAlmacen.Services
{
    public class LoginService
    {
        private readonly string _loginFilePath;

        public LoginService()
        {
#if WINDOWS
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _loginFilePath = Path.Combine(documentosPath, "login_history.json");
#else
            _loginFilePath = Path.Combine(FileSystem.AppDataDirectory, "login_history.json");
#endif
        }

        public async Task GuardarRegistroLogin(LoginInfo loginInfo)
        {
            List<LoginInfo> historial = new();
            if (File.Exists(_loginFilePath))
            {
                try
                {
                    string json = await File.ReadAllTextAsync(_loginFilePath);
                    if (!string.IsNullOrEmpty(json))
                    {
                        historial = JsonSerializer.Deserialize<List<LoginInfo>>(json);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al leer archivo de login: {ex.Message}");
                }
            }

            historial ??= new List<LoginInfo>();
            historial.Add(loginInfo);

            string jsonActualizado = JsonSerializer.Serialize(historial, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_loginFilePath, jsonActualizado);
        }

        public async Task<List<LoginInfo>> ObtenerHistorialLogin()
        {
            if (!File.Exists(_loginFilePath))
            {
                return new List<LoginInfo>();
            }
            try
            {
                string json = await File.ReadAllTextAsync(_loginFilePath);
                if (string.IsNullOrEmpty(json))
                {
                    return new List<LoginInfo>();
                }
                return JsonSerializer.Deserialize<List<LoginInfo>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer historial de login: {ex.Message}");
                return new List<LoginInfo>();
            }
        }
    }
}
