#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#endregion

namespace AutomatumSimulator
{
    partial class EscogerEstado : Form
    {
        public String caracter;
        public String estadoEscogido = "";
        public Boolean isCorrect = false;
        public Hashtable lista = new Hashtable();
        public EscogerEstado(String caracter, Hashtable lista)
        {
            InitializeComponent();
            if (caracter == "")
            {
                label2.Font = new Font("Symbol", 11);
                this.caracter = "l";
            }
            else
                this.caracter = caracter;
            label2.Text = this.caracter;
            foreach(DictionaryEntry de in lista)
            {
                this.lista.Add(comboBox1.Items.Add((String)de.Key), (String)de.Value);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            estadoEscogido = (String)lista[comboBox1.SelectedIndex];
            isCorrect = true;
            this.Close();
        }

    }
}