using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;
using Exercise17.Interfaces;

namespace Exercise17
{
    public class Albun : IAlbun
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Artista { get; set; }
        public string Ritmo { get; set; }

        public void PrincipalMenuAlbun(List<Albun> albuns, List<Artista> artistas = null)
        {
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------:");
            Console.WriteLine("ALBUN MENU:");
            Console.WriteLine("Write action:");
            Console.WriteLine("1 for Show Albuns:");
            Console.WriteLine("2 for Insert Albun:");
            Console.WriteLine("3 for Update Albun:");
            Console.WriteLine("4 for Delete Albun:");
            Console.WriteLine("5 for Show Artists:");
            Console.WriteLine("6 for Back to the principal menu:");
            Console.WriteLine("------------------------------------------------------------:");
            Console.WriteLine("");
            string str = Console.ReadLine();

            switch (str)
            {
                case "1":
                    Console.WriteLine("");
                    getAlbuns(albuns, artistas);
                    break;

                case "2":
                    Console.WriteLine("");
                    cadastrarAlbun(albuns, artistas);
                    break;

                case "3":
                    Console.WriteLine("");
                    updateAlbun(albuns, artistas);
                    break;

                case "4":
                    Console.WriteLine("");
                    DeleteAlbun(albuns, artistas);
                    break;

                case "5":
                    Console.WriteLine("");
                    ShowArtists(albuns, artistas);
                    break;

                case "6":
                    Console.WriteLine("");
                    IArtista _artista = new Artista();
                    IAlbun _albun = new Albun();
                    BaseClass baseClass = new BaseClass(_albun, _artista);
                    baseClass.PrincipalMenuAlbun(albuns, artistas);
                    break;
            }
        }

        public void ShowArtists(List<Albun> albuns, List<Artista> artistas)
        {
            Console.WriteLine("Artists :");
            foreach (var item in artistas)
            {
                Console.WriteLine($"Id: {item.Id} ,Nome: {item.Nome}, Quantidade de integrantes: {item.QuantidadeDeIntegrantes}, Ritmo: {item.Ritmo}");
            }

            PrincipalMenuAlbun(albuns, artistas);
        }

        public void cadastrarAlbun(List<Albun> albuns, List<Artista> artistas)
        {
            Console.WriteLine("Nome do albun:");
            string nome = Console.ReadLine();

            Console.WriteLine("Nome do Artista:");

            string artista = Console.ReadLine();

            var getArtista = artistas.Where(a => a.Nome.ToLower().Trim() == artista.ToLower().Trim()).FirstOrDefault();
            if (getArtista == null)
            {
                Console.WriteLine("Por favor ingresse um nome de Artista existente.");
                PrincipalMenuAlbun(albuns, artistas);
            }

            Console.WriteLine("Ritmo: ");
            string ritmo = Console.ReadLine();

            Albun albun = new Albun()
            {
                Id = albuns.Last().Id + 1,
                Nome = nome,
                Artista = artista,
                Ritmo = ritmo
            };

            albuns.Add(albun);

            Console.WriteLine("");
            Console.WriteLine("Album cadastrado com sucesso ");
            Console.WriteLine("");

            foreach (var item in albuns)
            {
                Console.WriteLine($"Id: {item.Id} , Nome: {item.Nome}, Nome do Artista: {item.Artista}, Ritmo: {item.Ritmo}");
            }

            PrincipalMenuAlbun(albuns, artistas);
        }

        public void getAlbuns(List<Albun> albuns, List<Artista> artistas)
        {
            foreach (var item in albuns)
            {
                Console.WriteLine($"Id: {item.Id} ,Nome: {item.Nome}, Nome do Artista: {item.Artista}, Ritmo: {item.Ritmo}");
            }

            PrincipalMenuAlbun(albuns, artistas);
        }

        public void updateAlbun(List<Albun> albuns, List<Artista> artistas)
        {
            Console.WriteLine("Id do albun:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome do albun:");
            string nome = Console.ReadLine();

            Console.WriteLine("Nome do Artista: ");

            string artista = Console.ReadLine();

            var getArtista = artistas.Where(a => a.Nome.ToLower().Trim() == artista.ToLower().Trim()).FirstOrDefault();
            if (getArtista == null)
            {
                Console.WriteLine("Por favor ingresse um nome de Artista existente.");
                PrincipalMenuAlbun(albuns, artistas);
            }

            Console.WriteLine("Ritmo: ");
            string ritmo = Console.ReadLine();

            Albun updateAlbun = new Albun();
            updateAlbun.Id = id;
            updateAlbun.Nome = nome;
            updateAlbun.Artista = artista;
            updateAlbun.Ritmo = ritmo;

            var newList = UpdateObjectElementById(albuns, id, updateAlbun);

            Console.WriteLine("");
            Console.WriteLine("Album atualizado com sucesso ");
            Console.WriteLine("");

            foreach (var item in newList)
            {
                Console.WriteLine($"Id: {item.Id} ,Nome: {item.Nome}, Nome do Artista: {item.Artista}, Ritmo: {item.Ritmo}");
            }

            PrincipalMenuAlbun(albuns, artistas);
        }

        public void DeleteAlbun(List<Albun> albuns, List<Artista> artistas)
        {
            Console.WriteLine("Id do albun:");
            int id = int.Parse(Console.ReadLine());

            var newList = RemoveElementById(albuns, id);

            Console.WriteLine("");
            Console.WriteLine("Album deletado com sucesso ");
            Console.WriteLine("");

            foreach (var item in newList)
            {
                Console.WriteLine($"Id: {item.Id} ,Nome: {item.Nome}, Nome do Artista: {item.Artista}, Ritmo: {item.Ritmo}");
            }

            PrincipalMenuAlbun(albuns, artistas);
        }

        public List<Albun> UpdateObjectElementById(List<Albun> list, int id, Albun newElement)
        {
            Albun oldElement = list.Find(x => x.Id == id);

            foreach (PropertyInfo property in typeof(Albun).GetProperties())
            {
                property.SetValue(oldElement, property.GetValue(newElement));
            }
            list[list.IndexOf(oldElement)] = oldElement;
            return list;
        }

        public List<Albun> RemoveElementById(List<Albun> list, int id)
        {
            Albun element = list.Find(x => x.Id == id);

            list.Remove(element);

            return list;
        }
    }
}
