using prmToolkit.NotificationPattern;
using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Extensions;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }

        public Usuario(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;

            new AddNotifications<Usuario>(this)
                .IfNullOrInvalidLength(x => x.Senha, 3, 10);

            Senha = Senha.ConvertParaMD5();

            AddNotifications(nome, email);
        }

        public Usuario(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            Senha = Senha.ConvertParaMD5();

            AddNotifications(email);
        }
    }
}
