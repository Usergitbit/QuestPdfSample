using Bogus;
using QuestPdfSample.Models.Reports;

namespace QuestPdfSample.Services
{
	public class DataService
	{
        private static readonly Faker<Invoice> invoiceFaker = new Faker<Invoice>()
            .RuleFor(i => i.InvoiceNumber, f => f.Random.Int(1, 10000))
            .RuleFor(i => i.Comments, f => f.Hacker.Phrase())
            .RuleFor(i => i.DueDate, f => f.Date.Future())
            .RuleFor(i => i.IssueDate, f => f.Date.Recent())
            .RuleFor(i => i.Items, f => orderItemFaker.GenerateBetween(1, 10))
            .RuleFor(i => i.CustomerAddress, f => addressFaker.Generate())
            .RuleFor(i => i.SellerAddress, f => addressFaker.Generate());
        private static readonly Faker<Address> addressFaker = new Faker<Address>()
            .RuleFor(a => a.City, f => f.Address.City())
            .RuleFor(a => a.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(a => a.Email, f => f.Internet.Email())
            .RuleFor(a => a.Street, f => f.Address.StreetAddress())
            .RuleFor(a => a.State, f => f.Address.State())
            .RuleFor(a => a.CompanyName, f => f.Company.CompanyName());
        private static readonly Faker<OrderItem> orderItemFaker = new Faker<OrderItem>()
            .RuleFor(oi => oi.Name, f => f.Commerce.Product())
            .RuleFor(oi => oi.Price, f => f.Random.Decimal(1, 100, 2))
            .RuleFor(oi => oi.Quantity, f => f.Random.Int(1, 10));

        public Invoice GetInvoiceDetails()
        {
            return invoiceFaker.Generate();
        }
    }

    public static class ExtensionsForRandomizer
    {
        public static decimal Decimal(this Randomizer r, decimal min = 0.0m, decimal max = 1.0m, int? decimals = null)
        {
            var value = r.Decimal(min, max);
            if (decimals.HasValue)
            {
                return Math.Round(value, decimals.Value);
            }
            return value;
        }
    }
}
