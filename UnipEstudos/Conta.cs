namespace UnipStudies
{
    public class Conta
    {
        public string Numero { get; set; }
        public decimal Saldo { get; set; }
        public decimal Limite { get; set; }

        public Conta() { }

        public Conta(string numero, decimal saldo, decimal limite)
        {
            Numero = numero;
            Saldo = saldo;
            Limite = limite;
        }

        public void Sacar(decimal quantia)
        {
            Saldo -= quantia;
        }

        public void Depositar(decimal quantia)
        {
            Saldo += quantia;
        }
    }
}
