using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_2.Models
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
                    Pris = 600
                };

                var nyStrekning2 = new Strekning
                {
                    Navn = "Sandefjord - Strømstad",
                    Pris = 400
                };

                var nyStrekning3 = new Strekning
                {
                    Navn = "Oslo - Kiel",
                    Pris = 750
                };

                var nyStrekning4 = new Strekning
                {
                    Navn = "Kristiansand - Hirtshals",
                    Pris = 500
                };

                var nyStrekning5 = new Strekning
                {
                    Navn = "Hirtshals - Larvik",
                    Pris = 600
                };

                var nyStrekning6 = new Strekning
                {
                    Navn = "Strømstad - Sandefjord",
                    Pris = 400
                };

                var nyStrekning7 = new Strekning
                {
                    Navn = "Kiel - Oslo",
                    Pris = 750
                };

                var nyStrekning8 = new Strekning
                {
                    Navn = "Hirtshals - Kristiansand",
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
                context.SaveChanges();
            }
        }
    }
}