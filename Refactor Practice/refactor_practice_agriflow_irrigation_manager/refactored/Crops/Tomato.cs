namespace Refactor
{
    public class Tomato : ICrop
    {
        public string CropName { get; } = "Tomato";
        public double WateringThreshold { get; } = 45.0;
        public int BaseWateringTimeMinutes { get; } = 20;
        public double GallonsPerSqFtPerMinute { get; } = 0.045;

        public bool NeedsFertigation(Zone zone) => zone.SoilMoisturePercent < 40.0;
    }
}