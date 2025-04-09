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
        private readonly string _baseUrl = "https://localhost:7280";
        private readonly JsonSerializerOptions _serializerOptions;

        public ApiService()
        {
            _httpClient = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            });

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<Usuario> Login(string documento, string clave)
        {
            try
            {
               
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null 
                };

               
                var loginData = new { documento = documento, clave = clave };
                var json = JsonSerializer.Serialize(loginData, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                Debug.WriteLine($"Enviando datos de login: {json}");
                Debug.WriteLine($"URL completa: {_baseUrl}/api/Usuario/Login");

                var response = await _httpClient.PostAsync($"{_baseUrl}/api/Usuario/Login", content);

                var responseContent = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"Respuesta API: {responseContent}");

                if (response.IsSuccessStatusCode)
                {
                    
                    var loginResponse = JsonSerializer.Deserialize<LoginResponse>(responseContent, _serializerOptions);

                    if (loginResponse?.Success == true)
                    {
                        return loginResponse.Usuario;
                    }
                    else
                    {
                        Debug.WriteLine($"Error de login: {loginResponse?.Message}");
                        return null;
                    }
                }
                else
                {
                    Debug.WriteLine($"Error API: {responseContent}, StatusCode: {response.StatusCode}");
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

      
        public async Task<List<AsignacionCliente>> GetClientesAsignados(int idVendedor)
        {
            try
            {
                Debug.WriteLine($"Obteniendo clientes asignados para vendedor ID: {idVendedor}");
                Debug.WriteLine($"URL: {_baseUrl}/api/AsignacionCliente/vendedor/{idVendedor}");

                var response = await _httpClient.GetAsync($"{_baseUrl}/api/AsignacionCliente/vendedor/{idVendedor}");
                var content = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"Respuesta API (GetClientesAsignados): {content}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = JsonSerializer.Deserialize<List<dynamic>>(content, _serializerOptions);

                    if (jsonResponse == null || !jsonResponse.Any())
                    {
                        Debug.WriteLine("No se encontraron asignaciones");
                        return new List<AsignacionCliente>();
                    }

                 
                    var asignaciones = new List<AsignacionCliente>();

                    foreach (var item in jsonResponse)
                    {
                       
                        var jsonElement = (JsonElement)item;

                        var asignacion = new AsignacionCliente
                        {
                            IdAsignacion = jsonElement.GetProperty("idAsignacion").GetInt32(),
                            IdVendedor = jsonElement.GetProperty("idVendedor").GetInt32(),
                            IdCliente = jsonElement.GetProperty("idCliente").GetInt32(),
                            FechaAsignacion = jsonElement.GetProperty("fechaAsignacion").GetDateTime(),
                            Visitado = jsonElement.GetProperty("visitado").GetBoolean(),
                            NombreVendedor = jsonElement.GetProperty("nombreVendedor").GetString(),
                            NombreCliente = jsonElement.GetProperty("nombreCliente").GetString()
                        };

                        
                        if (jsonElement.TryGetProperty("fechaVisita", out JsonElement fechaVisitaElement) &&
                            fechaVisitaElement.ValueKind != JsonValueKind.Null)
                        {
                            asignacion.FechaVisita = fechaVisitaElement.GetDateTime();
                        }

                        asignaciones.Add(asignacion);
                    }

                    return asignaciones;
                }

                Debug.WriteLine($"Error al obtener clientes: {response.StatusCode}");
                return new List<AsignacionCliente>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al obtener clientes asignados: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"InnerException: {ex.InnerException.Message}");
                }
                return new List<AsignacionCliente>();
            }
        }

        
        public async Task<Usuario> GetUsuarioById(int idUsuario)
        {
            try
            {
                Debug.WriteLine($"Obteniendo usuario con ID: {idUsuario}");
                var response = await _httpClient.GetAsync($"{_baseUrl}/api/Usuario/{idUsuario}");
                var content = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"Respuesta API (GetUsuarioById): {content}");

                if (response.IsSuccessStatusCode)
                {
                    var usuario = JsonSerializer.Deserialize<Usuario>(content, _serializerOptions);
                    return usuario;
                }
                Debug.WriteLine($"Error al obtener usuario: {response.StatusCode}");
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al obtener usuario: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"InnerException: {ex.InnerException.Message}");
                }
                return null;
            }
        }

      
        public async Task<bool> MarcarClienteVisitado(int idAsignacion)
        {
            try
            {
                Debug.WriteLine($"Marcando cliente como visitado ID: {idAsignacion}");
               
                var response = await _httpClient.PutAsync($"{_baseUrl}/api/AsignacionCliente/marcar-visitado/{idAsignacion}", null);
                var content = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"Respuesta API (MarcarClienteVisitado): {content}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al marcar cliente como visitado: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Debug.WriteLine($"InnerException: {ex.InnerException.Message}");
                }
                return false;
            }
        }
    }
}