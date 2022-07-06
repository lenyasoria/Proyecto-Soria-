namespace Calculadora
{
    public enum Operacion
    {
        NoDefinida = 0,
        Suma = 1,
        Resta = 2,
        Division = 3,
        Multiplicacion = 4,
    }

    public partial class Form1 : Form
    {
        double valor1 = 0;
        double valor2 = 0;
        Operacion operado = Operacion.NoDefinida;
        bool unNumeroLeido= false; 
        public Form1()
        {
            InitializeComponent();
        }

        private void LeerNumero (string numero)
        {
            unNumeroLeido = true;
            if (CajaResultado.Text == "0" && CajaResultado.Text != null)
            {
                CajaResultado.Text = numero;
            }
            else
            {
                CajaResultado.Text += numero;
            }
        }

        private double EjecutarOperacion()
        {
            double resultado = 0;
            switch (operado)
            {
                case Operacion.Suma:
                    resultado = valor1 + valor2;
                    break;

                case Operacion.Resta:
                    resultado = valor1 - valor2;
                    break;

                case Operacion.Division:
                    if (valor2 == 0)
                    {
                        Historial.Text = "¡Error! Trata de dividir en un numero distinto a cero.";
                        resultado = 0;
                    }
                    else
                    {
                        resultado = valor1 / valor2;
                    }
                    break;

                case Operacion.Multiplicacion:
                    resultado = valor1 * valor2;
                    break;
            }
            return resultado;
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            unNumeroLeido = true; 
            if (CajaResultado.Text == "0")
            {
                return;
            }
            else
            {
                CajaResultado.Text += "0";
            } 
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            LeerNumero("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            LeerNumero("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            LeerNumero("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            LeerNumero("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            LeerNumero("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            LeerNumero("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            LeerNumero("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            LeerNumero("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            LeerNumero("9");
        }

        private void ObtenerValor (String operado)
        {
            valor1 = Convert.ToDouble(CajaResultado.Text);
            Historial.Text = CajaResultado.Text + operado;
            CajaResultado.Text = "0";
        }
        private void btnSUMA_Click(object sender, EventArgs e)
        {
            operado = Operacion.Suma;
            ObtenerValor("+");
        }

        private void btnIGUAL_Click(object sender, EventArgs e)
        {
            if (valor2 == 0 && unNumeroLeido )
            {
                valor2 = Convert.ToDouble(CajaResultado.Text);
                Historial.Text += valor2 + "=";
                double resultado = EjecutarOperacion();
                valor1 = 0;
                valor2 = 0;
                unNumeroLeido = false;
                CajaResultado.Text = Convert.ToString(resultado);
            } 
        }

        private void btnRESTA_Click(object sender, EventArgs e)
        {
            operado = Operacion.Resta;
            ObtenerValor("-");
        }

        private void btnMULTIPLICACION_Click(object sender, EventArgs e)
        {
            operado = Operacion.Multiplicacion;
            ObtenerValor("x");
        }

        private void btnDIVISION_Click(object sender, EventArgs e)
        {
            operado = Operacion.Division;
            ObtenerValor("÷");
        }

        private void btnBORRARTODO_Click(object sender, EventArgs e)
        {
            CajaResultado.Text = "0";
            Historial.Text = "";
        }

        private void btnBORRAR_Click(object sender, EventArgs e)
        {
            if (CajaResultado.Text.Length > 1)
            {
                string txtResultado = CajaResultado.Text;
                txtResultado = txtResultado.Substring(0, txtResultado.Length - 1);

                if (txtResultado.Length == 1 && txtResultado.Contains("-"))
                {
                    CajaResultado.Text = "0";
                }
                else
                {
                    CajaResultado.Text = txtResultado;
                }
               
            }
            else
            {
                CajaResultado.Text = "0";
            }
        }

        private void btnPUNTO_Click(object sender, EventArgs e)
        {
           if (CajaResultado.Text.Contains('.'))
            {
                return;
            }
            CajaResultado.Text += ".";
        }
    }
}