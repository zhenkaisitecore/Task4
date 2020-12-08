using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task4.Models
{
    public class BookFactorySingleton
    {
        private static Lazy<BookFactorySingleton> _lazy = new Lazy<BookFactorySingleton>(() => new BookFactorySingleton());
        public BooksFactory BooksFactory { get; private set; }
        private BookFactorySingleton()
        {
            BooksFactory = new BooksFactory();
        }

        public static BookFactorySingleton GetInstance() => _lazy.Value;
    }
}