using System.Text.Json.Serialization;

namespace MovilAlmacen.Models
{
    public class LoginResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("usuario")]
        public Usuario Usuario { get; set; }
    }
}