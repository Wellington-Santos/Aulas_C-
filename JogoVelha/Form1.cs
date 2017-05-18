using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoVelha
{
    public partial class Form1 : Form
    {
        bool xis = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            B11.Click += new EventHandler(BClick);
            B12.Click += new EventHandler(BClick);
            B13.Click += new EventHandler(BClick);
            B21.Click += new EventHandler(BClick);
            B22.Click += new EventHandler(BClick);
            B23.Click += new EventHandler(BClick);
            B31.Click += new EventHandler(BClick);
            B32.Click += new EventHandler(BClick);
            B33.Click += new EventHandler(BClick);

            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    item.TabStop = false;
                }
            }
        }

        private void BClick(object sender, EventArgs e)
        {
            ((Button)sender).Text = this.xis ? "X" : "O";
            ((Button)sender).Enabled = false;

            VerificarGanhador();
            xis = !xis;
            label1.Text = string.Format("{0}, é a sua vez", this.xis ? "X" : "O");
        }

        private void VerificarGanhador()
        {
            if (
                B11.Text != String.Empty && B11.Text == B12.Text && B12.Text == B13.Text || //Linha 1
                B21.Text != String.Empty && B21.Text == B22.Text && B22.Text == B23.Text || //Linha 2
                B31.Text != String.Empty && B31.Text == B32.Text && B32.Text == B33.Text || //Linha 3 
                 
                B11.Text != String.Empty && B11.Text == B21.Text && B21.Text == B31.Text || //Coluna 1 
                B12.Text != String.Empty && B12.Text == B22.Text && B22.Text == B32.Text || //Coluna 2 
                B11.Text != String.Empty && B13.Text == B23.Text && B23.Text == B33.Text || //Coluna 3 


                B11.Text != String.Empty && B11.Text == B22.Text && B22.Text == B33.Text || //Linha \  
                B13.Text != String.Empty && B13.Text == B22.Text && B22.Text == B31.Text  //Linha /
              )
            {
                MessageBox.Show(String.Format("O ganhador é o [{0}]", xis ? "X" : "O"), "Temos um Vitorio",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                Reiniciar();
            }
            else
            {
                VerificarEmpate();
            }
        }

        private void VerificarEmpate()
        {
            bool todosDesabilitados = true;

            foreach (Control item in this.Controls)
            {
                if (item is Button && item.Enabled)
                {
                    todosDesabilitados = false;
                    break;
                }
            }

            if (todosDesabilitados)
            {
                MessageBox.Show(String.Format("Deu empate"), "Ops!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Reiniciar();
            }
        }

        private void Reiniciar()
        {
            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    item.Enabled = true;
                    item.Text = String.Empty;
                }
            }
        }
    }
}
