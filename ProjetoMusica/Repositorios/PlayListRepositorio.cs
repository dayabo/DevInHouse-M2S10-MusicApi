using ProjetoMusica.Models;
using ProjetoMusica.ViewModels;

namespace ProjetoMusica.Repositorios
{
    public class PlayListRepositorio
    {
        private static int _indiceId = 1;

        private static List<PlayList> _playList = new();

        public PlayList Criar(PlayList playList)
        {
           playList.Id = _indiceId;
            _indiceId++;

            _playList.Add(playList);

            return (playList);

        }

        public PlayList Atualizar(int id, PlayList playList)
        {
            var playListExistente = _playList.FirstOrDefault(playListLista => playListLista.Id == id);

            if (playListExistente == null) return null;

            playListExistente.Nome = playList.Nome;
            playListExistente.Genero = playList.Genero;
            

            return (playList);

        }


        public void Deletar(int playListId)
        {
            var playListExistente = _playList.FirstOrDefault(playListLista => playListLista.Id == playListId);


            _playList.Remove(playListExistente);

        }

        public PlayList RemoverMusicaDaPlaylist(PlayList playList, int idMusica)
        {
            var playListAtual = ObterPlayListPorId(playList.Id);

            var musicaAtual = playListAtual.Musicas.FirstOrDefault(m => m.Id == idMusica);

            playListAtual.Musicas.Remove(musicaAtual);

            return playListAtual;
        }

        public List<PlayList> TodasPlayList()
        {

            return _playList;
        }

        public PlayList ObterPlayListPorId(int playListId)
        {
            var retornaPlayListComId = _playList.FirstOrDefault(playListLista => playListLista.Id == playListId);

            return retornaPlayListComId;
        }

        public PlayList AdicionarMusica(PlayList playList , Musica musica)
        {
            var playListAtual = ObterPlayListPorId(playList.Id);
            playListAtual.Musicas ??= new List<Musica>();
            playListAtual.Musicas.Add(musica);   

            

            return playListAtual;
        }

      
    }
}
