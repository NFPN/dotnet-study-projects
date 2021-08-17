namespace UnipForms
{
    public class Conta
    {
        public double Limite { get; set; }
        public string Numero { get; set; }
        public double Saldo { get; set; }

        public double SaldoTotal => Saldo + Limite;

        public Conta() { }

        public Conta(string numero, double saldo)
        {
            Numero = numero;
            Saldo = saldo;
        }

        public Conta(string numer, double saldo, double limite)
        {
            Numero = numer;
            Saldo = saldo;
            Limite = limite;
        }

        public void Depositar(double valor) => Saldo += valor;

        public void Sacar(double valor) => Saldo -= valor;
    }
}
