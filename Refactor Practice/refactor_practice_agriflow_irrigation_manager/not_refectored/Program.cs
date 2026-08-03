using System;
using System.Collections.Generic;

namespace AgriFlow
{
    public class Zone
    {
        public string Name { get; set; } = "";
        public string CropType { get; set; } = "";
        public double AreaSquareFeet { get; set; }
        public double SoilMoisturePercent { get; set; }
        public double TemperatureFahrenheit { get; set; }
    }

    public class IrrigationScheduler
    {
        // Decides whether a zone needs watering today.
        public bool NeedsWatering(Zone zone)
        {
            double threshold;

            if (zone.CropType == "Tomato")
            {
                threshold = 45.0;
            }
            else if (zone.CropType == "Lettuce")
            {
                threshold = 55.0;
            }
            else if (zone.CropType == "Corn")
            {
                threshold = 50.0;
            }
            else if (zone.CropType == "Almond")
            {
                threshold = 35.0;
            }
            else if (zone.CropType == "Grape")
            {
                threshold = 30.0;
            }
            else
            {
                threshold = 40.0;
            }

            return zone.SoilMoisturePercent < threshold;
        }

        // Calculates how many minutes to run the drip line for.
        public int GetWateringDurationMinutes(Zone zone)
        {
            int baseMinutes;

            if (zone.CropType == "Tomato")
            {
                baseMinutes = 20;
            }
            else if (zone.CropType == "Lettuce")
            {
                baseMinutes = 12;
            }
            else if (zone.CropType == "Corn")
            {
                baseMinutes = 25;
            }
            else if (zone.CropType == "Almond")
            {
                baseMinutes = 40;
            }
            else if (zone.CropType == "Grape")
            {
                baseMinutes = 30;
            }
            else
            {
                baseMinutes = 15;
            }

            // Hotter days need a bit more water, regardless of crop.
            if (zone.TemperatureFahrenheit > 90)
            {
                baseMinutes += 8;
            }
            else if (zone.TemperatureFahrenheit > 80)
            {
                baseMinutes += 4;
            }

            return baseMinutes;
        }

        // Decides whether today's watering pass should include fertigation.
        public bool NeedsFertigation(Zone zone)
        {
            if (zone.CropType == "Tomato")
            {
                return zone.SoilMoisturePercent < 40.0;
            }
            else if (zone.CropType == "Lettuce")
            {
                return zone.SoilMoisturePercent < 45.0 && zone.TemperatureFahrenheit < 85;
            }
            else if (zone.CropType == "Corn")
            {
                return zone.SoilMoisturePercent < 42.0;
            }
            else if (zone.CropType == "Almond")
            {
                // Tree crops get fertigation on a much slower cycle.
                return zone.SoilMoisturePercent < 32.0 && zone.TemperatureFahrenheit > 70;
            }
            else if (zone.CropType == "Grape")
            {
                return zone.SoilMoisturePercent < 28.0;
            }
            else
            {
                return false;
            }
        }

        // Estimates gallons used for the day's watering pass.
        public double EstimateWaterUsageGallons(Zone zone, int durationMinutes)
        {
            double gallonsPerSqFtPerMinute;

            if (zone.CropType == "Tomato")
            {
                gallonsPerSqFtPerMinute = 0.045;
            }
            else if (zone.CropType == "Lettuce")
            {
                gallonsPerSqFtPerMinute = 0.03;
            }
            else if (zone.CropType == "Corn")
            {
                gallonsPerSqFtPerMinute = 0.05;
            }
            else if (zone.CropType == "Almond")
            {
                gallonsPerSqFtPerMinute = 0.07;
            }
            else if (zone.CropType == "Grape")
            {
                gallonsPerSqFtPerMinute = 0.04;
            }
            else
            {
                gallonsPerSqFtPerMinute = 0.035;
            }

            return zone.AreaSquareFeet * gallonsPerSqFtPerMinute * durationMinutes;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var zones = new List<Zone>
            {
                new Zone { Name = "North-Tomato-1", CropType = "Tomato", AreaSquareFeet = 900, SoilMoisturePercent = 38, TemperatureFahrenheit = 82 },
                new Zone { Name = "East-Corn-2", CropType = "Corn", AreaSquareFeet = 1500, SoilMoisturePercent = 61, TemperatureFahrenheit = 75 },
                new Zone { Name = "South-Lettuce-3", CropType = "Lettuce", AreaSquareFeet = 600, SoilMoisturePercent = 40, TemperatureFahrenheit = 79 },
                new Zone { Name = "West-Almond-4", CropType = "Almond", AreaSquareFeet = 3000, SoilMoisturePercent = 33, TemperatureFahrenheit = 88 },
                new Zone { Name = "Hill-Grape-5", CropType = "Grape", AreaSquareFeet = 2200, SoilMoisturePercent = 29, TemperatureFahrenheit = 91 },
            };

            var scheduler = new IrrigationScheduler();

            int zonesWatered = 0;
            int zonesFertigated = 0;
            double totalGallons = 0.0;

            Console.WriteLine("=== AgriFlow Daily Irrigation Report ===");

            foreach (var zone in zones)
            {
                Console.WriteLine($"Zone: {zone.Name} ({zone.CropType})");
                Console.WriteLine($"  Moisture: {zone.SoilMoisturePercent}% | Temp: {zone.TemperatureFahrenheit}F");

                if (scheduler.NeedsWatering(zone))
                {
                    int duration = scheduler.GetWateringDurationMinutes(zone);
                    bool fertigate = scheduler.NeedsFertigation(zone);
                    double gallons = scheduler.EstimateWaterUsageGallons(zone, duration);

                    Console.WriteLine($"  Action: WATER for {duration} minutes");
                    Console.WriteLine($"  Fertigation: {(fertigate ? "YES" : "NO")}");
                    Console.WriteLine($"  Estimated usage: {gallons:F1} gallons");

                    zonesWatered++;
                    totalGallons += gallons;
                    if (fertigate) zonesFertigated++;
                }
                else
                {
                    Console.WriteLine("  Action: SKIP (moisture sufficient)");
                    Console.WriteLine("  Fertigation: NO");
                    Console.WriteLine("  Estimated usage: 0.0 gallons");
                }

                Console.WriteLine();
            }

            Console.WriteLine("--- Summary ---");
            Console.WriteLine($"Zones watered: {zonesWatered} / {zones.Count}");
            Console.WriteLine($"Total estimated water usage: {totalGallons:F1} gallons");
            Console.WriteLine($"Zones needing fertigation: {zonesFertigated}");
        }
    }
}