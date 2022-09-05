﻿using ProjetoMusica.Models;

namespace ProjetoMusica.Repositorios
{
    public class ArtistaRepositorio
    {
        private static int _indiceId = 1;

        private static List<Artista> _artistas = new();

        public Artista Criar(Artista artista)
        {
            artista.Id = _indiceId;
            _indiceId++;

            _artistas.Add(artista);

            return (artista);

        }

        public Artista Atualizar(int id,Artista artista)
        {
            var artistaExistente = _artistas.FirstOrDefault(artistaLista => artistaLista.Id == id);
           
            if (artistaExistente == null) return null;

            artistaExistente.Nome = artista.Nome;
            artistaExistente.NomeArtistico = artista.NomeArtistico;
            artistaExistente.Idade = artista.Idade;
            artistaExistente.PaisOrigem = artista.PaisOrigem;

            return (artista);

        }

        public Artista AtualizarIdade(int idArtista, int idade)
        {
            var artistaExistente = _artistas.FirstOrDefault(artistaLista => artistaLista.Id == idArtista);

            artistaExistente.Idade = idade;

            return artistaExistente;
        }

        public void Deletar(int artistaId)
        {
            var artistaExistente = _artistas.FirstOrDefault(artistaLista => artistaLista.Id == artistaId);


            _artistas.Remove(artistaExistente);

        }

        public List<Artista>TodosArtistas(string filtrarNome)
        {
            if (!string.IsNullOrEmpty(filtrarNome))
            {
                return _artistas.Where(artistaLista => artistaLista.Nome.Contains(filtrarNome) || artistaLista.NomeArtistico.Contains(filtrarNome)).ToList();
            }
            return _artistas;
        }

        public Artista ObterArtistasPorId(int artistaId)
        {
            var retornaArtistaComId = _artistas.FirstOrDefault(artistaLista => artistaLista.Id == artistaId);

            return retornaArtistaComId;
        }
    }
}
