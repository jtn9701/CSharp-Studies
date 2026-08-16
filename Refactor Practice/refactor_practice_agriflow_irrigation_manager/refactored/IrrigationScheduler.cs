namespace Refactor
{    
    public class IrrigationScheduler
        {
            public bool NeedsWatering(Zone zone) => zone.SoilMoisturePercent < zone.CropType!.WateringThreshold;

            public int GetWateringDurationMinutes(Zone zone) => 
                zone.CropType!.BaseWateringTimeMinutes + GetExtraWateringTimeBasedOnTemp(zone.TemperatureFahrenheit);

            public bool NeedsFertigation(Zone zone) => zone.CropType!.NeedsFertigation(zone);

            public double EstimateWaterUsageGallons(Zone zone, int durationMinutes) => 
                zone.AreaSquareFeet * zone.CropType!.GallonsPerSqFtPerMinute * durationMinutes;
        
            // --------------- HELPERS --------------- //
            int GetExtraWateringTimeBasedOnTemp(double temperatureFahrenheit) => temperatureFahrenheit switch 
            {
                > 90 => 8,
                > 80 => 4,
                _ => 0
            };
            
        } // END CLASS
}