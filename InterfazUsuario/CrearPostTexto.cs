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
   


    public partial class CrearPostTexto : Form
    {
        public Form crearPost;


        public CrearPostTexto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CrearPostTexto_FormClosing(object sender, FormClosingEventArgs e)
        {
            crearPost.Show();
        }
    }
}
