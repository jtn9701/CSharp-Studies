using System.Text;

namespace RiversideReportingRefactored
{


    class CustomerHtmlReportGenerator : ReportGeneratorBase
    {
        protected override List<string[]> FetchData()
        {
            return new List<string[]>
            {
                new[] { "CustomerId", "Name", "LoyaltyPoints", "Tier" },
                new[] { "C-501", "Alicia Gomez", "1240", "Gold" },
                new[] { "C-502", "Ben Turner", "310", "Silver" },
                new[] { "C-503", "Devon Wu", "58", "Bronze" },
                new[] { "C-504", "Fatima Noor", "2890", "Platinum" },
            };
        }

        protected override string FormatData(List<string[]> rows)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<html><head><title>Customer Report</title></head><body>");
            sb.AppendLine("<h1>Customer Report</h1><table border='1'>");
            foreach (var row in rows)
            {
                sb.AppendLine("<tr>" + string.Join("", Array.ConvertAll(row, c => $"<td>{c}</td>")) + "</tr>");
            }
            sb.AppendLine("</table></body></html>");
            return sb.ToString();
        }
    }
}