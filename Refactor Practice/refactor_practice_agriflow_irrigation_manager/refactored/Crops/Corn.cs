namespace Refactor
{
    public class Corn : ICrop
    {
        public string CropName { get; } = "Corn";
        public double WateringThreshold { get; } = 50.0;
        public int BaseWateringTimeMinutes { get; } = 25;
        public double GallonsPerSqFtPerMinute { get; } = 0.05;

        public bool NeedsFertigation(Zone zone) => zone.SoilMoisturePercent < 42.0;
    }
}