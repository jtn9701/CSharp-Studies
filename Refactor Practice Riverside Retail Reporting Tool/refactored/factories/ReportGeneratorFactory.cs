namespace RiversideReportingRefactored
{
    class ReportGeneratorFactory
    {
        public static ReportGeneratorBase CreateReport(ReportType reportType, Format format)
        {
            return (reportType, format) switch {
                (ReportType.Sales, Format.Csv) => new SalesCsvReportGenerator(),
                (ReportType.Sales, Format.Html) => new SalesHtmlReportGenerator(),
                (ReportType.Inventory, Format.Csv) => new InventoryCsvReportGenerator(),
                (ReportType.Inventory, Format.Html) => new InventoryHtmlReportGenerator(),
                (ReportType.Customers, Format.Csv) => new CustomerCsvReportGenerator(),
                (ReportType.Customers, Format.Html) => new CustomerHtmlReportGenerator(),
                _ => new NullReportGenerator()
            };
            
        }
    }
}