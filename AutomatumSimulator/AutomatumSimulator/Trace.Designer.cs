namespace AutomatumSimulator
{
    partial class Trace
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
            this.input = new System.Windows.Forms.Label();
            this.traceText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
// 
// label1
// 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "A continuación el cambio de estados dado el input:";
// 
// input
// 
            this.input.AutoSize = true;
            this.input.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input.Location = new System.Drawing.Point(29, 32);
            this.input.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(8, 17);
            this.input.TabIndex = 2;
            this.input.Text = "l";
// 
// traceText
// 
            this.traceText.AutoSize = false;
            this.traceText.BackColor = System.Drawing.Color.White;
            this.traceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.traceText.ForeColor = System.Drawing.Color.MediumBlue;
            this.traceText.Location = new System.Drawing.Point(18, 56);
            this.traceText.Multiline = true;
            this.traceText.Name = "traceText";
            this.traceText.ReadOnly = true;
            this.traceText.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.traceText.Size = new System.Drawing.Size(314, 52);
            this.traceText.TabIndex = 3;
            this.traceText.WordWrap = false;
// 
// button1
// 
            this.button1.Location = new System.Drawing.Point(135, 115);
            this.button1.Name = "button1";
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.Click += new System.EventHandler(this.button1_Click);
// 
// Trace
// 
            this.AcceptButton = this.button1;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(343, 152);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.traceText);
            this.Controls.Add(this.input);
            this.Controls.Add(this.label1);
            this.Name = "Trace";
            this.Text = "Cambio de Estados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label input;
        private System.Windows.Forms.TextBox traceText;
        private System.Windows.Forms.Button button1;
    }
}