using System.ComponentModel.DataAnnotations;

namespace ProjetoMusica.Models
{
    public class Artista
    {
        public int Id { get; internal set; }

        [Required(ErrorMessage = "O nome do artista é Obrigatório")]
        public string Nome { get; set; }
        public string NomeArtistico { get; set; }
        public int Idade { get; set; }
        public string PaisOrigem { get; set; }
    }
}
