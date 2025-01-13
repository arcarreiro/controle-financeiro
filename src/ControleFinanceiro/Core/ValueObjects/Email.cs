namespace ControleFinanceiro.Core.ValueObjects
{
    public partial class Email
    {
        public string Endereco { get; }

        public Email(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("O e-mail não pode ser vazio.");

            if (!ValidarEmail(endereco))
                throw new ArgumentException("Formato de e-mail inválido.");

            Endereco = endereco;
        }

        private static bool ValidarEmail(string email)
        {
            return MyRegex().IsMatch(email);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Email other)
                return Endereco == other.Endereco;

            return false;
        }

        public override int GetHashCode()
        {
            return Endereco.GetHashCode();
        }

        public override string ToString()
        {
            return Endereco;
        }

        [System.Text.RegularExpressions.GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        private static partial System.Text.RegularExpressions.Regex MyRegex();
    }
}
