namespace Refactor
{
    public class Lettuce : ICrop
    {
        public string CropName { get; } = "Lettuce";
        public double WateringThreshold { get; } = 55.0;
        public int BaseWateringTimeMinutes { get; } = 12;
        public double GallonsPerSqFtPerMinute { get; } = 0.03;

        public bool NeedsFertigation(Zone zone) => zone.SoilMoisturePercent < 45.0 && zone.TemperatureFahrenheit < 85;
    }
}