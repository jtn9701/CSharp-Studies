public class Tomato : ICrop
{
    public string CropName { get; } = "Tomato";
    public float WateringThreshold { get; } = 45.0;
    public int BaseWateringTimeMinuntes { get; } = 20;
    public float GallonsPerSqFtPerMinute { get; } = 0.045;

    public bool NeedsFertigation(Zone zone) => zone.SoilMoisturePercent < 40.0;
}