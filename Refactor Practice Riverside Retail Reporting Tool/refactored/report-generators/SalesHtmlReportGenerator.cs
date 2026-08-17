using System.Text;

namespace RiversideReportingRefactored
{
    class SalesHtmlReportGenerator : ReportGeneratorBase
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
            sb.AppendLine("<html><head><title>Sales Report</title></head><body>");
            sb.AppendLine("<h1>Sales Report</h1><table border='1'>");
            foreach (var row in rows)
            {
                sb.AppendLine("<tr>" + string.Join("", Array.ConvertAll(row, c => $"<td>{c}</td>")) + "</tr>");
            }
            sb.AppendLine("</table></body></html>");
            return sb.ToString();
        }
    }
}