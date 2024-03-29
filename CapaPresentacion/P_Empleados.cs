﻿using System;
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
    public partial class P_Empleados : Form
    {
        public P_Empleados()
        {
            InitializeComponent();
        }

        private void P_Empleados_Load(object sender, EventArgs e)
        {
            ListarEmpleado();
        }

        //creacion de la instancia de n_empleados y negocio empleado
        E_Empleados objEntidad = new E_Empleados();
        N_Empleados objNego = new N_Empleados();

        void ListarEmpleado()
        {
            DataTable dt = objNego.N_listado();
            dataGridView1.DataSource = dt;
        }
    }
}
