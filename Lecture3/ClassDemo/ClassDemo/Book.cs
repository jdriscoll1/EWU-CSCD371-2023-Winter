using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    public record class Book
    {
        private string Title;
        private string Author;
        private string ISBN;

        public Book(string title, string author, string isbn)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
        }
    }
}
