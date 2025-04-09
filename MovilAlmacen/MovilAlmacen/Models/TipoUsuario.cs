using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MovilAlmacen.Models
{
    public class TipoUsuario : INotifyPropertyChanged
    {
        private int idTipo;
        private string tipoUsuarioNombre;

        public int IdTipo
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
            get => tipoUsuarioNombre;
            set
            {
                tipoUsuarioNombre = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}