using Example17.Interfaces;
using System.Collections.Generic;

namespace Example17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IArtista _artista = new Artista();
            IAlbun _albun = new Albun();
            BaseClass baseClass = new BaseClass(_albun, _artista);
            baseClass.PrincipalMenuAlbun(ListaAlbuns(), ListaArtistas());
        }

        static List<Artista> ListaArtistas()
        {
            List<Artista> artistas = new List<Artista>()
            {
                new Artista() { Id = 1, Nome = "Legião Urbana", QuantidadeDeIntegrantes = "4", Ritmo = "Rock" },
                new Artista() { Id = 2, Nome = "Caetano Veloso", QuantidadeDeIntegrantes = "1", Ritmo = "MPB" },
                new Artista() { Id = 3, Nome = "Chico Buarque", QuantidadeDeIntegrantes = "1", Ritmo = "MPB" },
                new Artista() { Id = 4, Nome = "Marilia Mendonca", QuantidadeDeIntegrantes = "1", Ritmo = "Sertanejo" },
                new Artista() { Id = 5, Nome = "Gustavo Lima", QuantidadeDeIntegrantes = "1", Ritmo = "Sertanejo" }
            };

            return artistas;
        }

        static List<Albun> ListaAlbuns()
        {
            List<Albun> albuns = new List<Albun>()
            {
                new Albun() { Id = 1, Nome = "Legião Noite", Artista = "Legião Urbana", Ritmo = "Rock" },
            };

            return albuns;
        }
    }
}
