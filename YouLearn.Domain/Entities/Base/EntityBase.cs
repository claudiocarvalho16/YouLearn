using prmToolkit.NotificationPattern;
using System;

namespace YouLearn.Domain.Entities.Base
{
    public abstract class EntityBase : Notifiable
    {
        public virtual Guid Id { get; set; }
        public EntityBase() => Id = Guid.NewGuid();
    }
}
