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
    public partial class FormAcomodacao : Form
    {

        Thread nt = null;

        public FormAcomodacao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            nt = new Thread(novoFormCadastroAcomodacao);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void novoFormCadastroAcomodacao()
        {
            Application.Run(new FormCadastroAcomodacao());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

            nt = new Thread(novoFormConsultaAcomodacao);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void novoFormConsultaAcomodacao()
        {
            Application.Run(new FormConsultarAcomodacao());
        }
    }
}
