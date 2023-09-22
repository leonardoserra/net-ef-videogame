using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
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

            Console.Write("Quanti Videogames vuoi creare? ");
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
                    Console.Write("Data Rilascio: ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    SoftwareHouseManager.PrintSoftwareHousesList(db);
                    Console.WriteLine();
                    Console.Write("Scegli la Software Houses: ");
                    long softwareHouseId = long.Parse(Console.ReadLine());
                    Console.WriteLine();
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
                Console.WriteLine("Ecco la lista dei videogames presenti nel database: ");
                PrintAndReturnVideogamesList(db);
                Console.WriteLine();


            }
        }
        public static List<Videogame> PrintAndReturnVideogamesList(VideogamesContext db)
        {
            List<Videogame> videogames = db.Videogames.OrderBy(vg => vg.Id).ToList();
            foreach (Videogame vgInDb in videogames)
            {
                Console.WriteLine(vgInDb);
            }
            return videogames;
        }
        public static Videogame SearchAndPrintVideogameByID(long id)
        {
            using (VideogamesContext db = new VideogamesContext())
            {
                Videogame videogameFound = db.Videogames.Where(vg => vg.Id == id).First();
                Console.WriteLine(videogameFound);

                return videogameFound;

            }
        }
        public static List<Videogame> SearchAndPrintVideogamesByName(string name)
        {
            using (VideogamesContext db = new VideogamesContext())
            {
                List<Videogame> videogames = db.Videogames.OrderBy(vg => vg.Id).Where(vg => vg.Name.Contains(name)).ToList();
                foreach(Videogame vg in videogames)
                {
                    Console.WriteLine(vg);
                }
                return videogames;
            }

        }

    }
}
