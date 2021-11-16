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
    public partial class FormReservas : Form
    {

        Thread nt = null;

        public FormReservas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            nt = new Thread(novoFormCadastroReservas);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void novoFormCadastroReservas()
        {
            Application.Run(new FormCadastroReservas());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nt = new Thread(novoFormConsultarReservas);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void novoFormConsultarReservas()
        {
            Application.Run(new FormConsultarReservas());
        }
    }
}
