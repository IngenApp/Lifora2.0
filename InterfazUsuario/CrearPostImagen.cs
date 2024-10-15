﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazUsuario
{
    public partial class CrearPostImagen : Form
    {
        public Form crearPost;
        string rutaImagen;


        public CrearPostImagen()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Selecciona una imagen";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaImagen = openFileDialog.FileName;
                pictureBox1.Image = new Bitmap(rutaImagen);
            }
        }

        private void CrearPostImagen_FormClosing(object sender, FormClosingEventArgs e)
        {
            crearPost.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rutaImagen))
            {
                MessageBox.Show("Seleccione una imagen");
            }
            else
            {
                this.Close();

                if (crearPost != null && !crearPost.IsDisposed)
                {
                    crearPost.Close();
                }
                rutaImagen = string.Empty;
            }
        }

    }
}

