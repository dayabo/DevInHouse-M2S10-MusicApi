using Microsoft.AspNetCore.Mvc;
using ProjetoMusica.DTOs;
using ProjetoMusica.Models;
using ProjetoMusica.Repositorios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoMusica.Controllers
{
    
    [ApiController]
    [Route("api/playList")]
    public class PlayListController : ControllerBase
    {
        private readonly PlayListRepositorio _playListRepositorio;

        private readonly MusicaRepositorio _musicaRepositorio;

        private readonly AlbumRepositorio _albumRepositorio;

        private readonly ArtistaRepositorio _artistaRepositorio;

        public PlayListController(PlayListRepositorio playListRepositorio, MusicaRepositorio musicaRepositorio, AlbumRepositorio albumRepositorio, ArtistaRepositorio artistaRepositorio)
        {
            _playListRepositorio=  playListRepositorio;
            _musicaRepositorio = musicaRepositorio;
            _albumRepositorio = albumRepositorio;
            _artistaRepositorio = artistaRepositorio;
        }
     


        [HttpGet]
        public ActionResult<List<PlayList>> Get()
        {
            return Ok(_playListRepositorio.TodasPlayList());
        }

       
        [HttpGet("{idPlayList}")]
        public ActionResult<PlayList> GetById([FromRoute] int idPlayList)
        {
            return Ok(_playListRepositorio.ObterPlayListPorId(idPlayList));
        }

       
        [HttpPost]
        public ActionResult<PlayList> Post([FromBody] PlayListDTO criandoPlayList)
        {


            var playList = new PlayList(
                criandoPlayList.Nome,
                criandoPlayList.Genero
                ); 
            
            _playListRepositorio.Criar(playList);

            return Ok(playList);
            
        }


        [HttpPost("{idPlayList}/musica")]
        public ActionResult<PlayList> PostMusica([FromRoute] int idPlayList, [FromBody] PlayListMusicaDTO music)
        {

            var playList = _playListRepositorio.ObterPlayListPorId(idPlayList);

            var musica = _musicaRepositorio.ObterMusicaPorId(music.MusicaId);


            _playListRepositorio.AdicionarMusica(playList,musica);

            return Ok(playList);

        }

        
        [HttpPut("{idPlayList}")]
        public ActionResult<PlayList> Put([FromRoute] int idPlayList, [FromBody] PlayListDTO alteraPlayList)  
        
        {
            var playList = _playListRepositorio.ObterPlayListPorId(idPlayList);
            playList.Nome = alteraPlayList.Nome;
            playList.Genero = alteraPlayList.Genero;
         

            _playListRepositorio.Atualizar(idPlayList, playList);

            return Ok(playList);
        }

       
        [HttpDelete("{idPlayList}")]
        public ActionResult<PlayList> RemoverPlayList([FromRoute] int idPlayList)
        {
            _playListRepositorio.Deletar(idPlayList);

            return Ok("Play List Removida");

        }


        [HttpDelete("{idPlayList}/musica/{idMusica}")]
        public ActionResult<PlayList> RemoverMusicaDaPlayList( [FromRoute] int idPlayList, [FromRoute] int idMusica)
        {
            var playList = _playListRepositorio.ObterPlayListPorId(idPlayList);

            _playListRepositorio.RemoverMusicaDaPlaylist(playList, idMusica);

            return Ok("Musica Removida  da Play List");
        }
    }
}
