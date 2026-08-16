
namespace Refactor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var zones = new List<Zone>
            {
                new Zone { Name = "North-Tomato-1", CropType = CropFactory.CreateCrop("Tomato"), AreaSquareFeet = 900, SoilMoisturePercent = 38, TemperatureFahrenheit = 82 },
                new Zone { Name = "East-Corn-2", CropType = CropFactory.CreateCrop("Corn"), AreaSquareFeet = 1500, SoilMoisturePercent = 61, TemperatureFahrenheit = 75 },
                new Zone { Name = "South-Lettuce-3", CropType = CropFactory.CreateCrop("Lettuce"), AreaSquareFeet = 600, SoilMoisturePercent = 40, TemperatureFahrenheit = 79 },
                new Zone { Name = "West-Almond-4", CropType = CropFactory.CreateCrop("Almond"), AreaSquareFeet = 3000, SoilMoisturePercent = 33, TemperatureFahrenheit = 88 },
                new Zone { Name = "Hill-Grape-5", CropType = CropFactory.CreateCrop("Grape"), AreaSquareFeet = 2200, SoilMoisturePercent = 29, TemperatureFahrenheit = 91 },
            };

            var scheduler = new IrrigationScheduler();

            ReportBuilder.BuildReport(zones, scheduler, out int zonesWatered, out int zonesFertigated, out double totalGallons);
            
        }
    }
}