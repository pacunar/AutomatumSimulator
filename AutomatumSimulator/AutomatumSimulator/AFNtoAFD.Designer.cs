namespace AutomatumSimulator
{
    partial class AFNtoAFD
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
            this.AFNtoAFDtext = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
// 
// label1
// 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "A continuación los pasos para pasar de AFN a AFD";
// 
// AFNtoAFDtext
// 
            this.AFNtoAFDtext.AutoSize = false;
            this.AFNtoAFDtext.BackColor = System.Drawing.Color.White;
            this.AFNtoAFDtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AFNtoAFDtext.Location = new System.Drawing.Point(13, 51);
            this.AFNtoAFDtext.Multiline = true;
            this.AFNtoAFDtext.Name = "AFNtoAFDtext";
            this.AFNtoAFDtext.ReadOnly = true;
            this.AFNtoAFDtext.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.AFNtoAFDtext.Size = new System.Drawing.Size(602, 233);
            this.AFNtoAFDtext.TabIndex = 1;
            this.AFNtoAFDtext.WordWrap = false;
// 
// button1
// 
            this.button1.Location = new System.Drawing.Point(263, 297);
            this.button1.Name = "button1";
            this.button1.TabIndex = 2;
            this.button1.Text = "Ok";
            this.button1.Click += new System.EventHandler(this.button1_Click);
// 
// AFNtoAFD
// 
            this.AcceptButton = this.button1;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(627, 332);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AFNtoAFDtext);
            this.Controls.Add(this.label1);
            this.Name = "AFNtoAFD";
            this.Text = "AFNtoAFD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AFNtoAFDtext;
        private System.Windows.Forms.Button button1;
    }
}