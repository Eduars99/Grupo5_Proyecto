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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

       

        public void Limipar()
        {
            txtUserCode.Clear();
            txtIdentidad.Clear();
            txtEmail.Clear();
            txtName.Clear();
            txtApellido.Clear();
            txtPassword.Clear();
            txtPhone.Clear();
            cmbRole.Text = string.Empty;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string password, DNI, name, lastname, email, phone, role;
                int user;
                ClassRegistro con = new ClassRegistro();
                //entradas
                user = Convert.ToInt32(txtUserCode.Text);
                name = txtName.Text.Trim();
                lastname = txtApellido.Text.Trim();
                phone = txtPhone.Text.Trim();
                password = txtPassword.Text.Trim();
                DNI = txtIdentidad.Text.Trim();
                email = txtEmail.Text.Trim();
                role = cmbRole.SelectedItem.ToString();

                //Procesos y salidas
                con.InsertarDatos(user, password, name, lastname, DNI, email, phone, role);
                MessageBox.Show("Registro guardado con exito");
                Limipar();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }

