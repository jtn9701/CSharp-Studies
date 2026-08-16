namespace Refactor
{
    public class Almond : ICrop
    {
        public string CropName { get; } = "Almond";
        public double WateringThreshold { get; } = 35.0;
        public int BaseWateringTimeMinutes { get; } = 40;
        public double GallonsPerSqFtPerMinute { get; } = 0.07;

        public bool NeedsFertigation(Zone zone) => zone.SoilMoisturePercent < 32.0 && zone.TemperatureFahrenheit > 70;
    }
}