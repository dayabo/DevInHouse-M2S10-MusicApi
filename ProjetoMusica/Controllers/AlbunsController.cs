using Microsoft.AspNetCore.Mvc;
using ProjetoMusica.DTOs;
using ProjetoMusica.Models;
using ProjetoMusica.Repositorios;

namespace ProjetoMusica.Controllers
{

    [ApiController]
    [Route("api/albuns")]
    public class AlbunsController : ControllerBase
    {
        //injetando o reposito album
        private readonly AlbumRepositorio _albumRepositorio;

        //injetando o reposito artista que completara a classe album
        private readonly ArtistaRepositorio _artistaRepositorio;

        //injetando o reposito musica para utilizar no get musica id album
        private readonly MusicaRepositorio _musicaRepositorio;

        public AlbunsController(AlbumRepositorio albumRepositorio, ArtistaRepositorio artistaRepositorio, MusicaRepositorio musicaRepositorio)
        {
            _albumRepositorio = albumRepositorio;
            _artistaRepositorio = artistaRepositorio;
            _musicaRepositorio = musicaRepositorio;
        }

        [HttpGet]
        public ActionResult<Album>Get()
        {
            return Ok(_albumRepositorio.TodosAlbum());
        }

        [HttpGet("{idAlbum}/musicas")]
        public ActionResult<Musica> GetMusicaPorAlbum([FromRoute] int idAlbum)
        {
            return Ok(_musicaRepositorio.TodasMusicasPorAlbum(idAlbum));
        }


        [HttpPost]
        public ActionResult<Album> Post([FromBody] AlbumDTO criacaoDeAlbum)
        {
            var artista = _artistaRepositorio.ObterArtistasPorId(criacaoDeAlbum.ArtistaId);

            var album = new Album(
                criacaoDeAlbum.Nome,
                criacaoDeAlbum.AnoLancamento,
                criacaoDeAlbum.CapaUrl,
                artista
                );


            _albumRepositorio.Criar(album);

            return Ok(album);
        }

        [HttpPut("{idAlbum}")]
        public ActionResult<Album> Put([FromBody] AlbumDTO alteracaoDeAlbum, [FromRoute] int idAlbum)
        {
            var artista = _artistaRepositorio.ObterArtistasPorId(alteracaoDeAlbum.ArtistaId);

             var album = _albumRepositorio.Atualizar(idAlbum, new Album(
                alteracaoDeAlbum.Nome,
                alteracaoDeAlbum.AnoLancamento,
                alteracaoDeAlbum.CapaUrl,
                artista)
                );


            return Ok(album);
        }

        [HttpDelete("{idAlbum}")]
        public ActionResult<Artista> RemoverArtista([FromRoute] int idAlbum)
        {
            _albumRepositorio.Deletar(idAlbum);

            return NoContent();
        }
    }
}
