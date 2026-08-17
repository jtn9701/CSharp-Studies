namespace RiversideReportingRefactored
{
    class InputHandler
    {
        public static (ReportType reportType, Format format, string file_name) GetInput()
        {
            string reportType = GetReportType();
            string format = GetFormat();
            return (
                InputValidator.ValidateReportType(reportType),
                InputValidator.ValidateFormat(format),
                GetFileName(reportType, format));
        }

        public static string GetReportType()
        {
            Console.Write("Report type (sales/inventory/customers): ");
            return (Console.ReadLine() ?? "").Trim().ToLower();
        }

        public static string GetFormat()
        {
            Console.Write("Output format (csv/html): ");
            return (Console.ReadLine() ?? "").Trim().ToLower();
        }

        public static string GetFileName(string reportType, string format)
        {
            string defaultName = $"{reportType}_report.{format}";

            Console.Write($"Output file name [{defaultName}]: ");
            string? fileName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = defaultName;
            }
            
            return fileName;

        }
    }
}