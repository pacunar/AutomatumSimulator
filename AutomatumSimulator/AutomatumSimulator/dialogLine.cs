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
    partial class dialogLine : Form
    {
        public Boolean isCorrect = false;
        public Boolean isAfnCorrect = false;
        public String text = "";
        public Color color;
        public String afnText = null;
        public dialogLine(String texto, Boolean colorLabelVisible, Boolean colorPanelVisible)
        {
            InitializeComponent();
            label1.Text = texto;
            color = Color.Black;
            panel1.BackColor = colorDialog1.Color;
            label2.Visible = colorLabelVisible;
            panel1.Visible = colorPanelVisible;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                isCorrect = isAfnCorrect = true;
                text = afnText = textBox1.Text;
                color = colorDialog1.Color;
            }
            else
            {
                isAfnCorrect = true;
                afnText = "";
                color = colorDialog1.Color;
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isCorrect = false;
            isAfnCorrect = false;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                panel1.BackColor = colorDialog1.Color;
            }
        }
    }
}