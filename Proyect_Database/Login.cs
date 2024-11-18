using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyect_Database
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public void MostrarPerfil()
        {
            ClassRegistro createUsuario = new ClassRegistro();
            List<Usuario> temp = new List<Usuario>();
            int codigo = Convert.ToInt32(txtUserCode.Text);
            temp = createUsuario.ObtenerUsuario(codigo);
            foreach (Usuario mostrar in temp)
            {
                if (mostrar.Role == "Administrador")
                {
                    MessageBox.Show("PERFIL DE ADMINISTRADOR");
                    MenuAdmin mn = new MenuAdmin();
                    mn.Show();
                }
                else if (mostrar.Role == "Perfil de Empleado")
                {
                    MessageBox.Show("PERFIL DE EMPLEADO");
                    MenuAdmin mn = new MenuAdmin();
                    mn.Show();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                int UserCode;
                bool isNumeric = int.TryParse(txtUserCode.Text, out UserCode);
                string contrasena = txtPassword.Text;

                ClassRegistro con = new ClassRegistro();
                List<Usuario> temp = new List<Usuario>();

                temp = con.ObtenerLogin(UserCode, contrasena);
                if ((txtUserCode.Text == "") && (txtPassword.Text == ""))
                {
                    MessageBox.Show("Ingrese Usuario y Contraseña para continuar.", "Informacion Incompleta",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (temp.Count == 0)
                {
                    MessageBox.Show("Usuario no econtrado. Por favor, intente de nuevo o cree una cuenta");
                    txtUserCode.Clear();
                    txtPassword.Clear();
                }
                else
                {
                    MostrarPerfil();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
                if (checkBox1.Checked)
                {
                    txtPassword.UseSystemPasswordChar = false;
                }
                else
                {
                    txtPassword.UseSystemPasswordChar = true;
                } 
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registro rg = new Registro();
            this.Hide();
            rg.Show();
        }
    }
}
