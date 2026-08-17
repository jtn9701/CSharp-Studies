using System.Text;

namespace RiversideReportingRefactored
{
    class NullReportGenerator : ReportGeneratorBase
    {
        public override void Generate(string outputPath)
        {
            Console.WriteLine("Unrecognized report type or format.");
        }

        protected override List<string[]> FetchData()
        {
            return new List<string[]>{};
        }

        protected override string FormatData(List<string[]> rows)
        {
            return "";
        }
    }
}