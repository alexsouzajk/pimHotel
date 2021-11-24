using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HotelVancouver
{
    public partial class FormCliente : Form
    {

        Thread nt = null;

        public FormCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nt = new Thread(novoFormCadastroCliente);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void novoFormCadastroCliente()
        {
            Application.Run(new FormCadastroCliente());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nt = new Thread(novoFormConsultarClientes);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void novoFormConsultarClientes()
        {
            Application.Run(new FormConsultarClientes());
        }
    }
}
