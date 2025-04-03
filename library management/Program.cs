namespace library_management
{
class Book
    {
        public string title;
        public string author;
        public string isbn;
        public bool IsAvailable;

        public Book(string title, string author, string isbn)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            IsAvailable = true;

        }
    }
//-----------------------------------------------------------------
class Library
    { 
    public List<Book> books=new List<Book> ();

        //method to add new book
       //-------------------------------------------------------------------------
        public void AddNewBook (string title, string author, string isbn)
        {
          // Book NewBook = new Book (title, author, isbn);
            books.Add(new Book(title,author,isbn));
            Console.WriteLine($"the book:{title} Added success");
        }
        //-------------------------------------------------------------------------

        //method to search  book
        //-------------------------------------------------------------------------
        public void search(string text) 
        {
            bool found = false;
            for (int i = 0; i < books.Count; i++)
            {
                if(books[i].title == text || books[i].author==text)
                {
                    Console.WriteLine("The book is found and detils is : ");
                    Console.WriteLine($"title : {books[i].title}");
                    Console.WriteLine($"author : {books[i].author}");
                    Console.WriteLine($"isbn : {books[i].isbn}");
                    Console.WriteLine($"Available : {books[i].IsAvailable}");
                    found = true;

                }

            }
            if (!found)
            {
                Console.WriteLine("the book is not found ");
            }


        }
        //-------------------------------------------------------------------------
        //method BorrowBook 
        //-------------------------------------------------------------------------
        public void BorrowBook(string text)
        {
            for(int i= 0;i< books.Count; i++)
            {
                if (books[i].title == text || books[i].isbn==text)
                {
                    if (books[i].IsAvailable)
                    {
                        books[i].IsAvailable = false;
                        Console.WriteLine("The book has been successfully borrowed");
                    }
                    else
                    {
                        Console.WriteLine("The book is currently not available");
                    }
                    return;
                }


            }
            Console.WriteLine("The book's name or number was not found");
            

        }
        //-------------------------------------------------------------------------
        //method ReturnBook 
        //-------------------------------------------------------------------------
        public void ReturnBook(string text)
        {

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].isbn == text || books[i].title==text)
                {
                    if (!books[i].IsAvailable)
                    {
                        books[i].IsAvailable = true;
                        Console.WriteLine($"The book:{books[i].title} has been successfully returned");
                    }
                    else
                    {
                        Console.WriteLine("This book is already available");
                    }
                    return;
                }
            }

            Console.WriteLine("The book's name or number was not found");
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddNewBook("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565");
            library.AddNewBook("To Kill a Mockingbird", "Harper Lee", "9780061120084");
            library.AddNewBook("1984", "George Orwell", "9780451524935");
            Console.WriteLine("============================================================");

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.search("The Great Gatsby");
            Console.WriteLine("============================================================");

            library.BorrowBook("The Great Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library
            Console.WriteLine("============================================================");

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("The Great Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

            Console.ReadLine();

        }
    }
}
