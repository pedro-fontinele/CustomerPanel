namespace CustomerPanel.Domain.Entity.Validator.ErrorMessage
{
    public static class TelephoneErrorMessage
    {
        // Fields
        public static string DDDMustBeInformed = "O DDD do cliente deve ser informado.";
        public static string NumberMustBeInformed = "O numero do telefone do cliente deve ser informado.";
        public static string TypeNumberMustBeInformed = "O tipo de telefone do cliente deve ser informado.";

        // Exceeded characters
        public static string ExceededNumberOfCharacters = "Número de caracteres excedido, máximo suportado {0}.";

        // Field null
        public static string FieldCannotBeNull = "O campo não pode ser nulo.";
    }
}