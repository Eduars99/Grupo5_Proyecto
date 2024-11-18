
namespace Proyect_Database
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNombreTabla = new System.Windows.Forms.TextBox();
            this.dvgCampos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCrearTabla = new System.Windows.Forms.Button();
            this.NombreCampo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDato = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PrimaryKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCampos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombreTabla
            // 
            this.txtNombreTabla.Location = new System.Drawing.Point(204, 51);
            this.txtNombreTabla.Name = "txtNombreTabla";
            this.txtNombreTabla.Size = new System.Drawing.Size(139, 22);
            this.txtNombreTabla.TabIndex = 0;
            // 
            // dvgCampos
            // 
            this.dvgCampos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgCampos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreCampo,
            this.TipoDato,
            this.PrimaryKey,
            this.dgvNull});
            this.dvgCampos.Location = new System.Drawing.Point(41, 92);
            this.dvgCampos.Name = "dvgCampos";
            this.dvgCampos.RowHeadersWidth = 51;
            this.dvgCampos.RowTemplate.Height = 24;
            this.dvgCampos.Size = new System.Drawing.Size(583, 288);
            this.dvgCampos.TabIndex = 1;
            this.dvgCampos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgCampos_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre de la Tabla";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCrearTabla
            // 
            this.btnCrearTabla.Location = new System.Drawing.Point(192, 408);
            this.btnCrearTabla.Name = "btnCrearTabla";
            this.btnCrearTabla.Size = new System.Drawing.Size(151, 40);
            this.btnCrearTabla.TabIndex = 3;
            this.btnCrearTabla.Text = "Crear Tabla";
            this.btnCrearTabla.UseVisualStyleBackColor = true;
            this.btnCrearTabla.Click += new System.EventHandler(this.btnCrearTabla_Click);
            // 
            // NombreCampo
            // 
            this.NombreCampo.HeaderText = "Campos";
            this.NombreCampo.MinimumWidth = 6;
            this.NombreCampo.Name = "NombreCampo";
            this.NombreCampo.Width = 125;
            // 
            // TipoDato
            // 
            this.TipoDato.HeaderText = "Tipo de Datos";
            this.TipoDato.Items.AddRange(new object[] {
            "int",
            "varchar(50)",
            "date"});
            this.TipoDato.MinimumWidth = 6;
            this.TipoDato.Name = "TipoDato";
            this.TipoDato.Width = 125;
            // 
            // PrimaryKey
            // 
            this.PrimaryKey.HeaderText = "Llave Primaria";
            this.PrimaryKey.MinimumWidth = 6;
            this.PrimaryKey.Name = "PrimaryKey";
            this.PrimaryKey.Width = 125;
            // 
            // dgvNull
            // 
            this.dgvNull.HeaderText = "Allow Null";
            this.dgvNull.MinimumWidth = 6;
            this.dgvNull.Name = "dgvNull";
            this.dgvNull.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 475);
            this.Controls.Add(this.btnCrearTabla);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dvgCampos);
            this.Controls.Add(this.txtNombreTabla);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgCampos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreTabla;
        private System.Windows.Forms.DataGridView dvgCampos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCrearTabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCampo;
        private System.Windows.Forms.DataGridViewComboBoxColumn TipoDato;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PrimaryKey;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvNull;
    }
}

