public class Corn : ICrop
{
    public string CropName { get; } = "Corn";
    public float WateringThreshold { get; } = 50.0;
    public int BaseWateringTimeMinuntes { get; } = 25;
    public float GallonsPerSqFtPerMinute { get; } = 0.05;

    public bool NeedsFertigation(Zone zone) => zone.SoilMoisturePercent < 42.0;
}