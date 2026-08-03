public class Grape : ICrop
{
    public string CropName { get; } = "Grape";
    public float WateringThreshold { get; } = 30.0;
    public int BaseWateringTimeMinuntes { get; } = 30;
    public float GallonsPerSqFtPerMinute { get; } = 0.04;

    public bool NeedsFertigation(Zone zone) => zone.SoilMoisturePercent < 28.0;

}