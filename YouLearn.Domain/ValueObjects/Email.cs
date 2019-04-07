using prmToolkit.NotificationPattern;

namespace YouLearn.Domain.ValueObjects
{
    public class Email : ValueObjectBase
    {
        public string Endereco { get; private set; }
        public Email(string endereco)
        {
            Endereco = endereco;
            new AddNotifications<Email>(this)
                .IfNotEmail(x => x.Endereco);

        }
    }
}
