namespace RiversideReportingRefactored
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Riverside Retail Reporting Tool ===");

            (ReportType reportType, Format format, string fileName)= InputHandler.GetInput();

            ReportGeneratorBase generator = ReportGeneratorFactory.CreateReport(
                reportType, 
                format);

            generator.Generate(fileName);
        }
    }
}