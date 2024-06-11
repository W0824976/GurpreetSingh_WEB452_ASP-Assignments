using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ChronoGen.Data;
using System;
using System.Linq;

namespace ChronoGen.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ChronoGenContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ChronoGenContext>>()))
            {
                // Look for any movies.
                if (context.Watch.Any())
                {
                    return;   // DB has been seeded
                }
                context.Watch.AddRange(
                    new Watch
                    {
                        WatchName = "FX150",
                        DesignerName = "Roy",
                        Material = "Steel",
                        Size = "Medium",
                        ReleaseDate = DateTime.Parse("2023-3-13"),
                        Price = 150.88M,
                        CustomerReview = 4,
                        Rating = "Good",
                    },
                    new Watch
                    {
                        WatchName = "GTX200",
                        DesignerName = "Eva",
                        Material = "Titanium",
                        Size = "Large",
                        ReleaseDate = DateTime.Parse("2022-07-25"),
                        Price = 299.99M,
                        CustomerReview = 4,
                        Rating = "Good"
                    },
                    new Watch
                    {
                        WatchName = "ChronoMaster",
                        DesignerName = "Max",
                        Material = "Stainless Steel",
                        Size = "Medium",
                        ReleaseDate = DateTime.Parse("2023-01-10"),
                        Price = 249.50M,
                        CustomerReview = 4,
                        Rating = "Good"
                    },
                    // Add more watch objects here...
                    new Watch
                    {
                        WatchName = "TimeCraft",
                        DesignerName = "Sophie",
                        Material = "Leather",
                        Size = "Small",
                        ReleaseDate = DateTime.Parse("2024-05-08"),
                        Price = 199.99M,
                        CustomerReview = 2,
                        Rating = "Below Average"
                    },
                    new Watch
                    {
                        WatchName = "AquaLux",
                        DesignerName = "Oliver",
                        Material = "Aluminum",
                        Size = "Medium",
                        ReleaseDate = DateTime.Parse("2023-11-15"),
                        Price = 179.95M,
                        CustomerReview = 3,
                        Rating = "Average"
                    },
                    new Watch
                    {
                        WatchName = "SilverArrow",
                        DesignerName = "Lily",
                        Material = "Silver",
                        Size = "Small",
                        ReleaseDate = DateTime.Parse("2024-02-20"),
                        Price = 199.00M,
                        CustomerReview = 5,
                        Rating = "Average"
                    },
                    new Watch
                    {
                        WatchName = "SunriseX",
                        DesignerName = "Leo",
                        Material = "Gold",
                        Size = "Large",
                        ReleaseDate = DateTime.Parse("2022-12-05"),
                        Price = 349.99M,
                        CustomerReview = 4,
                        Rating = "Good"
                    },
                    new Watch
                    {
                        WatchName = "SkyDiver",
                        DesignerName = "Aria",
                        Material = "Plastic",
                        Size = "Medium",
                        ReleaseDate = DateTime.Parse("2023-09-18"),
                        Price = 99.95M,
                        CustomerReview = 3,
                        Rating = "Average"
                    },
                    new Watch
                    {
                        WatchName = "NightOwl",
                        DesignerName = "Mia",
                        Material = "Ceramic",
                        Size = "Small",
                        ReleaseDate = DateTime.Parse("2024-04-30"),
                        Price = 279.00M,
                        CustomerReview = 3,
                        Rating = "Good"
                    },
                    new Watch
                    {
                        WatchName = "LunarEdge",
                        DesignerName = "Ethan",
                        Material = "Rose Gold",
                        Size = "Medium",
                        ReleaseDate = DateTime.Parse("2023-07-12"),
                        Price = 299.50M,
                        CustomerReview = 4,
                        Rating = "Good"
                    }


                );
                context.SaveChanges();
            }
        }

    }
}
