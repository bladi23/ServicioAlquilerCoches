using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicioAlquiler.VIEWS
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btn_coches_Click(object sender, EventArgs e)
        {
            coches _coches = new coches();
            panel7.Controls.Clear();
            _coches.Dock = DockStyle.Fill;
            panel7.Controls.Add(_coches);
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_clientes_Click(object sender, EventArgs e)
        {
            Clientes _clientes = new Clientes();
            panel7.Controls.Clear();
            _clientes.Dock = DockStyle.Fill;
            panel7.Controls.Add(_clientes);

        }

        private void btn_alquileres_Click(object sender, EventArgs e)
        {
            Alquiler _alquiler = new Alquiler();
            panel7.Controls.Clear();
            _alquiler.Dock = DockStyle.Fill;
            panel7.Controls.Add(_alquiler);
        }
    }
}
