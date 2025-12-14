namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanta
{
    partial class PlantaResumenForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTituloPlanta = new MetroFramework.Controls.MetroLabel();
            this.pnlInfoGeneral = new MetroFramework.Controls.MetroPanel();
            this.lblFechaCosecha = new MetroFramework.Controls.MetroLabel();
            this.lblFechaSiembra = new MetroFramework.Controls.MetroLabel();
            this.lblPlanAsignado = new MetroFramework.Controls.MetroLabel();
            this.lblTituloInfo = new MetroFramework.Controls.MetroLabel();
            this.pnlEstadoActual = new MetroFramework.Controls.MetroPanel();
            this.lblProgresoDia = new MetroFramework.Controls.MetroLabel();
            this.lblEtapaActual = new MetroFramework.Controls.MetroLabel();
            this.progresoEtapa = new MetroFramework.Controls.MetroProgressBar();
            this.lblTituloEstado = new MetroFramework.Controls.MetroLabel();
            this.pnlMediciones = new MetroFramework.Controls.MetroPanel();
            this.lblUltimaMedicion = new MetroFramework.Controls.MetroLabel();
            this.lblLuminosidadVal = new MetroFramework.Controls.MetroLabel();
            this.lblHumedadVal = new MetroFramework.Controls.MetroLabel();
            this.lblTempVal = new MetroFramework.Controls.MetroLabel();
            this.lblLuminosidad = new MetroFramework.Controls.MetroLabel();
            this.lblHumedad = new MetroFramework.Controls.MetroLabel();
            this.lblTemperatura = new MetroFramework.Controls.MetroLabel();
            this.lblTituloMediciones = new MetroFramework.Controls.MetroLabel();
            this.btnEliminarPlanta = new MetroFramework.Controls.MetroButton();
            this.btnCerrar = new MetroFramework.Controls.MetroButton();
            this.pnlInfoGeneral.SuspendLayout();
            this.pnlEstadoActual.SuspendLayout();
            this.pnlMediciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloPlanta
            // 
            this.lblTituloPlanta.AutoSize = true;
            this.lblTituloPlanta.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTituloPlanta.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTituloPlanta.Location = new System.Drawing.Point(23, 60);
            this.lblTituloPlanta.Name = "lblTituloPlanta";
            this.lblTituloPlanta.Size = new System.Drawing.Size(213, 25);
            this.lblTituloPlanta.Style = MetroFramework.MetroColorStyle.Green;
            this.lblTituloPlanta.TabIndex = 0;
            this.lblTituloPlanta.Text = "Planta: [NombrePlanta]";
            this.lblTituloPlanta.UseStyleColors = true;
            // 
            // pnlInfoGeneral
            // 
            this.pnlInfoGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfoGeneral.Controls.Add(this.lblFechaCosecha);
            this.pnlInfoGeneral.Controls.Add(this.lblFechaSiembra);
            this.pnlInfoGeneral.Controls.Add(this.lblPlanAsignado);
            this.pnlInfoGeneral.Controls.Add(this.lblTituloInfo);
            this.pnlInfoGeneral.HorizontalScrollbarBarColor = true;
            this.pnlInfoGeneral.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlInfoGeneral.HorizontalScrollbarSize = 10;
            this.pnlInfoGeneral.Location = new System.Drawing.Point(23, 100);
            this.pnlInfoGeneral.Name = "pnlInfoGeneral";
            this.pnlInfoGeneral.Size = new System.Drawing.Size(350, 160);
            this.pnlInfoGeneral.TabIndex = 1;
            this.pnlInfoGeneral.VerticalScrollbarBarColor = true;
            this.pnlInfoGeneral.VerticalScrollbarHighlightOnWheel = false;
            this.pnlInfoGeneral.VerticalScrollbarSize = 10;
            // 
            // lblFechaCosecha
            // 
            this.lblFechaCosecha.AutoSize = true;
            this.lblFechaCosecha.Location = new System.Drawing.Point(15, 110);
            this.lblFechaCosecha.Name = "lblFechaCosecha";
            this.lblFechaCosecha.Size = new System.Drawing.Size(168, 19);
            this.lblFechaCosecha.TabIndex = 6;
            this.lblFechaCosecha.Text = "Estimada Cosecha: --/--/--";
            // 
            // lblFechaSiembra
            // 
            this.lblFechaSiembra.AutoSize = true;
            this.lblFechaSiembra.Location = new System.Drawing.Point(15, 80);
            this.lblFechaSiembra.Name = "lblFechaSiembra";
            this.lblFechaSiembra.Size = new System.Drawing.Size(149, 19);
            this.lblFechaSiembra.TabIndex = 5;
            this.lblFechaSiembra.Text = "Fecha Siembra: --/--/--";
            // 
            // lblPlanAsignado
            // 
            this.lblPlanAsignado.AutoSize = true;
            this.lblPlanAsignado.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblPlanAsignado.Location = new System.Drawing.Point(15, 45);
            this.lblPlanAsignado.Name = "lblPlanAsignado";
            this.lblPlanAsignado.Size = new System.Drawing.Size(166, 19);
            this.lblPlanAsignado.TabIndex = 4;
            this.lblPlanAsignado.Text = "Plan de Cultivo: [Nombre]";
            // 
            // lblTituloInfo
            // 
            this.lblTituloInfo.AutoSize = true;
            this.lblTituloInfo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTituloInfo.Location = new System.Drawing.Point(10, 10);
            this.lblTituloInfo.Name = "lblTituloInfo";
            this.lblTituloInfo.Size = new System.Drawing.Size(146, 19);
            this.lblTituloInfo.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblTituloInfo.TabIndex = 2;
            this.lblTituloInfo.Text = "Información General";
            this.lblTituloInfo.UseStyleColors = true;
            // 
            // pnlEstadoActual
            // 
            this.pnlEstadoActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEstadoActual.Controls.Add(this.lblProgresoDia);
            this.pnlEstadoActual.Controls.Add(this.lblEtapaActual);
            this.pnlEstadoActual.Controls.Add(this.progresoEtapa);
            this.pnlEstadoActual.Controls.Add(this.lblTituloEstado);
            this.pnlEstadoActual.HorizontalScrollbarBarColor = true;
            this.pnlEstadoActual.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlEstadoActual.HorizontalScrollbarSize = 10;
            this.pnlEstadoActual.Location = new System.Drawing.Point(390, 100);
            this.pnlEstadoActual.Name = "pnlEstadoActual";
            this.pnlEstadoActual.Size = new System.Drawing.Size(350, 160);
            this.pnlEstadoActual.TabIndex = 2;
            this.pnlEstadoActual.VerticalScrollbarBarColor = true;
            this.pnlEstadoActual.VerticalScrollbarHighlightOnWheel = false;
            this.pnlEstadoActual.VerticalScrollbarSize = 10;
            // 
            // lblProgresoDia
            // 
            this.lblProgresoDia.AutoSize = true;
            this.lblProgresoDia.Location = new System.Drawing.Point(15, 80);
            this.lblProgresoDia.Name = "lblProgresoDia";
            this.lblProgresoDia.Size = new System.Drawing.Size(71, 19);
            this.lblProgresoDia.TabIndex = 5;
            this.lblProgresoDia.Text = "Día X de Y";
            // 
            // lblEtapaActual
            // 
            this.lblEtapaActual.AutoSize = true;
            this.lblEtapaActual.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblEtapaActual.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblEtapaActual.Location = new System.Drawing.Point(15, 45);
            this.lblEtapaActual.Name = "lblEtapaActual";
            this.lblEtapaActual.Size = new System.Drawing.Size(168, 25);
            this.lblEtapaActual.TabIndex = 4;
            this.lblEtapaActual.Text = "[Germinación / Veg]";
            // 
            // progresoEtapa
            // 
            this.progresoEtapa.Location = new System.Drawing.Point(15, 110);
            this.progresoEtapa.Name = "progresoEtapa";
            this.progresoEtapa.Size = new System.Drawing.Size(315, 23);
            this.progresoEtapa.Style = MetroFramework.MetroColorStyle.Green;
            this.progresoEtapa.TabIndex = 3;
            this.progresoEtapa.Value = 35;
            // 
            // lblTituloEstado
            // 
            this.lblTituloEstado.AutoSize = true;
            this.lblTituloEstado.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTituloEstado.Location = new System.Drawing.Point(10, 10);
            this.lblTituloEstado.Name = "lblTituloEstado";
            this.lblTituloEstado.Size = new System.Drawing.Size(99, 19);
            this.lblTituloEstado.Style = MetroFramework.MetroColorStyle.Orange;
            this.lblTituloEstado.TabIndex = 2;
            this.lblTituloEstado.Text = "Estado Actual";
            this.lblTituloEstado.UseStyleColors = true;
            // 
            // pnlMediciones
            // 
            this.pnlMediciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMediciones.Controls.Add(this.lblUltimaMedicion);
            this.pnlMediciones.Controls.Add(this.lblLuminosidadVal);
            this.pnlMediciones.Controls.Add(this.lblHumedadVal);
            this.pnlMediciones.Controls.Add(this.lblTempVal);
            this.pnlMediciones.Controls.Add(this.lblLuminosidad);
            this.pnlMediciones.Controls.Add(this.lblHumedad);
            this.pnlMediciones.Controls.Add(this.lblTemperatura);
            this.pnlMediciones.Controls.Add(this.lblTituloMediciones);
            this.pnlMediciones.HorizontalScrollbarBarColor = true;
            this.pnlMediciones.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMediciones.HorizontalScrollbarSize = 10;
            this.pnlMediciones.Location = new System.Drawing.Point(23, 280);
            this.pnlMediciones.Name = "pnlMediciones";
            this.pnlMediciones.Size = new System.Drawing.Size(717, 160);
            this.pnlMediciones.TabIndex = 3;
            this.pnlMediciones.VerticalScrollbarBarColor = true;
            this.pnlMediciones.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMediciones.VerticalScrollbarSize = 10;
            // 
            // lblUltimaMedicion
            // 
            this.lblUltimaMedicion.AutoSize = true;
            this.lblUltimaMedicion.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblUltimaMedicion.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblUltimaMedicion.Location = new System.Drawing.Point(520, 130);
            this.lblUltimaMedicion.Name = "lblUltimaMedicion";
            this.lblUltimaMedicion.Size = new System.Drawing.Size(184, 15);
            this.lblUltimaMedicion.TabIndex = 9;
            this.lblUltimaMedicion.Text = "Última medición: Hace 5 minutos";
            // 
            // lblLuminosidadVal
            // 
            this.lblLuminosidadVal.AutoSize = true;
            this.lblLuminosidadVal.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblLuminosidadVal.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblLuminosidadVal.Location = new System.Drawing.Point(520, 75);
            this.lblLuminosidadVal.Name = "lblLuminosidadVal";
            this.lblLuminosidadVal.Size = new System.Drawing.Size(42, 25);
            this.lblLuminosidadVal.Style = MetroFramework.MetroColorStyle.Yellow;
            this.lblLuminosidadVal.TabIndex = 8;
            this.lblLuminosidadVal.Text = "--%";
            this.lblLuminosidadVal.UseStyleColors = true;
            // 
            // lblHumedadVal
            // 
            this.lblHumedadVal.AutoSize = true;
            this.lblHumedadVal.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblHumedadVal.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblHumedadVal.Location = new System.Drawing.Point(280, 75);
            this.lblHumedadVal.Name = "lblHumedadVal";
            this.lblHumedadVal.Size = new System.Drawing.Size(42, 25);
            this.lblHumedadVal.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblHumedadVal.TabIndex = 7;
            this.lblHumedadVal.Text = "--%";
            this.lblHumedadVal.UseStyleColors = true;
            // 
            // lblTempVal
            // 
            this.lblTempVal.AutoSize = true;
            this.lblTempVal.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTempVal.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTempVal.Location = new System.Drawing.Point(40, 75);
            this.lblTempVal.Name = "lblTempVal";
            this.lblTempVal.Size = new System.Drawing.Size(49, 25);
            this.lblTempVal.Style = MetroFramework.MetroColorStyle.Red;
            this.lblTempVal.TabIndex = 6;
            this.lblTempVal.Text = "-- °C";
            this.lblTempVal.UseStyleColors = true;
            // 
            // lblLuminosidad
            // 
            this.lblLuminosidad.AutoSize = true;
            this.lblLuminosidad.Location = new System.Drawing.Point(520, 50);
            this.lblLuminosidad.Name = "lblLuminosidad";
            this.lblLuminosidad.Size = new System.Drawing.Size(28, 19);
            this.lblLuminosidad.TabIndex = 5;
            this.lblLuminosidad.Text = "Luz";
            // 
            // lblHumedad
            // 
            this.lblHumedad.AutoSize = true;
            this.lblHumedad.Location = new System.Drawing.Point(280, 50);
            this.lblHumedad.Name = "lblHumedad";
            this.lblHumedad.Size = new System.Drawing.Size(67, 19);
            this.lblHumedad.TabIndex = 4;
            this.lblHumedad.Text = "Humedad";
            // 
            // lblTemperatura
            // 
            this.lblTemperatura.AutoSize = true;
            this.lblTemperatura.Location = new System.Drawing.Point(40, 50);
            this.lblTemperatura.Name = "lblTemperatura";
            this.lblTemperatura.Size = new System.Drawing.Size(83, 19);
            this.lblTemperatura.TabIndex = 3;
            this.lblTemperatura.Text = "Temperatura";
            // 
            // lblTituloMediciones
            // 
            this.lblTituloMediciones.AutoSize = true;
            this.lblTituloMediciones.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTituloMediciones.Location = new System.Drawing.Point(10, 10);
            this.lblTituloMediciones.Name = "lblTituloMediciones";
            this.lblTituloMediciones.Size = new System.Drawing.Size(166, 19);
            this.lblTituloMediciones.Style = MetroFramework.MetroColorStyle.Teal;
            this.lblTituloMediciones.TabIndex = 2;
            this.lblTituloMediciones.Text = "Sensores (Tiempo Real)";
            this.lblTituloMediciones.UseStyleColors = true;
            // 
            // btnEliminarPlanta
            // 
            this.btnEliminarPlanta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEliminarPlanta.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnEliminarPlanta.Location = new System.Drawing.Point(23, 460);
            this.btnEliminarPlanta.Name = "btnEliminarPlanta";
            this.btnEliminarPlanta.Size = new System.Drawing.Size(150, 40);
            this.btnEliminarPlanta.Style = MetroFramework.MetroColorStyle.Red;
            this.btnEliminarPlanta.TabIndex = 4;
            this.btnEliminarPlanta.Text = "Eliminar Planta";
            this.btnEliminarPlanta.UseCustomBackColor = true;
            this.btnEliminarPlanta.UseSelectable = true;
            this.btnEliminarPlanta.UseStyleColors = true;
            this.btnEliminarPlanta.Click += new System.EventHandler(this.btnEliminarPlanta_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(620, 460);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 40);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Volver";
            this.btnCerrar.UseSelectable = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PlantaResumenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 530);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnEliminarPlanta);
            this.Controls.Add(this.pnlMediciones);
            this.Controls.Add(this.pnlEstadoActual);
            this.Controls.Add(this.pnlInfoGeneral);
            this.Controls.Add(this.lblTituloPlanta);
            this.MaximizeBox = false;
            this.Name = "PlantaResumenForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Resumen de Planta";
            this.pnlInfoGeneral.ResumeLayout(false);
            this.pnlInfoGeneral.PerformLayout();
            this.pnlEstadoActual.ResumeLayout(false);
            this.pnlEstadoActual.PerformLayout();
            this.pnlMediciones.ResumeLayout(false);
            this.pnlMediciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblTituloPlanta;

        // Panel Info General
        private MetroFramework.Controls.MetroPanel pnlInfoGeneral;
        private MetroFramework.Controls.MetroLabel lblTituloInfo;
        private MetroFramework.Controls.MetroLabel lblPlanAsignado;
        private MetroFramework.Controls.MetroLabel lblFechaSiembra;
        private MetroFramework.Controls.MetroLabel lblFechaCosecha;

        // Panel Estado Actual
        private MetroFramework.Controls.MetroPanel pnlEstadoActual;
        private MetroFramework.Controls.MetroLabel lblTituloEstado;
        private MetroFramework.Controls.MetroProgressBar progresoEtapa;
        private MetroFramework.Controls.MetroLabel lblEtapaActual;
        private MetroFramework.Controls.MetroLabel lblProgresoDia;

        // Panel Mediciones
        private MetroFramework.Controls.MetroPanel pnlMediciones;
        private MetroFramework.Controls.MetroLabel lblTituloMediciones;
        private MetroFramework.Controls.MetroLabel lblTemperatura;
        private MetroFramework.Controls.MetroLabel lblHumedad;
        private MetroFramework.Controls.MetroLabel lblLuminosidad;
        private MetroFramework.Controls.MetroLabel lblTempVal;
        private MetroFramework.Controls.MetroLabel lblHumedadVal;
        private MetroFramework.Controls.MetroLabel lblLuminosidadVal;
        private MetroFramework.Controls.MetroLabel lblUltimaMedicion;

        // Botones
        private MetroFramework.Controls.MetroButton btnEliminarPlanta;
        private MetroFramework.Controls.MetroButton btnCerrar;
    }
}