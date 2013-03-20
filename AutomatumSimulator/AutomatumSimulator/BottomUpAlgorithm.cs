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
    partial class BottomUpAlgorithm : Form
    {
        ArrayList pasos = new ArrayList();
        ArrayList pasosExplicacion = new ArrayList();
        int pasosCounter;
        ArrayList estados = new ArrayList();
        public BottomUpAlgorithm(ArrayList pasos, ArrayList pasosExplicacion)
        {
            InitializeComponent();
            this.pasos = pasos;
            this.pasosExplicacion = pasosExplicacion;
            pasosCounter = 0;
            Hashtable paso = (Hashtable)pasos[0];
            foreach (DictionaryEntry de in paso)
            {
                if (((breakKey((String)de.Key))[0] != "sBasura") && ((breakKey((String)de.Key))[1] != "sBasura"))
                {
                    if (!(estados.Contains((breakKey((String)de.Key))[0])))
                        estados.Add((breakKey((String)de.Key))[0]);
                    if (!(estados.Contains((breakKey((String)de.Key))[1])))
                        estados.Add((breakKey((String)de.Key))[1]);
                }
            }
            ordenar();

        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (pasosCounter == 0)
            {
                topleft.Enabled = left.Enabled = false;
                right.Enabled = topright.Enabled = true;
            }
            else
            {
                if (pasosCounter == (pasos.Count - 1))
                {
                    topleft.Enabled = left.Enabled = true;
                    topright.Enabled = right.Enabled = false;
                }
                else
                {
                    topleft.Enabled = left.Enabled = topright.Enabled = right.Enabled = true;
                }
            }
            Graphics g = e.Graphics;
            g.TranslateTransform(panel1.AutoScrollPosition.X, panel1.AutoScrollPosition.Y);
            Font font = new Font("Arial", 12);
            Pen pencil = new Pen(Color.Black, 2);
            SolidBrush brush = new SolidBrush(Color.Black);

            Hashtable paso = (Hashtable)pasos[pasosCounter];
            label2.Text = (String)pasosExplicacion[pasosCounter];

            Size scrollOffset = new Size(panel1.AutoScrollPosition);
            int width = scrollOffset.Width;
            int heigth = scrollOffset.Height;

            int xinicial = 150;
            int yinicial = 30;

            g.DrawRectangle(pencil, xinicial + width, yinicial + heigth, (xinicial + (estados.Count * 25)), yinicial + (estados.Count * 25));

            //escribir nombre estados

            for (int i = 1; i < estados.Count; i++)
            {
                g.DrawString((String)estados[i], font, brush, xinicial + 3 + width, yinicial +(i* 25) + heigth);
                g.DrawLine(pencil, xinicial + width, yinicial + heigth + (i * 25), (xinicial + (i * 50)) + width + 30, yinicial + heigth + (i * 25));
                for (int j = 0; j < i; j++)
                    g.DrawString((String)paso[(String)estados[j] + ":" + (String)estados[i]], font, brush, xinicial + ((j+1)*45) + width, yinicial + (i * 25) + heigth);
            }
            g.DrawLine(pencil, xinicial + width, yinicial + heigth + (estados.Count * 25), (xinicial + (estados.Count * 46)) + width, yinicial + heigth + (estados.Count * 25));
            for (int i = 0; i < (estados.Count - 1); i++)
            {
                g.DrawString((String)estados[i], font, brush, xinicial + (i * 50) + 35 + width, yinicial + (estados.Count * 25) + heigth);
                g.DrawLine(pencil, xinicial + (i * 50) + 30 + width, yinicial + (i  * 25) + heigth, xinicial + (i * 50) + 30 + width, yinicial + ((estados.Count + 1) * 26) + heigth);
            }
            g.DrawLine(pencil, xinicial + ((estados.Count-1) * 50) + 30 + width, yinicial + ((estados.Count-1) * 25) + heigth, xinicial + ((estados.Count-1) * 50) + 30 + width, yinicial + ((estados.Count + 1) * 26) + heigth);


        }

        private void topleft_Click(object sender, EventArgs e)
        {
            pasosCounter = 0;
            panel1.Refresh();
        }

        private void left_Click(object sender, EventArgs e)
        {
            pasosCounter--;
            panel1.Refresh();
        }

        private void right_Click(object sender, EventArgs e)
        {
            pasosCounter++;
            panel1.Refresh();
        }

        private void topright_Click(object sender, EventArgs e)
        {
            pasosCounter = pasos.Count - 1;
            panel1.Refresh();
        }

        public String[] breakKey(String key)
        {
            String stateKey = "";
            String caracterKey = "";
            String[] toReturn = new String[2];
            int i = 0;
            for (i = 0; i < key.Length; i++)
            {
                if (key[i] == ':')
                    break;
            }
            stateKey = key.Substring(0, i);
            caracterKey = key.Substring(i + 1);
            toReturn[0] = stateKey;
            toReturn[1] = caracterKey;
            return toReturn;
        }

        private void ordenar()
        {
            String[] keys = new String[estados.Count];
            int counter = 0;
            foreach (String statelabel in estados)
            {
                keys[counter++] = statelabel;
            }
            Boolean isChanged = true;
            while (isChanged)
            {
                isChanged = false;
                for (int i = 0; i < (keys.Length - 1); i++)
                    if (String.CompareOrdinal(keys[i], keys[i + 1]) > 0)
                    {
                        isChanged = true;
                        String toSwap = keys[i];
                        keys[i] = keys[i + 1];
                        keys[i + 1] = toSwap;
                    }
            }

            estados.Clear();
            for (int i = 0; i < keys.Length; i++)
                estados.Add(keys[i]);
        }


    }
} 