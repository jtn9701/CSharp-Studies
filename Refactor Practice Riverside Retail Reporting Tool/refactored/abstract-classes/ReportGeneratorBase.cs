namespace RiversideReportingRefactored
{
    abstract class ReportGeneratorBase
    {
        public virtual void Generate(string outputPath)
        {
            var rows = FetchData();
            var formatted = FormatData(rows);
            File.WriteAllText(outputPath, formatted);
            Console.WriteLine($"Report saved to {outputPath}");
        }

        protected abstract List<string[]> FetchData();
        protected abstract string FormatData(List<string[]> rows);
    }
}