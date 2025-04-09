using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Diagnostics;
using MovilAlmacen.Models;

namespace MovilAlmacen.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7280/api/Usuario/Login";

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<Usuario> Login(string documento, string clave)
        {
            try
            {
                // Configurar las opciones de serialización
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null // No aplicar ninguna política de nombres
                };

                // Crear un objeto anónimo con los nombres de propiedades exactamente como los espera el backend
                var loginData = new { documento = documento, clave = clave };
                var json = JsonSerializer.Serialize(loginData, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                Debug.WriteLine($"Enviando datos de login: {json}");

                var response = await _httpClient.PostAsync("Usuario/Login", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseOptions = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true // Esto permite que ignore mayúsculas/minúsculas al deserializar
                    };

                    var responseContent = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"Respuesta API: {responseContent}");

                    return JsonSerializer.Deserialize<Usuario>(responseContent, responseOptions);
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"Error API: {errorContent}, StatusCode: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en login: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"InnerException: {ex.InnerException.Message}");
                }
                throw;
            }
        }

        // Obtener lista de clientes asignados a un vendedor
        public async Task<List<AsignacionCliente>> GetClientesAsignados(int idVendedor)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/AsignacionCliente/vendedor/{idVendedor}");
                if (response.IsSuccessStatusCode)
                {
                    var asignaciones = await response.Content.ReadFromJsonAsync<List<AsignacionCliente>>();
                    return asignaciones;
                }
                return new List<AsignacionCliente>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener clientes asignados: {ex.Message}");
                return new List<AsignacionCliente>();
            }
        }

        // Obtener detalles de un usuario (cliente)
        public async Task<Usuario> GetUsuarioById(int idUsuario)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/Usuario/{idUsuario}");
                if (response.IsSuccessStatusCode)
                {
                    var usuario = await response.Content.ReadFromJsonAsync<Usuario>();
                    return usuario;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener usuario: {ex.Message}");
                return null;
            }
        }

        // Marcar cliente como visitado
        public async Task<bool> MarcarClienteVisitado(int idAsignacion)
        {
            try
            {
                var response = await _httpClient.PutAsync($"{_baseUrl}/AsignacionCliente/marcar-visitado/{idAsignacion}", null);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al marcar cliente como visitado: {ex.Message}");
                return false;
            }
        }
    }
}