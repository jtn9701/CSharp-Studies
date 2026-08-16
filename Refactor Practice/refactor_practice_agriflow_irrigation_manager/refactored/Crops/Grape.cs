namespace Refactor
{
    public class Grape : ICrop
    {
        public string CropName { get; } = "Grape";
        public double WateringThreshold { get; } = 30.0;
        public int BaseWateringTimeMinutes { get; } = 30;
        public double GallonsPerSqFtPerMinute { get; } = 0.04;

        public bool NeedsFertigation(Zone zone) => zone.SoilMoisturePercent < 28.0;

    }
}