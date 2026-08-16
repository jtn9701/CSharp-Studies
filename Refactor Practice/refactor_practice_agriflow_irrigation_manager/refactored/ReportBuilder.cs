namespace Refactor
{
    public class ReportBuilder
    {
        public static void BuildReport(List<Zone> zones, IrrigationScheduler scheduler, out int zonesWatered, out int zonesFertigated, out double totalGallons)
        {
            zonesWatered = 0;
            zonesFertigated = 0;
            totalGallons = 0.0;

            Console.WriteLine("=== AgriFlow Daily Irrigation Report ===");

            foreach (var zone in zones)
            {
                Console.WriteLine($"Zone: {zone.Name} ({zone.CropType!.CropName})");
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