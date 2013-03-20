namespace AutomatumSimulator
{
    partial class EscogerAlgoritmo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.topdown = new System.Windows.Forms.RadioButton();
            this.bottomup = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
// 
// topdown
// 
            this.topdown.AutoSize = true;
            this.topdown.Checked = true;
            this.topdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topdown.Location = new System.Drawing.Point(72, 39);
            this.topdown.Name = "topdown";
            this.topdown.Size = new System.Drawing.Size(92, 22);
            this.topdown.TabIndex = 0;
            this.topdown.TabStop = true;
            this.topdown.Text = "Top-Down";
            this.topdown.CheckedChanged += new System.EventHandler(this.topdown_CheckedChanged);
// 
// bottomup
// 
            this.bottomup.AutoSize = true;
            this.bottomup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomup.Location = new System.Drawing.Point(174, 39);
            this.bottomup.Name = "bottomup";
            this.bottomup.Size = new System.Drawing.Size(95, 22);
            this.bottomup.TabIndex = 1;
            this.bottomup.Text = "Bottom-Up";
// 
// label1
// 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Elija el algoritmo de Minimizacion que desea utilizar:";
// 
// button1
// 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(72, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Aceptar";
            this.button1.Click += new System.EventHandler(this.button1_Click);
// 
// button2
// 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(174, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancelar";
// 
// EscogerAlgoritmo
// 
            this.AcceptButton = this.button1;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(372, 112);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bottomup);
            this.Controls.Add(this.topdown);
            this.Name = "EscogerAlgoritmo";
            this.Text = "Escoger Algoritmo de Minimizacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton topdown;
        private System.Windows.Forms.RadioButton bottomup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;


    }
}