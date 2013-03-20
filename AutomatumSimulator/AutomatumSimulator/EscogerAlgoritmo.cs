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
    partial class EscogerAlgoritmo : Form
    {
        public Boolean isTopDown = true;
        public EscogerAlgoritmo()
        {
            InitializeComponent();
        }

        private void topdown_CheckedChanged(object sender, EventArgs e)
        {
            bottomup.Checked = !topdown.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isTopDown = topdown.Checked;
            this.Close();
        }
    }
}