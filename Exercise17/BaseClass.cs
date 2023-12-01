using Example17.Interfaces;
using System;
using System.Collections.Generic;

namespace Example17
{
    public class BaseClass 
    {
        private readonly IAlbun _albun;
        private readonly IArtista _artista;

        public BaseClass(IAlbun albun, IArtista artista)
        {
            _albun = albun;
            _artista = artista;
        }

        public void PrincipalMenuAlbun(List<Albun> albuns, List<Artista> artistas)
        {
            Console.WriteLine("------------------------------------------------------------:");
            Console.WriteLine("WELCOME TO THE PRINCIPAL MENU:");
            Console.WriteLine("");
            Console.WriteLine("Write 1 to Show Artist options:");
            Console.WriteLine("Write 2 to Show Albun options:");
            Console.WriteLine("------------------------------------------------------------:");

            string option = Console.ReadLine();

            if (option == "1")
            {
                _artista.PrincipalMenuArtista(artistas, albuns);
            }
            else if (option == "2")
            {
                _albun.PrincipalMenuAlbun(albuns, artistas);
            }

            Console.WriteLine("Please select one of the options");
            Console.WriteLine("");
            PrincipalMenuAlbun(albuns, artistas);
        }
    }
}
