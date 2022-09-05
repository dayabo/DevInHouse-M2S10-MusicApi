using Microsoft.AspNetCore.Mvc;
using ProjetoMusica.DTOs;
using ProjetoMusica.Models;
using ProjetoMusica.Repositorios;

namespace ProjetoMusica.Controllers
{
    [ApiController]
    [Route("api/artistas")]
    public class ArtistasController : ControllerBase
    {
        private readonly ArtistaRepositorio _artistaRepositorio;
        public ArtistasController(ArtistaRepositorio artistaRepositorio)
        {
            _artistaRepositorio = artistaRepositorio;
        }

        [HttpGet]
        public List<Artista> Get([FromQuery] string? nomeFiltro)
        {
            return _artistaRepositorio.TodosArtistas(nomeFiltro);
        }



        [HttpPost]
        public ActionResult<Artista> CriarArtista([FromBody] Artista novoArtista)
        {
            var artista = _artistaRepositorio.Criar(novoArtista);

            return Created("api/artistas", artista);
        }
        
        [HttpPut("{idArtista}")]
        public ActionResult<Artista> AtualizarArtista([FromBody] Artista artista, [FromRoute] int idArtista)
        {
            var artistaAlterado = _artistaRepositorio.Atualizar(idArtista, artista);

            return Ok(artistaAlterado);
        }

        [HttpPatch("{idArtista}/idade")]
        public ActionResult AtualizarIdade([FromBody] ArtistaIdadeDTO artistaIdade, [FromRoute] int idArtista)
        {
            var artista = _artistaRepositorio.AtualizarIdade(idArtista, artistaIdade.Idade);

            return Ok(artista);
        }

        [HttpDelete("{idArtista}")]
        public ActionResult<Artista> RemoverArtista([FromRoute] int idArtista)
        {
          _artistaRepositorio.Deletar(idArtista);

            return Ok("Artista Removido");
        }
    }
}