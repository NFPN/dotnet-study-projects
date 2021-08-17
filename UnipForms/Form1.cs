using System;
using System.Windows.Forms;

namespace UnipForms
{
    public partial class Form1 : Form
    {
        private Conta ContaPrincipal { get; set; }

        public Form1()
        {
            InitializeComponent();

            textBoxNumero.Text = "1213456";
            textBoxSaldo.Text = "500";
            textBoxLimite.Text = "5000";
        }

        private void MostraSaida(string mensagem)
        {
            textBoxOutput.Text = mensagem;
        }

        private void BtnSalvar_Click(object sender, System.EventArgs e)
        {
            try
            {
                var numero = textBoxNumero.Text;
                var saldo = Convert.ToDouble(textBoxSaldo.Text);
                var limite = Convert.ToDouble(textBoxLimite.Text);
                ContaPrincipal = new Conta(numero, saldo, limite);
                MostraSaida($"Conta salva com sucesso!");
            }
            catch (Exception)
            {
                MostraSaida("Erro - um ou mais valores estão incorretos");
            }
        }

        private void BtnDepositar_Click(object sender, System.EventArgs e)
        {
            try
            {
                ContaPrincipal.Depositar(Convert.ToDouble(textBoxValor.Text));
                MostraSaida($"Seu saldo principal é: {ContaPrincipal.Saldo}\t\t\t" +
                            $"Saldo total: {ContaPrincipal.SaldoTotal}");
            }
            catch (Exception)
            {
                MostraSaida($"Erro - o valor '{textBoxValor.Text}' está incorreto");
            }
        }

        private void BtnSacar_Click(object sender, System.EventArgs e)
        {
            try
            {
                ContaPrincipal.Sacar(Convert.ToDouble(textBoxValor.Text));
                MostraSaida($"Seu saldo principal é: {ContaPrincipal.Saldo}\t\t\t" +
                            $"Saldo total: {ContaPrincipal.SaldoTotal}");
            }
            catch (Exception)
            {
                MostraSaida($"Erro - o valor '{textBoxValor.Text}' está incorreto");
            }
        }
    }
}
