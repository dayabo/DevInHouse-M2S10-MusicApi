

namespace ProjetoMusica.Models
{
    public class PlayList
    {
        public int Id { get; internal set; }

        public string Nome { get; set; }
        public string Genero { get; set; }
        public List<Musica> Musicas { get; set; } = new();


        public PlayList(string nome, string genero)
        {
            Nome = nome;
            Genero = genero;
        }

    }
}
