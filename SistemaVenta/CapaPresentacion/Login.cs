using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;



namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            List<Usuario> list = new CN_Usuario().Listar();

            Usuario ousuario = new CN_Usuario().Listar().Where(U=> U.Documento == txtDocumento.Text && U.Clave == txtClave.Text).FirstOrDefault();


            if(ousuario != null)
            {
                Inicio form = new Inicio();
                form.Show();
                this.Hide();

                form.FormClosing += Form_FormClosing;
            }
            else
            {
                MessageBox.Show("Nose encontro el usuario","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
           


        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {

            this.Show();
        }

    }
}
