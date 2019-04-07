using YouLearn.Domain.Entities.Base;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Entities
{
    public class Video : EntityBase
    {
        public Canal Canal { get; set; }
        public PlayList PlayList { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Tags { get; set; }
        public int OrdemPlaylist { get; set; }
        public string IdVideoYoutube { get; set; }
        public Usuario Usuario { get; set; }
        public EnumStatus Status { get; set; }
    }
}
