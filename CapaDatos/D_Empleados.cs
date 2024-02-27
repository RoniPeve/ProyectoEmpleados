using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class D_Empleados
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconex"].ConnectionString);
        public DataTable D_listado()
        {
            SqlCommand cmd = new SqlCommand("sp_listar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void D_Insertar(E_Empleados emp)
        {
            SqlCommand cmd = new SqlCommand("sp_insertar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nom", emp.nombre);
            cmd.Parameters.AddWithValue("@edad", emp.edad);
            cmd.Parameters.AddWithValue("@sexo", emp.sexo);
            cmd.Parameters.AddWithValue("@sue", emp.sueldo);

            if (cn.State==ConnectionState.Open)
            {
                cn.Close();
            }
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void D_Eliminar(int cod)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod", cod);
            if (cn.State==ConnectionState.Open)
            {
                cn.Close();
            }
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void D_editar(E_Empleados emp)
        {
            SqlCommand cmd = new SqlCommand("sp_editar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cod", emp.cod);
            cmd.Parameters.AddWithValue("@nom", emp.nombre);
            cmd.Parameters.AddWithValue("@edad", emp.edad);
            cmd.Parameters.AddWithValue("@sexo", emp.sexo);
            cmd.Parameters.AddWithValue("@sue", emp.sueldo);
            if (cn.State==ConnectionState.Open)
            {
                cn.Close();
            }
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
