namespace ProjetoMusica.Models
{
    public class Album
    {
        public int Id { get;  internal set; }
        public string Nome { get; set; }
        public int AnoLancamento { get; set; }
        public string CapaUrl { get; set; }
        public Artista Artista { get; set; }

        public Album( string nome, int anoLancamento, string capaUrl, Artista artista)
        {
            Nome = nome;
            AnoLancamento = anoLancamento;
            CapaUrl = capaUrl;
            Artista = artista;
        }
        public Album(int id,string nome, int anoLancamento, string capaUrl)
        {
            Nome = nome;
            AnoLancamento = anoLancamento;
            CapaUrl = capaUrl;
           
        }
    }
}
