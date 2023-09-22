using net_ef_videogame.Database;
using net_ef_videogame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Seeders
{
    public static class SoftwareHouseSeeder
    {
        public static void PopulateTableSoftwareHouse() {

            Console.Write("Quante Software Houses vuoi creare? ");
            int quantityToCreate = int.Parse(Console.ReadLine()); 
            using (VideogamesContext db = new VideogamesContext())
            {
                for (int i = 0; i < quantityToCreate; i++)
                {
                    Console.WriteLine($"Crea Software House n.{i + 1}");
                    Console.Write("Nome (Obbligatorio): ");
                    string name = Console.ReadLine();
                    Console.Write("P.Iva (11 caratteri): ");
                    string taxId = Console.ReadLine();
                    Console.Write("City: ");
                    string city = Console.ReadLine();
                    Console.Write("Country: ");
                    string country = Console.ReadLine();
                    try
                    {
                        SoftwareHouse sh = new SoftwareHouse() { Name = name, TaxId = taxId, City = city, Country = country };
                        db.Add(sh);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Problema con la creazione della Software House");
                        Console.WriteLine(ex.Message);
                        i--;

                    }
                }
            }
        }
    }
}
