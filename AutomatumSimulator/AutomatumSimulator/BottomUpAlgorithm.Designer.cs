namespace AutomatumSimulator
{
    partial class BottomUpAlgorithm
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
            this.Cerrar = new System.Windows.Forms.Button();
            this.topleft = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.topright = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
// 
// label1
// 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(646, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "A continuacion se presentan los pasos realizados en el Algoritmo de Minimizacion " +
                "Bottom-up:";
// 
// Cerrar
// 
            this.Cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cerrar.Location = new System.Drawing.Point(320, 500);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(100, 30);
            this.Cerrar.TabIndex = 2;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
// 
// topleft
// 
            this.topleft.Location = new System.Drawing.Point(215, 500);
            this.topleft.Name = "topleft";
            this.topleft.Size = new System.Drawing.Size(30, 30);
            this.topleft.TabIndex = 0;
            this.topleft.Text = "<<";
            this.topleft.Click += new System.EventHandler(this.topleft_Click);
// 
// left
// 
            this.left.Location = new System.Drawing.Point(250, 500);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(30, 30);
            this.left.TabIndex = 3;
            this.left.Text = "<";
            this.left.Click += new System.EventHandler(this.left_Click);
// 
// right
// 
            this.right.Location = new System.Drawing.Point(460, 500);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(30, 30);
            this.right.TabIndex = 4;
            this.right.Text = ">";
            this.right.Click += new System.EventHandler(this.right_Click);
// 
// topright
// 
            this.topright.Location = new System.Drawing.Point(495, 500);
            this.topright.Name = "topright";
            this.topright.Size = new System.Drawing.Size(30, 30);
            this.topright.TabIndex = 5;
            this.topright.Text = ">>";
            this.topright.Click += new System.EventHandler(this.topright_Click);
// 
// panel1
// 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(670, 460);
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(13, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 443);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel1_Scroll);
// 
// label2
// 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(284, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
// 
// BottomUpAlgorithm
// 
            this.AcceptButton = this.Cerrar;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(667, 544);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.topright);
            this.Controls.Add(this.right);
            this.Controls.Add(this.left);
            this.Controls.Add(this.topleft);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "BottomUpAlgorithm";
            this.Text = "Pasos del Algoritmo Bottom-up";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.Button topleft;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button topright;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}