using LinqCheck.Model;

namespace LinqCheck
{
    internal class Program
    {
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
            Console.WriteLine("Hello, World!");
        }
    }
}
