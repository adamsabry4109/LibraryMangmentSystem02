namespace LibraryMangmentSystem02
{
    class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public string isbn { get; set; }
        public bool availability { get; set; }

        public Book(string title, string author, string isbn, bool availability = true)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.availability = availability;
        }
    }

    class Library
    {
        private List<Book> books = new List<Book>();
        //Add Book
        public void AddBooks(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Book '{book.title}' added");
        }

        //Search book

        public void SearchBook(string keyword)
        {
            bool found = false;
            for (int i = 0; i < books.Count; i++)
            {
                Book book = books[i];
                if (book.title == keyword || book.author == keyword)
                {
                    Console.WriteLine($"Found : '{books[i].title}'\nAuthor : '{books[i].author}' .");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No book found with that keyword.");
            }
        }

        //Borrow book

        public void BorrowBook(string title)
        {

            for (int i = 0; i < books.Count; i++)
            {
                Book book = books[i];
                if (book.title == title)
                {

                    if (book.availability)
                    {
                        book.availability = false;
                        Console.WriteLine($"You borrowed '{book.title}' .");
                    }
                    else
                    {
                        Console.WriteLine($" '{book.title}' is not avilable");
                    }
                    return;
                }
            }

            Console.WriteLine("Book not found");
            return;
        }

        // Return book
        public void ReturnBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                Book book = books[i];
                if (book.title == title)
                {
                    if (!book.availability)
                    {
                        book.availability = true;
                        Console.WriteLine($"You returned '{book.title}' .");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($" '{book.title}' was not borrowed");
                    }

                }
            }
            Console.WriteLine("Book not found");
            return;

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            Book b1 = new Book("Harry Potter", "J.K. Rowling", "123456");
            library.AddBooks(b1);


            library.SearchBook("Harry Potter");
            library.BorrowBook("Harry Potter");
            library.ReturnBook("Harry Potter");
            Console.WriteLine("--------------------------------");

            library.AddBooks(new Book("Algorithms", "John Doe", "67890"));
            Console.WriteLine("--------------------------------");

            library.SearchBook("John Doe");
            library.SearchBook("Python");
            Console.WriteLine("--------------------------------");


            library.BorrowBook("Algorithms");
            library.BorrowBook("Algorithms");
            Console.WriteLine("--------------------------------");

            library.ReturnBook("Algorithms");
            library.ReturnBook("Algorithms");

        }
    }
}
