

namespace TP24Technical;

public class DataSeeder
{
    private readonly ReceivableDbContext _context;
    // List<string> currencies = new List<string> { "USD", "EUR", "JPY", "GBP", "AUD","CAD", "CHF", "CNY", "SEK", "NZD","SGD", "HKD", "NOK", "KRW", "INR","BRL", "ZAR", "MXN", "RUB", "AED","RM" ,"RS"};
    //Dictionary<string, string> currencyCOuntryCodes = new Dictionary<string, string> {{"USD", "1"},{"EUR", "33"},{"JPY", "81"},{"GBP", "44"},{"AUD", "61"},{"CAD", "1"},{"CHF", "41"},{"CNY", "86"},{"SEK", "46"},{"NZD", "64"},{"SGD", "65"},{"HKD", "852"},{"NOK", "47"},{"KRW", "82"},{"INR", "91"},{"BRL", "55"}, {"ZAR", "27"}, {"MXN", "52"},{"RUB", "7"}, {"AED", "971"},{"RM", "60"}, {"RS", "381"}};

    public DataSeeder(ReceivableDbContext context)
    {
        _context = context;
    }

    public void SeedReceivables()
    {
        var random = new Random() ;
        var receivables = new List<Receivable> {

            new Receivable {
                Reference = "Reference-0",
                CurrencyCode = "SGD",
                IssueDate = new DateTime(2020,10,24),
                OpeningValue = 724.40m,
                PaidValue = 634.31m,
                DueDate = new DateTime(2023, 11, 4),
                ClosedDate = null,
                Cancelled = false,
                DebtorName = "Debtor-0",
                DebtorReference = "DebtorRef-0",
                DebtorAddress1 = "Address1-0",
                DebtorAddress2 = "Address2-0",
                DebtorTown = "Town-0",
                DebtorState = "State-0",
                DebtorZip = "Zip-0",
                DebtorCountryCode = "65",
                DebtorRegistrationNumber = "RegNo-0"
            },
           new Receivable {
                Reference = "Reference-1",
                CurrencyCode = "NOK",
                IssueDate = new DateTime(2020,10,24),
                OpeningValue = 800.40m,
                PaidValue = 634.31m,
                DueDate = new DateTime(2023, 11, 4),
                ClosedDate = null,
                Cancelled = false,
                DebtorName = "Debtor-1",
                DebtorReference = "DebtorRef-1",
                DebtorAddress1 = "Address1-1",
                DebtorAddress2 = "Address2-1",
                DebtorTown = "Town-1",
                DebtorState = "State-1",
                DebtorZip = "Zip-1",
                DebtorCountryCode = "47",
                DebtorRegistrationNumber = "RegNo-1"
            },
             new Receivable {
                Reference = "Reference-2",
                CurrencyCode = "USD",
                IssueDate = new DateTime(2020,10,24),
                OpeningValue = 724.40m,
                PaidValue = 634.31m,
                DueDate = new DateTime(2023, 12, 4),
                ClosedDate = new DateTime(2021 , 01 , 18),
                Cancelled = false,
                DebtorName = "Debtor-2",
                DebtorReference = "DebtorRef-2",
                DebtorAddress1 = "Address1-2",
                DebtorAddress2 = "Address2-2",
                DebtorTown = "Town-2",
                DebtorState = "State-2",
                DebtorZip = "Zip-2",
                DebtorCountryCode = "01",
                DebtorRegistrationNumber = "RegNo-2"
            },

            new Receivable {
                Reference = "Reference-3",
                CurrencyCode = "HKD",
                IssueDate = new DateTime(2020,10,24),
                OpeningValue = 724.40m,
                PaidValue = 724.40m,
                DueDate = new DateTime(2023, 11, 4),
                ClosedDate = new DateTime(2020, 11, 4),
                Cancelled = false,
                DebtorName = "Debtor-3",
                DebtorReference = "DebtorRef-3",
                DebtorAddress1 = "Address1-3",
                DebtorAddress2 = "Address2-3",
                DebtorTown = "Town-3",
                DebtorState = "State-3",
                DebtorZip = "Zip-3",
                DebtorCountryCode = "852",
                DebtorRegistrationNumber = "RegNo-3"
            },
             new Receivable {
                Reference = "Reference-4",
                CurrencyCode = "NOK",
                IssueDate = new DateTime(2020,10,24),
                OpeningValue = 724.40m,
                PaidValue = 634.31m,
                DueDate = new DateTime(2023, 12, 30),
                ClosedDate =null,
                Cancelled = true,
                DebtorName = "Debtor-4",
                DebtorReference = "DebtorRef-4",
                DebtorAddress1 = "Address1-4",
                DebtorAddress2 = "Address2-4",
                DebtorTown = "Town-4",
                DebtorState = "State-4",
                DebtorZip = "Zip-4",
                DebtorCountryCode = "47",
                DebtorRegistrationNumber = "RegNo-4"
            },
            new Receivable {
                Reference = "Reference-5",
                CurrencyCode = "CHF",
                IssueDate = new DateTime(2020,10,24),
                OpeningValue = 724.40m,
                PaidValue = 634.31m,
                DueDate = new DateTime(2024, 2, 2),
                ClosedDate =null,
                Cancelled = false,
                DebtorName = "Debtor-5",
                DebtorReference = "DebtorRef-5",
                DebtorAddress1 = "Address1-5",
                DebtorAddress2 = "Address2-5",
                DebtorTown = "Town-5",
                DebtorState = "State-5",
                DebtorZip = "Zip-5",
                DebtorCountryCode = "41",
                DebtorRegistrationNumber = "RegNo-5"
            },
             new Receivable {
                Reference = "Reference-6",
                CurrencyCode = "RUB",
                IssueDate = new DateTime(2020,10,24),
                OpeningValue = 724.40m,
                PaidValue = 634.31m,
                DueDate = new DateTime(2024, 5, 4),
                ClosedDate =null,
                Cancelled = false,
                DebtorName = "Debtor-6",
                DebtorReference = "DebtorRef-6",
                DebtorAddress1 = "Address1-6",
                DebtorAddress2 = "Address2-6",
                DebtorTown = "Town-6",
                DebtorState = "State-6",
                DebtorZip = "Zip-6",
                DebtorCountryCode = "07",
                DebtorRegistrationNumber = "RegNo-6"
            },
             new Receivable {
                Reference = "Reference-7",
                CurrencyCode = "GBP",
                IssueDate = new DateTime(2020,10,24),
                OpeningValue = 724.40m,
                PaidValue = 634.31m,
                DueDate = new DateTime(2024, 1, 4),
                ClosedDate =null,
                Cancelled = false,
                DebtorName = "Debtor-7",
                DebtorReference = "DebtorRef-7",
                DebtorAddress1 = "Address1-7",
                DebtorAddress2 = "Address2-7",
                DebtorTown = "Town-7",
                DebtorState = "State-7",
                DebtorZip = "Zip-7",
                DebtorCountryCode = "44",
                DebtorRegistrationNumber = "RegNo-7"
            },
             new Receivable {
                Reference = "Reference-8",
                CurrencyCode = "SGD",
                IssueDate = new DateTime(2020,10,24),
                OpeningValue = 724.40m,
                PaidValue = 634.31m,
                DueDate = new DateTime(2023, 12, 5),
                ClosedDate =null,
                Cancelled = false,
                DebtorName = "Debtor-8",
                DebtorReference = "DebtorRef-8",
                DebtorAddress1 = "Address1-8",
                DebtorAddress2 = "Address2-8",
                DebtorTown = "Town-8",
                DebtorState = "State-8",
                DebtorZip = "Zip-8",
                DebtorCountryCode = "65",
                DebtorRegistrationNumber = "RegNo-8"
            },
             new Receivable {
                Reference = "Reference-9",
                CurrencyCode = "JPY",
                IssueDate = new DateTime(2020,10,24),
                OpeningValue = 724.40m,
                PaidValue = 634.31m,
                DueDate = new DateTime(2023, 12, 2),
                 ClosedDate =null,
                Cancelled = false,
                DebtorName = "Debtor-9",
                DebtorReference = "DebtorRef-9",
                DebtorAddress1 = "Address1-9",
                DebtorAddress2 = "Address2-9",
                DebtorTown = "Town-9",
                DebtorState = "State-9",
                DebtorZip = "Zip-9",
                DebtorCountryCode = "81",
                DebtorRegistrationNumber = "RegNo-9"
            },
             new Receivable {
                Reference = "Reference-10",
                CurrencyCode = "SEK",
                IssueDate = new DateTime(2020,10,24),
                OpeningValue = 724.40m,
                PaidValue = 634.31m,
                DueDate = new DateTime(2023, 12, 4),
                ClosedDate = null,
                Cancelled = false,
                DebtorName = "Debtor-10",
                DebtorReference = "DebtorRef-10",
                DebtorAddress1 = "Address1-10",
                DebtorAddress2 = "Address2-10",
                DebtorTown = "Town-10",
                DebtorState = "State-10",
                DebtorZip = "Zip-10",
                DebtorCountryCode = "46",
                DebtorRegistrationNumber = "RegNo-10"
            },


        };

            
        

        _context.Receivables.AddRange(receivables) ;
        _context.SaveChanges();
    }
}
