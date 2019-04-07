using System;

namespace YouLearn.Domain.Arguments.Usuario
{
    public class AdicionarResponse
    {
        public AdicionarResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
