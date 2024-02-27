using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
using System.Data;


namespace CapaNegocio
{
    public class N_Empleados
    {
        D_Empleados objdato = new D_Empleados();
        public DataTable N_listado()
        {
            return objdato.D_listado();
        }

        public void N_Insertar(E_Empleados emp)
        {
            objdato.D_Insertar(emp);
        }
        public void N_Eliminar(int cod)
        {
            objdato.D_Eliminar(cod);
        }
        public void N_Editar(E_Empleados emp)
        {
            objdato.D_editar(emp);
        }
    }
}
