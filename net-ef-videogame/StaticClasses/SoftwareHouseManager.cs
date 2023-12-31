﻿using net_ef_videogame.Database;
using net_ef_videogame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.StaticClasses
{
    public static class SoftwareHouseManager
    {
        public static void PopulateTableSoftwareHouse()
        {

            Console.Write("Quante Software Houses vuoi creare? ");
            int quantityToCreate = int.Parse(Console.ReadLine());
            using (VideogamesContext db = new VideogamesContext())
            {
                int createdSoftwareHouses = 0;
                for (int i = 0; i < quantityToCreate; i++)
                {
                    Console.WriteLine($"Crea Software House n.{i + 1}");
                    Console.Write("Nome (Obbligatorio): ");
                    string name = Console.ReadLine();
                    Console.Write("P.Iva (11 caratteri): ");
                    string taxId = Console.ReadLine();
                    if (taxId == null || taxId.Length != 11)
                    {
                        Console.WriteLine("Inserire esattamente 11 caratteri");
                        i--;
                        continue;
                    }
                    Console.Write("City: ");
                    string city = Console.ReadLine();
                    Console.Write("Country: ");
                    string country = Console.ReadLine();
                    try
                    {
                        SoftwareHouse sh = new SoftwareHouse() { Name = name, TaxId = taxId, City = city, Country = country };
                        db.Add(sh);
                        createdSoftwareHouses += db.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Problema con la creazione della Software House");
                        Console.WriteLine(ex.Message);
                        i--;
                    }
                }
                if (createdSoftwareHouses > 0)
                    Console.WriteLine($"Completato. + {createdSoftwareHouses} Software Houses al database!");
                Console.WriteLine();
                Console.WriteLine("Ecco la lista delle Software Houses nel database: ");
                Console.WriteLine();
                PrintSoftwareHousesList(db);
                Console.WriteLine();


            }
        }
        public static void PrintSoftwareHousesList(VideogamesContext db)
        {
            List<SoftwareHouse> softwareHouses = db.SoftwareHouses.OrderBy(sh => sh.SoftwareHouseId).ToList();
            foreach (SoftwareHouse shInDb in softwareHouses)
            {
                Console.WriteLine(shInDb);
            }
        }
    }
}
