namespace Refactor
{
    public class GenericCrop : ICrop
    {
        public string CropName { get; } = "GenericCrop";
        public double WateringThreshold { get; } = 40.0;
        public int BaseWateringTimeMinutes { get; } = 15;
        public double GallonsPerSqFtPerMinute { get; } = 0.035;

        public bool NeedsFertigation(Zone zone) => false;
    }
}