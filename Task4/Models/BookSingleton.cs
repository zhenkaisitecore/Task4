using System;
using System.Web;
using System.Xml;

namespace Task4.Models
{
    public class BookSingleton
    {
        private static readonly Lazy<BookSingleton> _lazy = new Lazy<BookSingleton>(() => new BookSingleton());
        public XmlNode Root { get; private set; }
        private BookSingleton()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(HttpContext.Current.Server.MapPath("~/Bookstore.xml"));
            Root = xmlDoc.DocumentElement;
        }

        public static BookSingleton GetInstance()
        {
            return _lazy.Value;
        }
    }
}