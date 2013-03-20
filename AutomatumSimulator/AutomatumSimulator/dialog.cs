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
    partial class dialog : Form
    {
        public Boolean isCorrect = false;
        public String text = "";
        public Boolean isFinal = false;
        public Color color;
        public dialog(String texto, String texto2, Boolean isChecked, Color color)
        {
            InitializeComponent();
            label1.Text = texto;
            textBox1.Text = texto2;
            textBox1.Select();
            checkBox1.Checked = isChecked;
            panel1.BackColor = color;
            this.color = color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                isCorrect = true;
                text = textBox1.Text;
                color = colorDialog1.Color;
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isCorrect = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isFinal = !isFinal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
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