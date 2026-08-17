using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RiversideReporting
{
    abstract class ReportGeneratorBase
    {
        public void Generate(string outputPath)
        {
            var rows = FetchData();
            var formatted = FormatData(rows);
            File.WriteAllText(outputPath, formatted);
            Console.WriteLine($"Report saved to {outputPath}");
        }

        protected abstract List<string[]> FetchData();
        protected abstract string FormatData(List<string[]> rows);
    }

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

    class InventoryHtmlReportGenerator : ReportGeneratorBase
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
            sb.AppendLine("<html><head><title>Inventory Report</title></head><body>");
            sb.AppendLine("<h1>Inventory Report</h1><table border='1'>");
            foreach (var row in rows)
            {
                sb.AppendLine("<tr>" + string.Join("", Array.ConvertAll(row, c => $"<td>{c}</td>")) + "</tr>");
            }
            sb.AppendLine("</table></body></html>");
            return sb.ToString();
        }
    }

    class CustomerCsvReportGenerator : ReportGeneratorBase
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
            foreach (var row in rows)
            {
                sb.AppendLine(string.Join(",", row));
            }
            return sb.ToString();
        }
    }

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

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Riverside Retail Reporting Tool ===");

            Console.Write("Report type (sales/inventory/customers): ");
            string reportType = (Console.ReadLine() ?? "").Trim().ToLower();

            Console.Write("Output format (csv/html): ");
            string format = (Console.ReadLine() ?? "").Trim().ToLower();

            string defaultName = $"{reportType}_report.{format}";
            Console.Write($"Output file name [{defaultName}]: ");
            string fileName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = defaultName;
            }

            ReportGeneratorBase generator = null;

            if (reportType == "sales" && format == "csv")
            {
                generator = new SalesCsvReportGenerator();
            }
            else if (reportType == "sales" && format == "html")
            {
                generator = new SalesHtmlReportGenerator();
            }
            else if (reportType == "inventory" && format == "csv")
            {
                generator = new InventoryCsvReportGenerator();
            }
            else if (reportType == "inventory" && format == "html")
            {
                generator = new InventoryHtmlReportGenerator();
            }
            else if (reportType == "customers" && format == "csv")
            {
                generator = new CustomerCsvReportGenerator();
            }
            else if (reportType == "customers" && format == "html")
            {
                generator = new CustomerHtmlReportGenerator();
            }
            else
            {
                Console.WriteLine("Unrecognized report type or format.");
                return;
            }

            generator.Generate(fileName);
        }
    }
}