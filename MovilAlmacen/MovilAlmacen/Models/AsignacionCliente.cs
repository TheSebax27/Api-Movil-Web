using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MovilAlmacen.Models
{
    public class AsignacionCliente : INotifyPropertyChanged
    {
        private int idAsignacion;
        private int idVendedor;
        private int idCliente;
        private DateTime fechaAsignacion;
        private bool visitado;
        private DateTime? fechaVisita;
        private string nombreVendedor;
        private string nombreCliente;

        public int IdAsignacion
        {
            get => idAsignacion;
            set
            {
                idAsignacion = value;
                OnPropertyChanged();
            }
        }

        public int IdVendedor
        {
            get => idVendedor;
            set
            {
                idVendedor = value;
                OnPropertyChanged();
            }
        }

        public int IdCliente
        {
            get => idCliente;
            set
            {
                idCliente = value;
                OnPropertyChanged();
            }
        }

        public DateTime FechaAsignacion
        {
            get => fechaAsignacion;
            set
            {
                fechaAsignacion = value;
                OnPropertyChanged();
            }
        }

        public bool Visitado
        {
            get => visitado;
            set
            {
                visitado = value;
                OnPropertyChanged();
            }
        }

        public DateTime? FechaVisita
        {
            get => fechaVisita;
            set
            {
                fechaVisita = value;
                OnPropertyChanged();
            }
        }

        public string NombreVendedor
        {
            get => nombreVendedor;
            set
            {
                nombreVendedor = value;
                OnPropertyChanged();
            }
        }

        public string NombreCliente
        {
            get => nombreCliente;
            set
            {
                nombreCliente = value;
                OnPropertyChanged();
            }
        }

  
        public string EstadoVisita => Visitado ? "Visitado" : "Pendiente";
        public string FechaVisitaStr => FechaVisita.HasValue ? FechaVisita.Value.ToString("dd/MM/yyyy HH:mm") : "-";
        public string FechaAsignacionStr => FechaAsignacion.ToString("dd/MM/yyyy HH:mm");

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}