namespace growshiUI.UsuarioForms.Inicio
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
            this.groupBoxCultivos = new System.Windows.Forms.GroupBox();
            this.buttonGestionarPlanta = new System.Windows.Forms.Button();
            this.buttonActualizarSlots = new System.Windows.Forms.Button();
            this.GroupBoxSlotsDisponible = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelSlots = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxSlot = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxCultivos.SuspendLayout();
            this.GroupBoxSlotsDisponible.SuspendLayout();
            this.flowLayoutPanelSlots.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCultivos
            // 
            this.groupBoxCultivos.Controls.Add(this.buttonGestionarPlanta);
            this.groupBoxCultivos.Controls.Add(this.buttonActualizarSlots);
            this.groupBoxCultivos.Controls.Add(this.GroupBoxSlotsDisponible);
            this.groupBoxCultivos.Enabled = false;
            this.groupBoxCultivos.Location = new System.Drawing.Point(160, 227);
            this.groupBoxCultivos.Name = "groupBoxCultivos";
            this.groupBoxCultivos.Size = new System.Drawing.Size(604, 346);
            this.groupBoxCultivos.TabIndex = 3;
            this.groupBoxCultivos.TabStop = false;
            // 
            // buttonGestionarPlanta
            // 
            this.buttonGestionarPlanta.Location = new System.Drawing.Point(34, 301);
            this.buttonGestionarPlanta.Name = "buttonGestionarPlanta";
            this.buttonGestionarPlanta.Size = new System.Drawing.Size(96, 23);
            this.buttonGestionarPlanta.TabIndex = 1;
            this.buttonGestionarPlanta.Text = "Gestionar planta ";
            this.buttonGestionarPlanta.UseVisualStyleBackColor = true;
            // 
            // buttonActualizarSlots
            // 
            this.buttonActualizarSlots.Location = new System.Drawing.Point(123, 301);
            this.buttonActualizarSlots.Name = "buttonActualizarSlots";
            this.buttonActualizarSlots.Size = new System.Drawing.Size(94, 23);
            this.buttonActualizarSlots.TabIndex = 1;
            this.buttonActualizarSlots.Text = "Actualizar Mundo";
            this.buttonActualizarSlots.UseVisualStyleBackColor = true;
            // 
            // GroupBoxSlotsDisponible
            // 
            this.GroupBoxSlotsDisponible.Controls.Add(this.flowLayoutPanelSlots);
            this.GroupBoxSlotsDisponible.Location = new System.Drawing.Point(17, 19);
            this.GroupBoxSlotsDisponible.Name = "GroupBoxSlotsDisponible";
            this.GroupBoxSlotsDisponible.Size = new System.Drawing.Size(560, 276);
            this.GroupBoxSlotsDisponible.TabIndex = 0;
            this.GroupBoxSlotsDisponible.TabStop = false;
            // 
            // flowLayoutPanelSlots
            // 
            this.flowLayoutPanelSlots.Controls.Add(this.groupBoxSlot);
            this.flowLayoutPanelSlots.Location = new System.Drawing.Point(36, 28);
            this.flowLayoutPanelSlots.Name = "flowLayoutPanelSlots";
            this.flowLayoutPanelSlots.Size = new System.Drawing.Size(491, 232);
            this.flowLayoutPanelSlots.TabIndex = 1;
            // 
            // groupBoxSlot
            // 
            this.groupBoxSlot.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSlot.Name = "groupBoxSlot";
            this.groupBoxSlot.Size = new System.Drawing.Size(200, 100);
            this.groupBoxSlot.TabIndex = 0;
            this.groupBoxSlot.TabStop = false;
            this.groupBoxSlot.Text = "Slot 1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(127, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(680, 39);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "GROWSHI";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 676);
            this.Controls.Add(this.groupBoxCultivos);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxCultivos.ResumeLayout(false);
            this.GroupBoxSlotsDisponible.ResumeLayout(false);
            this.flowLayoutPanelSlots.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCultivos;
        private System.Windows.Forms.Button buttonGestionarPlanta;
        private System.Windows.Forms.Button buttonActualizarSlots;
        private System.Windows.Forms.GroupBox GroupBoxSlotsDisponible;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSlots;
        private System.Windows.Forms.GroupBox groupBoxSlot;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
    }
}