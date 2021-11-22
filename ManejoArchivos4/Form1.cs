using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ManejoArchivos4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos de texto (*.txt)|*.txt";

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK);
                {

                    if (File.Exists(openFileDialog1.FileName))
                    {
                        string texto = openFileDialog1.FileName;

                        TextReader leer = new StreamReader(texto);
                        textBox2.Text = leer.ReadToEnd();
                        leer.Close();

                        textBox1.Text = texto;
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("No se ha podido abrir correctamente este archivo");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Archivos de texto (*.txt)|*.txt";

            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog1.FileName))
                    {
                        string txt = saveFileDialog1.FileName;

                        StreamWriter textoguardar = File.CreateText(txt);
                        textoguardar.Write(textBox2.Text);
                        textoguardar.Close();

                        textBox1.Text = txt;
                    }
                    else
                    {
                        string txt = saveFileDialog1.FileName;

                        StreamWriter textoguardar = File.CreateText(txt);
                        textoguardar.Write(textBox2.Text);
                        textoguardar.Flush();
                        textoguardar.Close();

                        textBox1.Text = txt;
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar");
            }
        }
    }
}
