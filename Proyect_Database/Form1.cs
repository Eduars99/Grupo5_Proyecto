using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;


namespace Proyect_Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dvgCampos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCrearTabla_Click(object sender, EventArgs e)
        {
            // Obtener el nombre de la tabla desde el TextBox
            string nombreTabla = txtNombreTabla.Text.Trim();
            if (string.IsNullOrEmpty(nombreTabla))
            {
                MessageBox.Show("El nombre de la tabla es requerido.");
                return;
            }

            // Construir la estructura de la consulta SQL CREATE TABLE
            string sqlCreateTable = $"CREATE TABLE {nombreTabla} (";
            List<string> columnas = new List<string>();

            foreach (DataGridViewRow row in dvgCampos.Rows)
            {
                if (row.IsNewRow) continue; // Ignorar la fila vacía

                // Obtener el nombre del campo y el tipo de dato
                string nombreCampo = row.Cells["NombreCampo"].Value?.ToString();
                string tipoDato = row.Cells["TipoDato"].Value?.ToString();
                bool esLlavePrimaria = Convert.ToBoolean(row.Cells["PrimaryKey"].Value ?? false);
                bool permiteNull = Convert.ToBoolean(row.Cells["dgvNull"].Value ?? false);

                if (string.IsNullOrEmpty(nombreCampo) || string.IsNullOrEmpty(tipoDato))
                {
                    MessageBox.Show("Todos los campos deben tener un nombre y un tipo de dato.");
                    return;
                }

                // Crear la definición del campo
                string columna = $"{nombreCampo} {tipoDato}";

                // Agregar restricción de llave primaria o NULL
                if (esLlavePrimaria)
                {
                    columna += " PRIMARY KEY";
                }
                else if (!permiteNull)
                {
                    columna += " NOT NULL";
                }

                columnas.Add(columna);
            }

            // Completar la consulta CREATE TABLE
            sqlCreateTable += string.Join(", ", columnas) + ");";

            // Llamar al método para ejecutar la consulta SQL
            CrearTablaEnBaseDeDatos(sqlCreateTable);
        }

        private void CrearTablaEnBaseDeDatos(string sqlQuery)
        {
            try
            {
                using (var context = new TiendaEntities()) 
                {
                    context.Database.ExecuteSqlCommand(sqlQuery);
                    MessageBox.Show("La tabla se ha creado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la tabla: {ex.Message}");
            }
        }
    }
}
    

