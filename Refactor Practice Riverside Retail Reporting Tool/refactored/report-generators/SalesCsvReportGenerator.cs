using System.Text;

namespace RiversideReportingRefactored
{
    
    class SalesCsvReportGenerator : ReportGeneratorBase
    {
        protected override List<string[]> FetchData()
        {
            return new List<string[]>
            {
                new[] { "Date", "Product", "Amount", "Cashier" },
                new[] { "2026-08-10", "Wireless Mouse", "24.99", "Jenna" },
                new[] { "2026-08-11", "USB-C Cable", "12.50", "Marcus" },
                new[] { "2026-08-12", "Bluetooth Speaker", "59.99", "Jenna" },
                new[] { "2026-08-14", "Laptop Stand", "34.00", "Priya" },
            };
        }

        protected override string FormatData(List<string[]> rows)
        {
            var sb = new StringBuilder();
            foreach (var row in rows)
            {
                sb.AppendLine(string.Join(",", row));
            }
            return sb.ToString();
        }
    }
}