 namespace WebInterface.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebInterface.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebInterface.Models.WaterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebInterface.Models.WaterContext context)
        {
            context.Stations.AddOrUpdate(
                s => s.Name,
                new Station
                {
                    Name = "Falling Spring",
                    Latitude = 39.911993,
                    Longitude = -77.616965
                },
                new Station
                {
                    Name = "Grace Island",
                    Latitude = 39.974582,
                    Longitude = -76.470649
                },
                new Station
                {
                    Name = "Delaware River",
                    Latitude = 39.716926,
                    Longitude = -75.500009
                }
            );

            context.SaveChanges();

            context.Samples.RemoveRange(context.Samples.ToList());

            context.SaveChanges();

            var baseTime = DateTime.Now.AddMinutes(-10000);
            Random rnd = new Random();

            foreach (var station in context.Stations)
            {
                int oxyScale = rnd.Next(20, 40);
                int phScale = rnd.Next(5, 15);

                for (int i = 0; i < 10000; i++)
                {
                    station.Samples.Add(new Sample {
                        Station = station,
                        DateTime = baseTime.AddMinutes(i),
                        Oxygen = (oxyScale * Math.Sin(i)) + (rnd.NextDouble() * 5),
                        PH = (phScale * Math.Cos(i + rnd.NextDouble())) + 3,
                        SC = (10 * Math.Sin(i)) + 45,
                        Temperature = (10 * Math.Cos(i)),
                        Turbidity = (20 * Math.Sin(i)) + 30
                    });
                }
            }

            context.SaveChanges();
        }
    }
}
