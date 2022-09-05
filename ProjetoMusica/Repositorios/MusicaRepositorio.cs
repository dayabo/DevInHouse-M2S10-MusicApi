using ProjetoMusica.Models;

namespace ProjetoMusica.Repositorios
{
    public class MusicaRepositorio
    {
        private static int _indiceId = 1;

        private static List<Musica> _musicas = new();

        public Musica Criar(Musica musica)
        {
           musica.Id = _indiceId;
            _indiceId++;

            _musicas.Add(musica);

            return (musica);

        }

        public Musica Atualizar(int id, Musica musica)
        {
            var musicaExistente = _musicas.FirstOrDefault(musicaLista => musicaLista.Id == id);

            if (musicaExistente == null) return null;

            musicaExistente.Nome = musica.Nome;
            musicaExistente.Duracao = musica.Duracao;
            musicaExistente.Artista = musica.Artista;
            musicaExistente.Album = musica.Album;

            return (musica);

        }


        public void Deletar(int musicaId)
        {
            var musicaExistente = _musicas.FirstOrDefault(musicaLista => musicaLista.Id == musicaId);


            _musicas.Remove(musicaExistente);

        }

        public List<Musica> TodasMusicas(string PorNomeDoAlbum,  string PorNomeDoArtista, string PorNomeDaMusica)
        {

            if (!string.IsNullOrEmpty(PorNomeDoAlbum))
            {
                return _musicas.Where(musicaLista => musicaLista.Album.Nome.Contains(PorNomeDoAlbum) ).ToList();
            }
            else if (!string.IsNullOrEmpty(PorNomeDoArtista))
            {
                return _musicas.Where(musicaLista => musicaLista.Artista.Nome.Contains(PorNomeDoArtista)).ToList();
            }

                else if (!string.IsNullOrEmpty(PorNomeDaMusica))
                    {

                return _musicas.Where(musicaLista => musicaLista.Nome.Contains(PorNomeDaMusica)).ToList();

                    }
            return _musicas;
        }
        
       

        public List<Musica> TodasMusicasPorAlbum(int idAlbum)
        {
            return _musicas
                .Where(musicaLista => musicaLista.Album != null)
                .Where(musicaLista => musicaLista.Album.Id == idAlbum)
                .ToList();
        }
        public Musica ObterMusicaPorId(int musicaId)
        {
            var retornaMusicaComId = _musicas.FirstOrDefault(musicaLista => musicaLista.Id == musicaId);

            return retornaMusicaComId;
        }
    }
}
