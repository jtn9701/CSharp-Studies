namespace RiversideReportingRefactored
{
    class InputValidator
    {
        public static ReportType ValidateReportType(string reportType)
        {
            return reportType switch
            {
                "sales" => ReportType.Sales,
                "inventory" => ReportType.Inventory,
                "customers" => ReportType.Customers,
                _ => throw new ArgumentException($"{reportType} is not a valid report type.")
            };
        }

        public static Format ValidateFormat(string format)
        {
            return format switch
            {
                "csv" => Format.Csv,
                "html" => Format.Html,
                _ => throw new ArgumentException($"{format} is not a valid file format.")
            };
        }
    }
}