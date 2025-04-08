using System;
using System.Collections.Generic;
using AppAlmacen.Datos;
using AppAlmacen.Entidades;

namespace AppAlmacen.Logica
{
    public class ClAsignacionClienteL
    {
        private ClAsignacionClienteD asignacionD = new ClAsignacionClienteD();

        public int MtdAsignarClienteVendedor(int idVendedor, int idCliente)
        {
            return asignacionD.MtdAsignarClienteVendedor(idVendedor, idCliente);
        }

        public List<ClAsignacionCliente> MtdListarClientesAsignados(int? idVendedor = null)
        {
            return asignacionD.MtdListarClientesAsignados(idVendedor);
        }

        public List<ClAsignacionCliente> MtdListarClientesVisitados()
        {
            return asignacionD.MtdListarClientesVisitados();
        }

        public bool MtdMarcarClienteVisitado(int idAsignacion)
        {
            return asignacionD.MtdMarcarClienteVisitado(idAsignacion);
        }

        public bool MtdEliminarAsignacionCliente(int idAsignacion)
        {
            return asignacionD.MtdEliminarAsignacionCliente(idAsignacion);
        }
    }
}
