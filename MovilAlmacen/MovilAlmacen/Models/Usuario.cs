using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace MovilAlmacen.Models
{
    public class Usuario : INotifyPropertyChanged
    {
        private int idUsuario;
        private string documento;
        private string nombres;
        private string apellidos;
        private string direccion;
        private string telefonoFijo;
        private string celular;
        private string email;
        private string foto;
        private string ubicacion;
        private string estado;
        private string _clave; // Renombrada para evitar conflicto
        private int? idTipo;
        private string tipoUsuarioNombre;

        public int IdUsuario
        {
            get => idUsuario;
            set
            {
                idUsuario = value;
                OnPropertyChanged();
            }
        }

        public string Documento
        {
            get => documento ?? string.Empty;
            set
            {
                documento = value;
                OnPropertyChanged();
            }
        }

        public string Nombres
        {
            get => nombres ?? string.Empty;
            set
            {
                nombres = value;
                OnPropertyChanged();
            }
        }

        public string Apellidos
        {
            get => apellidos ?? string.Empty;
            set
            {
                apellidos = value;
                OnPropertyChanged();
            }
        }

        public string Direccion
        {
            get => direccion ?? string.Empty;
            set
            {
                direccion = value;
                OnPropertyChanged();
            }
        }

        public string TelefonoFijo
        {
            get => telefonoFijo ?? string.Empty;
            set
            {
                telefonoFijo = value;
                OnPropertyChanged();
            }
        }

        public string Celular
        {
            get => celular ?? string.Empty;
            set
            {
                celular = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => email ?? string.Empty;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string Foto
        {
            get => foto ?? string.Empty;
            set
            {
                foto = value;
                OnPropertyChanged();
            }
        }

        public string Ubicacion
        {
            get => ubicacion ?? string.Empty;
            set
            {
                ubicacion = value;
                OnPropertyChanged();
            }
        }

        public string Estado
        {
            get => estado ?? string.Empty;
            set
            {
                estado = value;
                OnPropertyChanged();
            }
        }

        // Usa JsonPropertyName para indicar que esta propiedad se mapea a "clave" en el JSON
        [JsonPropertyName("clave")]
        public string Clave
        {
            get => _clave ?? string.Empty;
            set
            {
                _clave = value;
                OnPropertyChanged();
            }
        }

        public int? IdTipo
        {
            get => idTipo;
            set
            {
                idTipo = value;
                OnPropertyChanged();
            }
        }

        public string TipoUsuarioNombre
        {
            get => tipoUsuarioNombre ?? string.Empty;
            set
            {
                tipoUsuarioNombre = value;
                OnPropertyChanged();
            }
        }

        public string NombreCompleto => $"{Nombres} {Apellidos}";
        public string IdTipoString => IdTipo?.ToString() ?? string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}