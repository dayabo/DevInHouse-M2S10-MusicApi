using ProjetoMusica.DTOs;
using ProjetoMusica.ViewModels;

namespace ProjetoMusica.Models
{
    public class Musica
    {
        public int Id { get; internal set; }
        public string Nome { get; set; }
        public TimeSpan Duracao { get; set; }
        public AlbumSemArtistaViewModel Album { get; set; }
        public Artista Artista { get; set; }

        
        public Musica( string nome, TimeSpan duracao, AlbumSemArtistaViewModel album , Artista artista)
        {
          
            Nome = nome;
            Duracao = duracao;
            Album = album;
            Artista = artista;
        }

    }
}
