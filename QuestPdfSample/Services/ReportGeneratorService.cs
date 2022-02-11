using QuestPDF.Fluent;
using QuestPdfSample.Reports;

namespace QuestPdfSample.Services
{
	public class ReportGeneratorService
	{
		private readonly DataService dataService;

		public ReportGeneratorService(DataService dataService)
		{
			this.dataService = dataService;
		}
		public void GenerateReport(Stream stream)
		{
			var model = dataService.GetInvoiceDetails();
			var document = new InvoiceDocument(model);
			document.GeneratePdf(stream);
		}
	}
}
