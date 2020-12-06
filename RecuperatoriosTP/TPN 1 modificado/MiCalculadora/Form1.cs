using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class frmCalculadora : Form
    {
        public frmCalculadora()
        {
            InitializeComponent();
            //El evento Load del formulario deberá llamar al método Limpiar. 
            this.Load += btnLimpiar_Click;
        }

        public string operador = "";

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
            if (txtNumero2.Visible == false || cmbOperador.Visible == false)
            {
                txtNumero2.Visible = true;
                cmbOperador.Visible = true;
            }



        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
          Numero n1 = new Numero(this.txtNumero1.Text);
          Numero n2 = new Numero(this.txtNumero2.Text);
          string operador = cmbOperador.Text;

          double resultado = 0;

          resultado = Calculadora.Operar(n1, n2, operador);
          this.lblResultado.Text = resultado.ToString();

        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
            operador = cmbOperador.SelectedItem.ToString();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.cmbOperador.Visible = false;
            txtNumero2.Visible = false;

            string numeroStr = "";

            numeroStr = txtNumero1.Text;
            Numero convertir = new Numero(numeroStr);
            lblResultado.Text = convertir.DecimalBinario(numeroStr);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.cmbOperador.Visible = false;
            txtNumero2.Visible = false;

            string numeroStr = "";

            numeroStr = txtNumero1.Text;
            Numero convertir = new Numero(numeroStr);
            lblResultado.Text = convertir.BinarioDecimal(numeroStr);
        }
        /// <summary>
        ///  El evento Closing deberá preguntar al usuario si está seguro 
        ///  (botones SI y NO, con ícono de pregunta). Se deberá actuar en consecuencia a su respuesta. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Seguro que desea salir","Salir",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
            if(resultado== DialogResult.Yes)
            {
                e.Cancel = false;
            }
        }
    }
}
