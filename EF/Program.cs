using Company.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF
{
    class Program
    {
        
        static void Main(string[] args)
        {

            using(var context = new WoningContext())
            {
                
                //InsertWoning();
                InsertrelatedData(context);
                GetWoningen(context);
            }
            
        }

        private static void GetWoningen(WoningContext context)
        {
            var woningen = context.Woningen.ToList();
            foreach (var woning in woningen)
            {
                Console.WriteLine(woning.Naam);
            }
            Console.ReadLine();
        }

        private static void InsertrelatedData(WoningContext context)
        {
            context.Woningen.Add(
                new Woning
                {
                    Naam = "Nog een huis",
                    Huisnummer = 12,
                    Bewoners = new List<Bewoner>
                        {
                            new Bewoner{Naam="Jopie"},
                            new Bewoner{Naam="Jan"}
                        }
                }
                );
            context.SaveChanges();
        }

        //private static void InsertWoning(WoningContext context)
        //{
        //    context.Woningen.Add(new Woning { Naam = "HuizeFortune" });
        //    context.SaveChanges();
        //}
    }
}
