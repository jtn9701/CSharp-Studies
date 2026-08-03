public class Almond : ICrop
{
    public string CropName { get; } = "Almond";
    public float WateringThreshold { get; } = 35.0;
    public int BaseWateringTimeMinuntes { get; } = 40;
    public float GallonsPerSqFtPerMinute { get; } = 0.07;

    public bool NeedsFertigation(Zone zone) => zone.SoilMoisturePercent < 32.0 && zone.TemperatureFahrenheit > 70;
}