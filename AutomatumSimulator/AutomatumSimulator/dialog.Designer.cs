namespace AutomatumSimulator
{
    partial class dialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
/*            this.leftRaftingContainer = new System.Windows.Forms.RaftingContainer();
            this.rightRaftingContainer = new System.Windows.Forms.RaftingContainer();
            this.topRaftingContainer = new System.Windows.Forms.RaftingContainer();
            this.bottomRaftingContainer = new System.Windows.Forms.RaftingContainer();*/
            this.label2 = new System.Windows.Forms.Label();
/*            ((System.ComponentModel.ISupportInitialize)(this.leftRaftingContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightRaftingContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topRaftingContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomRaftingContainer)).BeginInit();*/
            this.SuspendLayout();
// 
// label1
// 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el Nombre del Estado a crear: ";
            
// 
// button1
// 
            this.button1.Location = new System.Drawing.Point(13, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Aceptar";
            this.button1.Click += new System.EventHandler(this.button1_Click);
// 
// button2
// 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(105, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancelar";
            this.button2.Click += new System.EventHandler(this.button2_Click);
// 
// textBox1
// 
            this.textBox1.AutoSize = false;
            this.textBox1.Location = new System.Drawing.Point(13, 37);
            this.textBox1.MaxLength = 3;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(245, 23);
            this.textBox1.TabIndex = 3;
// 
// checkBox1
// 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(13, 67);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(128, 20);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Es un estado final";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
// 
// panel1
// 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(237, 91);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(24, 29);
            this.panel1.TabIndex = 6;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
// 
// leftRaftingContainer
// 
/*            this.leftRaftingContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftRaftingContainer.Name = "leftRaftingContainer";
// 
// rightRaftingContainer
// 
            this.rightRaftingContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightRaftingContainer.Name = "rightRaftingContainer";
// 
// topRaftingContainer
// 
            this.topRaftingContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.topRaftingContainer.Name = "topRaftingContainer";
// 
// bottomRaftingContainer
// 
            this.bottomRaftingContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomRaftingContainer.Name = "bottomRaftingContainer";*/
// 
// label2
// 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Color:";
// 
// dialog
// 
            this.AcceptButton = this.button1;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(274, 129);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
/*            this.Controls.Add(this.leftRaftingContainer);
            this.Controls.Add(this.rightRaftingContainer);
            this.Controls.Add(this.topRaftingContainer);
            this.Controls.Add(this.bottomRaftingContainer);*/
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos del Estado";
/*            ((System.ComponentModel.ISupportInitialize)(this.leftRaftingContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightRaftingContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topRaftingContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomRaftingContainer)).EndInit();*/
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel1;
/*        private System.Windows.Forms.RaftingContainer leftRaftingContainer;
        private System.Windows.Forms.RaftingContainer rightRaftingContainer;
        private System.Windows.Forms.RaftingContainer topRaftingContainer;
        private System.Windows.Forms.RaftingContainer bottomRaftingContainer;*/
        private System.Windows.Forms.Label label2;
    }
}