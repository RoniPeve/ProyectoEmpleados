using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class P_Mantenimiento : Form
    {
        public P_Mantenimiento()
        {
            InitializeComponent();
        }
        //creacion de la instancia de n_empleados y negocio empleado
        E_Empleados objEntidad = new E_Empleados();
        N_Empleados objNego = new N_Empleados();

        void ListarEmpleado()
        {
            DataTable dt = objNego.N_listado();
            dataDatos.DataSource = dt;
        }

        private void P_Mantenimiento_Load(object sender, EventArgs e)
        {
            ListarEmpleado();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Insertar();
            ListarEmpleado();
            Limpiar();
        }
        void Insertar()
        {
            objEntidad.nombre = textNombre.Text;
            objEntidad.edad = Convert.ToInt32(textEdad.Text);
            objEntidad.sexo = textSexo.Text;
            objEntidad.sueldo = Convert.ToDouble(textSueldo.Text);

            objNego.N_Insertar(objEntidad);
            MessageBox.Show("Registro Insertado con exito");
        }
        void Limpiar()
        {
            textCodigo.Clear();
            textNombre.Clear();
            textEdad.Clear();
            textSexo.Clear();
            textSueldo.Clear();
        }

        private void dataDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataDatos.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                int eliminar = Convert.ToInt32(dataDatos.Rows[e.RowIndex].Cells["codigo"].Value.ToString());
                objNego.N_Eliminar(eliminar);
                MessageBox.Show("Registro Eliminado con exito");
                ListarEmpleado();
            }
            else if (dataDatos.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                textCodigo.Text= dataDatos.Rows[e.RowIndex].Cells["codigo"].Value.ToString();
                textNombre.Text = dataDatos.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                textEdad.Text = dataDatos.Rows[e.RowIndex].Cells["edad"].Value.ToString();
                textSexo.Text = dataDatos.Rows[e.RowIndex].Cells["sexo"].Value.ToString();
                textSueldo.Text = dataDatos.Rows[e.RowIndex].Cells["sueldo"].Value.ToString();
            }
            else
            {
                return;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            editar();
            ListarEmpleado();
            Limpiar();
        }
        void editar()
        {
            objEntidad.cod = Convert.ToInt32(textCodigo.Text);
            objEntidad.nombre = textNombre.Text;
            objEntidad.edad = Convert.ToInt32(textEdad.Text);
            objEntidad.sexo = textSexo.Text;
            objEntidad.sueldo = Convert.ToDouble(textSueldo.Text);
            objNego.N_Editar(objEntidad);

            MessageBox.Show("Registro editado con exito");
        }
    }
}
