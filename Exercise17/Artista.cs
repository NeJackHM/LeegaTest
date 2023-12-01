using Example17.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Example17
{
    public class Artista : IArtista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string QuantidadeDeIntegrantes { get; set; }
        public string Ritmo { get; set; }

        public void PrincipalMenuArtista(List<Artista> artistas, List<Albun> albuns = null)
        {
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------:");
            Console.WriteLine("ARTIST MENU:");
            Console.WriteLine("Write action:");
            Console.WriteLine("1 for Show Artists:");
            Console.WriteLine("2 for Insert Artist:");
            Console.WriteLine("3 for Update Artist:");
            Console.WriteLine("4 for Delete Artist:");
            Console.WriteLine("5 for Back to the principal menu:");
            Console.WriteLine("------------------------------------------------------------:");
            Console.WriteLine("");
            string str = Console.ReadLine();

            switch (str)
            {
                case "1":
                    Console.WriteLine("");
                    GetArtists(artistas, albuns);
                    break;

                case "2":
                    Console.WriteLine("");
                    InsertArtist(artistas, albuns);
                    break;

                case "3":
                    Console.WriteLine("");
                    UpdateArtist(artistas, albuns);
                    break;

                case "4":
                    Console.WriteLine("");
                    DeleteArtista(artistas, albuns);
                    break;

                case "5":
                    Console.WriteLine("");
                    IArtista _artista = new Artista();
                    IAlbun _albun = new Albun();
                    BaseClass baseClass = new BaseClass(_albun, _artista);
                    baseClass.PrincipalMenuAlbun(albuns, artistas);
                    break;
            }
        }

        public bool IsNumber(string input)
        {
            try
            {
                int.Parse(input);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public void InsertArtist(List<Artista> artistas, List<Albun> albuns)
        {
            Console.WriteLine("Nome do artista:");
            string nome = Console.ReadLine();

            var getArtista = artistas.Where(a => a.Nome.ToLower().Trim() == nome.ToLower().Trim()).FirstOrDefault();
            if (getArtista != null)
            {
                Console.WriteLine("O nome do artista ingressado já existe.");
                PrincipalMenuArtista(artistas, albuns);
            }

            Console.WriteLine("Quantidade de integrantes: ");

            string quantidadeDeIntegrantes = Console.ReadLine();

            if (!IsNumber(quantidadeDeIntegrantes))
            {
                Console.WriteLine("Por favor ingresse um numero.");
                PrincipalMenuArtista(artistas, albuns);
            }

            Console.WriteLine("Ritmo: ");
            string ritmo = Console.ReadLine();

            Artista artista = new Artista()
            {
                Id = artistas.Last().Id + 1,
                Nome = nome,
                QuantidadeDeIntegrantes = quantidadeDeIntegrantes,
                Ritmo = ritmo
            };

            artistas.Add(artista);

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Artista cadastrado com sucesso.");
            Console.WriteLine("-------------------------------------------------");

            foreach (var item in artistas)
            {
                Console.WriteLine($"Id: {item.Id} , Nome: {item.Nome}, Quantidade de integrantes: {item.QuantidadeDeIntegrantes}, Ritmo: {item.Ritmo}");
            }

            PrincipalMenuArtista(artistas, albuns);
        }

        public void GetArtists(List<Artista> artistas, List<Albun> albuns)
        {
            foreach (var item in artistas)
            {
                Console.WriteLine($"Id: {item.Id} ,Nome: {item.Nome}, Quantidade de integrantes: {item.QuantidadeDeIntegrantes}, Ritmo: {item.Ritmo}");
            }

            PrincipalMenuArtista(artistas, albuns);
        }

        public void UpdateArtist(List<Artista> artistas, List<Albun> albuns)
        {
            Console.WriteLine("Id do artista:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome do artista:");
            string nome = Console.ReadLine();

            Console.WriteLine("Quantidade de integrantes: ");

            string quantidadeDeIntegrantes = Console.ReadLine();

            if (!IsNumber(quantidadeDeIntegrantes))
            {
                Console.WriteLine("Por favor ingresse um numero.");
                PrincipalMenuArtista(artistas, albuns);
            }

            Console.WriteLine("Ritmo: ");
            string ritmo = Console.ReadLine();

            Artista updateArtista = new Artista();
            updateArtista.Id = id;
            updateArtista.Nome = nome;
            updateArtista.QuantidadeDeIntegrantes = quantidadeDeIntegrantes;
            updateArtista.Ritmo = ritmo;

            var newList = UpdateObjectElementById(artistas, id, updateArtista);

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Artista atualizado com sucesso.");
            Console.WriteLine("-------------------------------------------------");

            foreach (var item in newList)
            {
                Console.WriteLine($"Id: {item.Id} , Nome: {item.Nome}, Quantidade de integrantes: {item.QuantidadeDeIntegrantes}, Ritmo: {item.Ritmo}");
            }

            PrincipalMenuArtista(newList, albuns);
        }


        public void DeleteArtista(List<Artista> artistas, List<Albun> albuns)
        {
            Console.WriteLine("Id do artista:");
            int id = int.Parse(Console.ReadLine());

            var newList = RemoveElementById(artistas, id);

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Artista removido com sucesso.");
            Console.WriteLine("-------------------------------------------------");

            foreach (var item in newList)
            {
                Console.WriteLine($"Id: {item.Id} , Nome: {item.Nome}, Quantidade de integrantes: {item.QuantidadeDeIntegrantes}, Ritmo: {item.Ritmo}");
            }

            PrincipalMenuArtista(newList, albuns);
        }

        public List<Artista> UpdateObjectElementById(List<Artista> list, int id, Artista newElement)
        {
            Artista oldElement = list.Find(x => x.Id == id);

            foreach (PropertyInfo property in typeof(Artista).GetProperties())
            {
                property.SetValue(oldElement, property.GetValue(newElement));
            }
            list[list.IndexOf(oldElement)] = oldElement;
            return list;
        }

        public List<Artista> RemoveElementById(List<Artista> list, int id)
        {
            Artista element = list.Find(x => x.Id == id);

            list.Remove(element);

            return list;
        }
    }
}
