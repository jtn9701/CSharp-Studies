public class Lettuce : ICrop
{
    public string CropName { get; } = "Lettuce";
    public float WateringThreshold { get; } = 55.0;
    public int BaseWateringTimeMinuntes { get; } = 12;
    public float GallonsPerSqFtPerMinute { get; } = 0.03;

    public bool NeedsFertigation(Zone zone) => zone.SoilMoisturePercent < 45.0 && zone.TemperatureFahrenheit < 85;
}