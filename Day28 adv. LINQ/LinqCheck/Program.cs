using LinqCheck.Model;

namespace LinqCheck
{
    internal class Program
    {
        void PrintSales()
        {
            var context = new pubsContext();
            var sales = context.Sales.GroupBy(s => s.TitleId, s => s, (titleId, sale) =>
                new
                {
                    Key = titleId,
                    Sales = sale.ToList()
                }
            ).ToList();
            
            foreach (var sale in sales)
            {
                Console.WriteLine("Title Id : " + sale.Key);
                sale.Sales.ForEach(sale1 =>
                    {
                        Console.WriteLine("Quantity : " + sale1.Qty);
                        Console.WriteLine("Order Id : " + sale1.OrdNum);
                        
                    }
                    );
            }
        }
        void PrintTheBooksPulisherwise()
        {
            pubsContext context = new pubsContext();
            var books = context.Titles
                .GroupBy(t => t.PubId, t => t, (pid, title) => new { Key = pid, TitleCount = title.Count(),TitleNames=title.ToList() });

            foreach (var book in books)
            {
                Console.Write(book.Key);
                Console.WriteLine(" - " + book.TitleCount);
                Console.WriteLine("BookNames");
                foreach (var title in book.TitleNames)
                {
                    Console.WriteLine(title.Title1);
                }
            }
        }        public void PrintBookByTypes(string type)
        {
            var context = new pubsContext();
            // var booksCount = context.Titles.Count(title => title.Type.Equals(type));
            var booksCount = context.Titles.Where(title => title.Type.Equals(type)).Count();
            Console.WriteLine($"Books count is {booksCount}");
            
        }
        public void PrintAuthors()
        {
            var context = new pubsContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.PrintAuthors();
            program.PrintBookByTypes("mod_cook");
            program.PrintTheBooksPulisherwise();
            program.PrintSales();
            Console.WriteLine("Hello, World!");
        }
    }
}
