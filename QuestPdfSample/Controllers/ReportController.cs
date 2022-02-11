using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestPdfSample.Services;

namespace QuestPdfSample.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReportController : ControllerBase
	{
		private readonly ReportGeneratorService reportGeneratorService;

		public ReportController(ReportGeneratorService reportGeneratorService)
		{
			this.reportGeneratorService = reportGeneratorService;
		}
		[HttpGet("invoice")]
		public IActionResult GenerateInvoice()
		{
			//TODO: write directly to response stream when library will support it. See: https://github.com/QuestPDF/QuestPDF/issues/52
			var stream = new MemoryStream();
			reportGeneratorService.GenerateReport(stream);
			stream.Seek(0, SeekOrigin.Begin);
			return File(stream, "application/pdf", "invoice.pdf");
		}
	}
}
