using System.ComponentModel.DataAnnotations;

namespace ProjetoMusica.DTOs
{
    public class MusicaDTO
    {
        public int Id { get; internal set; }

        [Required(ErrorMessage = " O nome da musica é obrigatório !")]
        public string Nome { get; set; }

        public TimeSpan Duracao { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = " O id do album precisa ser válido !")]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = " O artista é obrigatório !")]
        [Range(1, int.MaxValue, ErrorMessage = " O id do artista precisa ser válido !")]
        public int ArtistaId { get; set; }
    }
}
