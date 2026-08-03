public class GenericCrop : ICrop
{
    public string CropName { get; } = "GenericCrop";
    public float WateringThreshold { get; } = 40.0;
    public int BaseWateringTimeMinuntes { get; } = 15;
    public float GallonsPerSqFtPerMinute { get; } = 0.035;

    public bool NeedsFertigation(Zone zone) => false;
}