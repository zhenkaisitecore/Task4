using System;
using System.Collections.Generic;
using System.Xml;

namespace Task4.Models
{
    public class BooksFactory
    {
        private delegate void CreateInstanceDelegate<T>(XmlNode node, ref List<T> target);

        private XmlNode _root = BookSingleton.GetInstance().Root;
        public List<Book> GetBooks() => Generator<Book>(_root.SelectNodes("Book"), CreateBookInstance);

        public List<string> GetAuthors() => Generator<string>(_root.SelectNodes("Book/Author"), CreateAuthorInstace);

        public List<Book> GetProgramming() => Generator<Book>(_root.SelectNodes("Book[Category='Programming']"), CreateBookInstance);
        public List<Book> GetLessThanTwenty() => Generator<Book>(_root.SelectNodes("Book[Price<20]"), CreateBookInstance);
        public Book GetBookById(int id)
        {
            XmlNode bookNode = _root.SelectSingleNode($"Book[Id={id}]");
            return CreateBook(bookNode);
        }

        private void CreateAuthorInstace(XmlNode node, ref List<string> target)
        {
            target.Add(node.InnerText);
        }

        private void CreateBookInstance(XmlNode node, ref List<Book> target)
        {
            target.Add(CreateBook(node));
        }

        private Book CreateBook(XmlNode node)
        {
            return new Book()
            {
                Id = Convert.ToInt32(node.SelectSingleNode("Id").InnerText),
                Title = node.SelectSingleNode("Title").InnerText,
                Author = node.SelectSingleNode("Author").InnerText,
                Category = node.SelectSingleNode("Category").InnerText,
                Price = Convert.ToDecimal(node.SelectSingleNode("Price").InnerText)
            };
        }

        
        private List<T> Generator<T>(XmlNodeList nodes, CreateInstanceDelegate<T> createInstance)
        {
            List<T> target = new List<T>();
            foreach (XmlNode node in nodes)
            {
                createInstance(node, ref target);
            }
            return target;
        }
    }
}