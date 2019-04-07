﻿using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities
{
    public class Canal : EntityBase
    {
        public string Nome { get; set; }
        public string urlLogo { get; set; }
        public Usuario Usuario { get; set; }
    }
}
