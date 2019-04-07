using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Entities;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Services
{
    public class ServiceUsuario : Notifiable, IServiceUsuario
    {
        // Dependencias
        private readonly IRepositoryUsuario _repositoryUsuario;
                
        public ServiceUsuario(IRepositoryUsuario repositoryUsuario)
        {
            this._repositoryUsuario = repositoryUsuario;
        }

        public AdicionarResponse Adicionar(AdicionarRequest request)
        {
            if (request == null)
            {
                AddNotification("AdicionarResponse", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarRequest"));
                return null;
            }

            // Cria Objetos de valor
            Nome nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            Email email = new Email(request.Email);

            // Cria Entidade
            Usuario usuario = new Usuario(nome, email, request.Senha);

            // Insere Notificações dos Objetos de valor e Entidade
            AddNotifications(usuario);

            if (this.IsInvalid()) return null;

            _repositoryUsuario.Salvar(usuario);

            return new AdicionarResponse(usuario.Id);
        }

        public AutenticarResponse Autenticar(AutenticarRequest request)
        {
            if (request == null)
            {
                AddNotification("AutenticarResponse", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AutenticarRequest"));
                return null;
            }
            var email = new Email(request.Email);
            var usuario = new Usuario(email, request.Senha);

            AddNotifications(usuario);

            if (this.IsInvalid()) return null;
            
            usuario = _repositoryUsuario.Buscar(usuario.Email.Endereco, usuario.Senha);

            if (usuario.Id == null)
            {
                AddNotification("AutenticarResponse", MSG.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            return new AutenticarResponse()
            {
                Id = usuario.Id,
                PrimeiroNome = usuario.Nome.PrimeiroNome
            };
        }
    }
}
