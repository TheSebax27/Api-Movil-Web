using MovilAlmacen.Views;

namespace MovilAlmacen
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

           
            Routing.RegisterRoute("DetalleClientePage", typeof(DetalleClientePage));
        }
    }
}