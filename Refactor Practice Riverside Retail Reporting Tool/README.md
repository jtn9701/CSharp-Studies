# Riverside Retail Reporting Tool

A lightweight console utility for generating business reports from Riverside Retail's internal data. Store managers and analysts use this tool at the end of each shift or week to export data snapshots for review or sharing with stakeholders.

## Features

- Generate reports from three data domains:
  - **Sales** — recent transaction records (date, product, amount, cashier)
  - **Inventory** — current stock levels (SKU, product name, quantity on hand, reorder threshold)
  - **Customers** — customer loyalty records (customer ID, name, loyalty points, tier)
- Export each report in one of two formats:
  - **CSV** — for opening in Excel/Google Sheets or importing into other systems
  - **HTML** — for quick viewing in a browser or pasting into an email/intranet page
- Reports are written to a file on disk, and the tool confirms the save location when finished.

## Usage

When you run the tool, it will prompt you interactively:

1. Choose a report type: `sales`, `inventory`, or `customers`
2. Choose an output format: `csv` or `html`
3. Enter a file name (or accept the suggested default)

The tool will fetch the relevant sample dataset, format it accordingly, and write it to the specified file in the current working directory.

### Example session

=== Riverside Retail Reporting Tool ===
Report type (sales/inventory/customers): sales
Output format (csv/html): html
Output file name [sales_report.html]:
Report saved to sales_report.html

## Expected Output

- **CSV reports** contain a header row followed by one row per record, comma-separated.
- **HTML reports** produce a simple styled table with a title matching the report type, suitable for viewing in any browser.

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download)

## How to Run

1. Create a new console project (or use the provided `Program.cs` directly):
```bash
   dotnet new console -n RiversideReporting
   cd RiversideReporting
```
2. Replace the generated `Program.cs` with the `Program.cs` file provided in this project.
3. Run the application:
```bash
   dotnet run
```
4. Follow the interactive prompts to generate your report.

## Notes

- This tool currently ships with representative sample data for each domain (no external database or file connection is required) so it can be used for demos, training, and format testing without needing live store data.