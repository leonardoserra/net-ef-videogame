using net_ef_videogame.Database;
using net_ef_videogame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.StaticClasses
{
    public static class VideogameManager
    {
        public static void PopulateTableVideogame()
        {

            Console.Write("Quante Videogames vuoi creare? ");
            int quantityToCreate = int.Parse(Console.ReadLine());
            using (VideogamesContext db = new VideogamesContext())
            {
                int createdVideogames = 0;
                for (int i = 0; i < quantityToCreate; i++)
                {
                    Console.WriteLine($"Crea Videogame n.{i + 1}");
                    Console.Write("Nome (Obbligatorio): ");
                    string name = Console.ReadLine();
                    Console.Write("Descrizione: ");
                    string overwiev = Console.ReadLine();
                    Console.Write("Descrizione: ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    Console.Write("Country: ");
                    string country = Console.ReadLine();
                    Console.WriteLine("Ecco la lista delle Software Houses nel database: ");
                    Console.WriteLine();
                    PrintVideogameList(db);
                    Console.Write("Software House ID: ");
                    Console.WriteLine();
                    long softwareHouseId = long.Parse(Console.ReadLine());
                    try
                    {
                        Videogame vg = new Videogame() { Name = name, Overview = overwiev, ReleaseDate = date, SoftwareHouseId = softwareHouseId };
                        db.Add(vg);
                        createdVideogames += db.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Problema con l'aggiunta del Videogame");
                        Console.WriteLine(ex.Message);
                        i--;
                    }
                }
                if (createdVideogames > 0)
                    Console.WriteLine($"Completato. + {createdVideogames} Videogames al database!");
                Console.WriteLine();

                Console.WriteLine();


            }
        }
        public static void PrintVideogameList(VideogamesContext db)
        {
            List<SoftwareHouse> softwareHouses = db.SoftwareHouses.OrderBy(sh => sh.SoftwareHouseId).ToList();
            foreach (SoftwareHouse shInDb in softwareHouses)
            {
                Console.WriteLine($"ID: {shInDb.SoftwareHouseId} - Nome: {shInDb.Name}");
            }
        }
    }
}
