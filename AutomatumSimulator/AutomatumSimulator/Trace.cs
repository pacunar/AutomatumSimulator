#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#endregion

namespace AutomatumSimulator
{
    partial class Trace : Form
    {
        public Trace(String inputLabel)
        {
            InitializeComponent();
            input.Text = inputLabel;
            traceText.DeselectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void refresh(String texto)
        {
            traceText.AppendText(texto);
        }
    }
}