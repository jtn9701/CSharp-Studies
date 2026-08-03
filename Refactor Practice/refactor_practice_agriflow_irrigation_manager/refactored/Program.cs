public class Program
{
    public static void Main(string[] args)
    {
        var zones = new List<Zone>
        {
            new Zone { Name = "North-Tomato-1", CropType = new Tomato(), AreaSquareFeet = 900, SoilMoisturePercent = 38, TemperatureFahrenheit = 82 },
            new Zone { Name = "East-Corn-2", CropType = new Corn(), AreaSquareFeet = 1500, SoilMoisturePercent = 61, TemperatureFahrenheit = 75 },
            new Zone { Name = "South-Lettuce-3", CropType = new Lettuce(), AreaSquareFeet = 600, SoilMoisturePercent = 40, TemperatureFahrenheit = 79 },
            new Zone { Name = "West-Almond-4", CropType = new Almond(), AreaSquareFeet = 3000, SoilMoisturePercent = 33, TemperatureFahrenheit = 88 },
            new Zone { Name = "Hill-Grape-5", CropType = new Grape(), AreaSquareFeet = 2200, SoilMoisturePercent = 29, TemperatureFahrenheit = 91 },
        };

        var scheduler = new IrrigationScheduler();

        int zonesWatered = 0;
        int zonesFertigated = 0;
        double totalGallons = 0.0;

        Console.WriteLine("=== AgriFlow Daily Irrigation Report ===");

        foreach (var zone in zones)
        {
            Console.WriteLine($"Zone: {zone.Name} ({zone.CropType.CropName})");
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