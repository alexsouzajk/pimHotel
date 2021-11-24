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
    public partial class FormMenu : Form
    {

        Thread nt = null;

        public FormMenu()
        {
            InitializeComponent();
        }

        public FormMenu(FormLogin formLogin)
        {
            InitializeComponent();

            formLogin.Close();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();


            nt = new Thread(novoFormReservas);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void novoFormReservas()
        {
            Application.Run(new FormReservas());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

            nt = new Thread(novoFormAcomodacao);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void novoFormAcomodacao()
        {
            Application.Run(new FormAcomodacao());
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();


            nt = new Thread(novoFormClientes);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void novoFormClientes()
        {
            Application.Run(new FormCliente());
        }
    }
}
