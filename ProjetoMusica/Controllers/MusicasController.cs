using Microsoft.AspNetCore.Mvc;
using ProjetoMusica.DTOs;
using ProjetoMusica.Models;
using ProjetoMusica.Repositorios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoMusica.Controllers
{
   
    [ApiController]
    [Route("api/musicas")]
    public class MusicasController : ControllerBase
    {

        private readonly MusicaRepositorio _musicaRepositorio;
       
        private readonly AlbumRepositorio _albumRepositorio;

        
        private readonly ArtistaRepositorio _artistaRepositorio;

        public MusicasController(MusicaRepositorio musicaRepositorio, AlbumRepositorio albumRepositorio, ArtistaRepositorio artistaRepositorio)
        {
            _musicaRepositorio = musicaRepositorio;
            _albumRepositorio = albumRepositorio;
            _artistaRepositorio = artistaRepositorio;
        }


        // GET: api/<MusicasController>
        [HttpGet]
        public ActionResult<List<Musica>> Get([FromQuery] string? PorNomeDoAlbum, [FromQuery] string? PorNomeDoArtista, [FromQuery] string? PorNomeDaMusica)
        {
            return Ok(_musicaRepositorio.TodasMusicas(PorNomeDoAlbum, PorNomeDoArtista, PorNomeDaMusica));
        }

        // GET api/<MusicasController>/5
        [HttpGet("{idMusica}")]
        public ActionResult GetById([FromRoute] int idMusica)
        {
            return Ok(_musicaRepositorio.ObterMusicaPorId(idMusica));
        }

        [HttpPost]
        public ActionResult<Musica> Post([FromBody] MusicaDTO criandoMusica)
        {
            var artista = _artistaRepositorio.ObterArtistasPorId(criandoMusica.ArtistaId);

            var album = _albumRepositorio.ObterAlbumPorIdSemArtista(criandoMusica.AlbumId);

            var musica = new Musica(
                criandoMusica.Nome,
                criandoMusica.Duracao,
                album,
                artista
                );

            _musicaRepositorio.Criar(musica);

            return Ok(musica);
        }

        [HttpPut("{idMusica}")]
        public ActionResult<Album> Put([FromBody] MusicaDTO alteracaoDeMusica, [FromRoute] int idMusica)
        {
            var artista = _artistaRepositorio.ObterArtistasPorId(alteracaoDeMusica.ArtistaId);

            var album = _albumRepositorio.ObterAlbumPorIdSemArtista(alteracaoDeMusica.AlbumId);


            var musica = _musicaRepositorio.Atualizar(idMusica, new Musica(
               alteracaoDeMusica.Nome,
               alteracaoDeMusica.Duracao,
                album,
                artista)
                );


            return Ok(musica);
        }


        [HttpDelete("{idMusica}")]
        public ActionResult<Musica> RemoverMusica([FromRoute] int idMusica)
        {
            _musicaRepositorio.Deletar(idMusica);

            return Ok("Musica Removido");

        }
    }
}
