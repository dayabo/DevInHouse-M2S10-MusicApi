using ProjetoMusica.Models;
using ProjetoMusica.ViewModels;

namespace ProjetoMusica.Repositorios
{
    public class AlbumRepositorio
    {
        private static int _indiceId = 1;

        private static List<Album> _album = new();
      

        public Album Criar(Album album)
        {
            album.Id = _indiceId;
            _indiceId++;

            _album.Add(album);

            return (album);

        }

        public Album Atualizar(int id, Album album)
        {
            var albumExistente = _album.FirstOrDefault(albumLista => albumLista.Id == id);

            if (albumExistente == null) return null;

            albumExistente.Nome = album.Nome;
            albumExistente.Artista = album.Artista;
            albumExistente.AnoLancamento = album.AnoLancamento;
            albumExistente.CapaUrl = album.CapaUrl;

            return (albumExistente);



        }

      
        public void Deletar(int albumId)
        {
            var artistaExistente = _album.FirstOrDefault(albumLista => albumLista.Id == albumId);


            _album.Remove(artistaExistente);

        }

        public List<Album> TodosAlbum()
        {
            return _album;
        }

        public Album ObterAlbumPorId(int albumId)
        {
            var retornaAlbumComId = _album.FirstOrDefault(albumLista => albumLista.Id == albumId);

            return retornaAlbumComId;
        }

        public AlbumSemArtistaViewModel ObterAlbumPorIdSemArtista(int albumId)
        {
            var TransformaAlbumEmAlbumSemArtistaViewModel = _album.Select(album => new AlbumSemArtistaViewModel()
            {
                Id = album.Id,
                Nome = album.Nome,
                AnoLancamento = album.AnoLancamento,
                CapaUrl = album.CapaUrl

            }).ToList();

            var retornaAlbumComId = TransformaAlbumEmAlbumSemArtistaViewModel.FirstOrDefault(albumLista => albumLista.Id == albumId);

            return retornaAlbumComId;
        }
    }
}
