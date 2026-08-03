public class Zone
    {
        public string Name { get; set; } = "";
        public ICrop CropType { get; set; } = "";
        public double AreaSquareFeet { get; set; }
        public double SoilMoisturePercent { get; set; }
        public double TemperatureFahrenheit { get; set; }
    }