namespace InstitutoDesktop.Views.Horarios
{
    partial class AgregarEditarHoraView
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
            txtNombre = new TextBox();
            label1 = new Label();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            chkRecreo = new CheckBox();
            dateTimeDesde = new DateTimePicker();
            dateTimeHasta = new DateTimePicker();
            label2 = new Label();
            lblHasta = new Label();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 11F);
            txtNombre.Location = new Point(321, 166);
            txtNombre.Margin = new Padding(2);
            txtNombre.Name = "txtNombre";
            txtNombre.ReadOnly = true;
            txtNombre.Size = new Size(257, 32);
            txtNombre.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(222, 171);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(57, 25);
            label1.TabIndex = 11;
            label1.Text = "Hora:";
            // 
            // btnCancelar
            // 
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnCancelar.IconSize = 30;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(426, 309);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(127, 40);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnGuardar.IconSize = 30;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(264, 309);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(127, 40);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // chkRecreo
            // 
            chkRecreo.AutoSize = true;
            chkRecreo.Location = new Point(321, 233);
            chkRecreo.Name = "chkRecreo";
            chkRecreo.Size = new Size(77, 24);
            chkRecreo.TabIndex = 14;
            chkRecreo.Text = "Recreo";
            chkRecreo.UseVisualStyleBackColor = true;
            chkRecreo.CheckedChanged += chkRecreo_CheckedChanged;
            // 
            // dateTimeDesde
            // 
            dateTimeDesde.Format = DateTimePickerFormat.Time;
            dateTimeDesde.Location = new Point(321, 52);
            dateTimeDesde.Name = "dateTimeDesde";
            dateTimeDesde.Size = new Size(250, 27);
            dateTimeDesde.TabIndex = 15;
            dateTimeDesde.ValueChanged += dateTimeDesde_ValueChanged;
            // 
            // dateTimeHasta
            // 
            dateTimeHasta.Format = DateTimePickerFormat.Time;
            dateTimeHasta.Location = new Point(321, 103);
            dateTimeHasta.Name = "dateTimeHasta";
            dateTimeHasta.Size = new Size(250, 27);
            dateTimeHasta.TabIndex = 16;
            dateTimeHasta.ValueChanged += dateTimeHasta_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(222, 59);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 17;
            label2.Text = "Desde:";
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(222, 108);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(50, 20);
            lblHasta.TabIndex = 18;
            lblHasta.Text = "Hasta:";
            // 
            // AgregarEditarHoraView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(762, 471);
            Controls.Add(lblHasta);
            Controls.Add(label2);
            Controls.Add(dateTimeHasta);
            Controls.Add(dateTimeDesde);
            Controls.Add(chkRecreo);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Name = "AgregarEditarHoraView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Agregar/Editar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtNombre;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private CheckBox chkRecreo;
        private DateTimePicker dateTimeDesde;
        private DateTimePicker dateTimeHasta;
        private Label label2;
        private Label lblHasta;
    }
}