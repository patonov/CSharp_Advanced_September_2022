using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {
        private string title;
        private int year;
        private List<string> authors;

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList(); 
        }

        public string Title 
        { 
            get => this.title; 
            set
                { this.title = value; }
        }

        public int Year 
        { 
            get => this.year; 
            set { this.year = value; }
        }

        public List<string> Authors 
        {
            get => this.authors;
            set { this.authors = value; }
        }
    }
}
