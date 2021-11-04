using Gruppeoppgave2.DAL;
using Gruppeoppgave2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppeOppgave2.Models
{
    public class DBInit
    {
        public static void init(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<DB>();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var nyStrekning1 = new Strekning
                {
                    Navn = "Larvik - Hirtshals",
                    Tid = "10:00",
                    Pris = 600
                };

                var nyStrekning2 = new Strekning
                {
                    Navn = "Sandefjord - Strømstad",
                    Tid = "09:30",
                    Pris = 400
                };

                var nyStrekning3 = new Strekning
                {
                    Navn = "Oslo - Kiel",
                    Tid = "11:15",
                    Pris = 750
                };

                var nyStrekning4 = new Strekning
                {
                    Navn = "Kristiansand - Hirtshals",
                    Tid = "17:05",
                    Pris = 500
                };

                var nyStrekning5 = new Strekning
                {
                    Navn = "Hirtshals - Larvik",
                    Tid = "19:00",
                    Pris = 600
                };

                var nyStrekning6 = new Strekning
                {
                    Navn = "Strømstad - Sandefjord",
                    Tid = "21:00",
                    Pris = 400
                };

                var nyStrekning7 = new Strekning
                {
                    Navn = "Kiel - Oslo",
                    Tid = "16:45",
                    Pris = 750
                };

                var nyStrekning8 = new Strekning
                {
                    Navn = "Hirtshals - Kristiansand",
                    Tid = "14:20",
                    Pris = 500
                };


                context.Strekning.Add(nyStrekning3);
                context.Strekning.Add(nyStrekning7);
                context.Strekning.Add(nyStrekning1);
                context.Strekning.Add(nyStrekning5);
                context.Strekning.Add(nyStrekning2);
                context.Strekning.Add(nyStrekning6);
                context.Strekning.Add(nyStrekning4);
                context.Strekning.Add(nyStrekning8);

                var admin = new Adminer();
                admin.Brukernavn = "Admin";
                string passord = "EtBraPassord123";
                byte[] salt = StrekningRepository.LagSalt();
                byte[] hash = StrekningRepository.LagHash(passord, salt);
                admin.Passord = hash;
                admin.Salt = salt;
                context.Adminer.Add(admin);

                context.SaveChanges();
            }
        }
    }
}