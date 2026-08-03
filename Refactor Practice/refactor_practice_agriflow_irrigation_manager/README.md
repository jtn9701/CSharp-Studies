# AgriFlow Irrigation Manager

AgriFlow is a console-based decision engine for small-to-mid-size farms running
automated drip irrigation. It ingests simulated soil sensor readings for each
field zone and produces a daily irrigation plan: how long to run water for,
whether to inject fertilizer through the line (fertigation), and how much
water each zone is expected to consume.

## Features

- Tracks multiple irrigation zones, each with its own crop type, soil area,
  and current sensor readings (soil moisture %, ambient temperature °F).
- Automatically determines whether a zone needs watering today based on
  crop-specific moisture thresholds.
- Calculates recommended watering duration in minutes, tuned per crop type
  and adjusted for temperature.
- Flags zones that need a fertigation (nutrient injection) pass, based on
  crop-specific fertilizer cycles and current growth conditions.
- Estimates total water usage (in gallons) per zone for the day.
- Prints a consolidated daily report to the console, and a farm-wide summary
  (total zones watered, total gallons used, zones needing attention).

## Supported Crop Types

The current release ships with tuned profiles for:

- Tomato
- Lettuce
- Corn
- Almond (tree crop)
- Grape (vineyard)

Unrecognized crop types fall back to a conservative generic watering profile.

## Example Output
=== AgriFlow Daily Irrigation Report ===
Zone: North-Tomato-1 (Tomato)
Moisture: 38% | Temp: 82F
Action: WATER for 22 minutes
Fertigation: YES
Estimated usage: 148.5 gallons

Zone: East-Corn-2 (Corn)
Moisture: 61% | Temp: 75F
Action: SKIP (moisture sufficient)
Fertigation: NO
Estimated usage: 0.0 gallons

--- Summary ---
Zones watered: 3 / 5
Total estimated water usage: 412.7 gallons
Zones needing fertigation: 2

## Inputs

Sensor readings are simulated in-code for this release (representing a feed
that would normally come from field hardware). Each zone has:

- `Name` — identifier for the zone
- `CropType` — one of the supported crop types above
- `AreaSquareFeet` — planted area
- `SoilMoisturePercent` — current soil moisture reading
- `TemperatureFahrenheit` — current ambient temperature

## Output

A formatted daily report is printed to standard output, covering each zone's
watering decision, duration, fertigation flag, and estimated water usage, plus
a farm-wide summary at the end.

## Requirements

- .NET 8 SDK

## How to Run

1. Save the source file as `Program.cs` in a new folder.
2. In that folder, create a console project and drop the file in, or simply
   run the following from the folder containing `Program.cs`:

```bash
   dotnet new console -o AgriFlow --force
   copy Program.cs AgriFlow\Program.cs   # Windows
   # or: cp Program.cs AgriFlow/Program.cs   # macOS/Linux
   cd AgriFlow
   dotnet run
```

3. The daily irrigation report will print to the console.