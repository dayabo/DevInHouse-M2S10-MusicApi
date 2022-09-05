using System.ComponentModel.DataAnnotations;
namespace ProjetoMusica.DTOs
{
    public class PlayListDTO
    {
        public int Id { get; internal set; }

        [Required(ErrorMessage = "Nome da Playlist obrigatório.")]
        public string Nome { get; set; }
        public string Genero { get; set; }
      
    }
}
