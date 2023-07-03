namespace CustomerPanel.Domain.Entity.Validator.ErrorMessage
{
    public static class ClientErrorMessage
    {
        // Fields
        public static string LegalNameMustBeInformed = "O nome completo do cliente deve ser informado.";
        public static string TelephoneMustBeInformed = "O telefone do cliente deve ser informado.";
        public static string MailMustBeInformed = "O email do cliente deve ser informado.";

        // Exceeded characters
        public static string ExceededNumberOfCharacters = "Número de caracteres excedido, máximo suportado {0}.";

        // Field null
        public static string FieldCannotBeNull = "O campo não pode ser nulo.";
    }
}
