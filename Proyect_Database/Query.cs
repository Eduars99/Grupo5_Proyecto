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
    public partial class Query : Form
    {
        public Query()
        {
            InitializeComponent();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            // Obtener la sentencia SQL del cuadro de texto
            string sentenciaSQL = txtSentenciaSQL.Text.Trim();
            string tablaSeleccionada = cmbTablas.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(sentenciaSQL))
            {
                MessageBox.Show("Por favor, ingresa una sentencia SQL.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (var context = new TiendaEntities()) // Reemplaza con tu contexto de Entity Framework
                {
                    if (sentenciaSQL.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                    {
                        // Usar un DataTable para cargar los resultados
                        var dataTable = new DataTable();
                        var connection = context.Database.Connection;

                        connection.Open();
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = sentenciaSQL;
                            using (var reader = command.ExecuteReader())
                            {
                                dataTable.Load(reader); // Cargar los datos en el DataTable
                            }
                        }
                        connection.Close();

                        // Mostrar los datos en el DataGridView
                        dgvInfo.DataSource = dataTable;
                        MessageBox.Show("Consulta ejecutada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        /* // Ejecución de consultas SELECT y mostrar en el DataGridView
                         var resultados = context.Database.SqlQuery<object>(sentenciaSQL).ToList();
                         dgvInfo.DataSource = resultados;
                         MessageBox.Show("Consulta ejecutada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                    }
                    else
                    {
                        // Ejecución de otras sentencias SQL
                        int filasAfectadas = context.Database.ExecuteSqlCommand(sentenciaSQL);
                        MessageBox.Show($"Sentencia ejecutada correctamente. Filas afectadas: {filasAfectadas}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // dgvResultados.DataSource = null; // Limpiar resultados previos
                        
                        if (!string.IsNullOrEmpty(tablaSeleccionada))
                        {
                            CargarDatosDeTabla(tablaSeleccionada); // Recargar datos en el DataGridView
                        }
                    }
                }
                txtSentenciaSQL.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Query_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TiendaEntities()) // Reemplaza con el nombre de tu contexto de Entity Framework
                {
                    // Ejecutar una consulta para obtener los nombres de las tablas en la base de datos
                    var tablas = context.Database.SqlQuery<string>(
                        "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'"
                    ).ToList();

                    // Asignar la lista de tablas al ComboBox
                    cmbTablas.DataSource = tablas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las tablas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosDeTabla(string nombreTabla)
        {
            try
            {
                using (var context = new TiendaEntities()) // Reemplaza con tu contexto de Entity Framework
                {
                    // Crear una consulta dinámica para seleccionar todos los datos de la tabla seleccionada
                    string consultaSQL = $"SELECT * FROM {nombreTabla}";

                    // Ejecutar la consulta y cargar los resultados en un DataTable
                    var dataTable = new DataTable();
                    var connection = context.Database.Connection;

                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = consultaSQL;
                        using (var reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader); // Cargar los datos en el DataTable
                        }
                    }
                    connection.Close();

                    // Asignar el DataTable como fuente de datos para el DataGridView
                    dgvResultados.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos de la tabla {nombreTabla}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el nombre de la tabla seleccionada
            string tablaSeleccionada = cmbTablas.SelectedItem.ToString();

            // Cargar los datos de la tabla seleccionada y mostrarlos en el DataGridView
            CargarDatosDeTabla(tablaSeleccionada);
        }

        private void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
