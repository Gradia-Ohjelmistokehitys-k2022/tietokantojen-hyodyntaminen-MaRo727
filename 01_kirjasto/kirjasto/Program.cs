using kirjasto.models;

namespace kirjasto
{
    internal class Program
    {
        static void Main(string[] args)
        {

            LibraryContext db = new("Trusted_Connection=True;" +
                "server=(localdb)\\MSSQLLocalDB;" +
                "database=KirjastoDB;");
            

            Console.WriteLine(db.IsDbConnectionEstablished());
            foreach (var book in db.GetBooks())
            {
                Console.WriteLine(book.PublicationYear);
            }
            Console.WriteLine(db.AverageAge());
            Console.WriteLine(db.MostBooks());
            Console.WriteLine(db.IsDbConnectionEstablished());
               
            var loanedFirstNames = db.LoanedFirstNames();
            foreach (var firstname in loanedFirstNames)
            {
                Console.WriteLine(firstname);
            }

        }
    }
}
