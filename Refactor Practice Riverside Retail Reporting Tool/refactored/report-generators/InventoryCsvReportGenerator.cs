using System.Text;

namespace RiversideReportingRefactored
{

    class InventoryCsvReportGenerator : ReportGeneratorBase
    {
        protected override List<string[]> FetchData()
        {
            return new List<string[]>
            {
                new[] { "SKU", "Product", "QtyOnHand", "ReorderThreshold" },
                new[] { "SKU-1001", "Wireless Mouse", "42", "15" },
                new[] { "SKU-1002", "USB-C Cable", "8", "20" },
                new[] { "SKU-1003", "Bluetooth Speaker", "17", "10" },
                new[] { "SKU-1004", "Laptop Stand", "3", "5" },
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