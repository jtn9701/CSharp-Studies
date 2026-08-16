namespace Refactor
{
    public interface ICrop
    {
        string CropName { get; }
        double WateringThreshold { get; }
        int BaseWateringTimeMinutes { get; }
        double GallonsPerSqFtPerMinute { get; }
        abstract bool NeedsFertigation(Zone zone);
    }
}