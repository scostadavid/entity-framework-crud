using System;
using System.Linq;
using System.Collections.Generic;
using EF_CRUD.Models;

namespace EF_CRUD.Data
{
    public static class DBSeeder
    {
        public static void Initialize(DatabaseContext context)
        {
            // DB has been seeded
            if (context.Client.Any())
            {
                return;   
            }
 
            string[] nameList = new string[] {
                "Newton", "Santa", "Ulrike", "Marisa", "Samella", "Santos", "Lenna", "Sharlene", "Palmira", "Joann", "Eleonore", "Conrad", "Evie", "Illa", "Stepanie", "Cordell", "Emma", "Nakita", "Zena", "Gisele", "Young", "Daphine", "Aiko", "Glayds", "Rosia", "Dewayne", "Antony", "Macie", "Albertina", "Maragret", "Nelle", "Carol", "Kayce", "Mickie", "Emeline", "Dudley", "June", "Nikki", "Colleen", "Sulema", "Deann", "Zoe", "Rhett", "Jolynn", "Ora", "Ramon", "Slyvia", "Colene", "Lili", "Simona"  
            };
                
            Random random = new Random();

            var clients = new List<PhysicalPerson>();
            
            for(int i = 0; i < 50; i++) 
            {
                clients.Add
                (
                    new PhysicalPerson {
                        FirstMidName= nameList[random.Next(0, nameList.Length)] + i.ToString(),
                        LastName= nameList[random.Next(0, nameList.Length)] + i.ToString(),
                        CPF=random.Next(0, 9) + "23.456.789-1" + random.Next(0, 9), 
                        BirthDate=DateTime.Parse("2018-12-01")
                    }
                );
            }

            context.PhysicalPeople.AddRange(clients);
            context.SaveChanges();

            var clients2 = new List<JuridicalPerson>();
            for(int i = 0; i < 50; i++) 
            {
                clients2.Add
                (
                    new JuridicalPerson {
                        CompanyName="Company Inc." + i.ToString(),
                        TradeName="Comp" + i.ToString(),
                        CNPJ= random.Next(0, 9) + "2.345.678/0000-9" + random.Next(0, 6)
                    }
                );
            }

            context.JuridicalPeople.AddRange(clients2);
            context.SaveChanges();

            var clientsPhones = new List<Phone>();

            foreach(var PF in context.PhysicalPeople)
            {
                
                clientsPhones.Add
                (
                    new Phone {
                        ClientID=PF.ClientID,
                        PhoneNumber="+551711111111",
                        PhoneType=PhoneType.CELL_PHONE
                    }
                );
            }

            context.Phone.AddRange(clientsPhones);
            context.SaveChanges();

            var clientsPhones2 = new List<Phone>();

            foreach(var PJ in context.JuridicalPeople)
            {
                clientsPhones2.Add
                (
                    new Phone {
                        ClientID=PJ.ClientID,
                        PhoneNumber="+551711111111",
                        PhoneType=PhoneType.COMMERCIAL
                    }
                );
            }

            context.Phone.AddRange(clientsPhones2);
            context.SaveChanges();
  

            var clientsAdresses = new List<Adress>();

            foreach(var PF in context.PhysicalPeople)
            {
                clientsAdresses.Add
                (
                    new Adress {
                        ClientID=PF.ClientID,
                        City="City" + PF.ClientID.ToString(),
                        State="SP",
                        Country="Brazil",
                        PostalCode="11111-000",
                        StreetName="St. " + nameList[random.Next(0, nameList.Length)],
                        AddressNumber=PF.ClientID,
                        AdressType=AdressType.BILLING,
                    }
                );
            }

            context.Adress.AddRange(clientsAdresses);
            context.SaveChanges();

            var clientsAdresses2 = new List<Adress>();

            foreach(var PJ in context.JuridicalPeople)
            {
                clientsAdresses2.Add
                (
                    new Adress {
                        ClientID=PJ.ClientID,
                        City="City" + PJ.ClientID.ToString(),
                        State="SP",
                        Country="Brazil",
                        PostalCode="11111-000",
                        StreetName="St. " + nameList[random.Next(0, nameList.Length)],
                        AddressNumber=PJ.ClientID,
                        AdressType=AdressType.COMMERCIAL,
                    }
                );
            }

            context.Adress.AddRange(clientsAdresses2);
            context.SaveChanges();
        }
    }
}