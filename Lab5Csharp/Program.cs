using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Lab5Csharp
{
    class Program
    {
        interface PrintEdition<T>
        {
            string Title { get; set; }
            public int Pages { get; set; }
            public static void findByKeyWord(List<T> collection, String keyWord) { }

        }
            interface PrintEdition2
            {
                public void printInfo() { }
            }
        
            class Book : PrintEdition<Book>, PrintEdition2
            {
                public string Title { get; set; }

                private int pages;

                public int Pages
                {
                    get
                    {
                        return pages;
                    }
                    set
                    {
                        if (value > 0)
                        {
                            pages = value;
                        }
                    }
                }
                private string genre;

                void setGenre(string genre)
                {
                    this.genre = genre;
                }

                string getGenre()
                {
                    return genre;
                }

                public Book()
                {
                    Pages = 100;
                    Title = "Harry Potter";
                    this.genre = "Fantasy";
                }

                public Book(string title, int pages, string genre)
                {
                    Title = title;
                    Pages = pages;
                    this.genre = genre;
                }

                public void printInfo()
                {
                    Console.Write("Title: " + Title);
                    Console.Write("Colvo pages: " + pages);
                    Console.Write("Genre: " + genre);
                }

                public static List<Book> findByKeyWord(List<Book> collection, String keyWord)
                {
                    List<Book> ListWithKeyWord = new List<Book>();
                    foreach (Book element in collection)
                    {
                        if (keyWord == element.Title || keyWord == element.pages.ToString() || keyWord == element.getGenre())
                        {
                            ListWithKeyWord.Add(element);
                        }
                    }
                    return ListWithKeyWord;
                }

            }

            class Magazine : PrintEdition<Magazine>
            {
                public string Title { get; set; }
                private int pages;

                public int Pages
                {
                    get
                    {
                        return pages;
                    }
                    set
                    {
                        if (value > 0)
                        {
                            pages = value;
                        }
                    }
                }
                private string article;
                void setArticle(string article)
                {
                    this.article = article;
                }

                string getArticle()
                {
                    return article;
                }

                public Magazine()
                {
                    Title = "Readers Digest";
                    Pages = 100;
                    this.article = "Leonardo Dicaprio";
                }

                public Magazine(string title, int pages, string article)
                {
                    Title = title;
                    Pages = pages;
                    this.article = article;
                }

                public void printInfo()
                {
                    Console.Write("Title: " + Title);
                    Console.Write("Colvo pages: " + Pages);
                    Console.Write("Article: " + article);
                }

                public static List<Magazine> findByKeyWord(List<Magazine> collection, String keyWord)
                {
                    List<Magazine> ListWithKeyWord = new List<Magazine>();
                    foreach (Magazine element in collection)
                    {
                        if (keyWord == element.Title || keyWord == element.pages.ToString() || keyWord == element.article)
                        {
                            ListWithKeyWord.Add(element);
                        }
                    }
                    return ListWithKeyWord;
                }

            }

            class TextBook : PrintEdition<TextBook>
            {
                public string Title { get; set; }
                private int pages;
                public int Pages
                {
                    get
                    {
                        return pages;
                    }
                    set
                    {
                        if (value > 0)
                        {
                            pages = value;
                        }
                    }
                }
                private string discipline;
                void setDiscipline(string discipline)
                {
                    this.discipline = discipline;
                }

                string getDiscipline()
                {
                    return discipline;
                }

                public TextBook() : base()
                {
                    Title = "Default";
                    Pages = 150;
                    this.discipline = "Default";
                }

                public TextBook(string title, int pages, string discipline) : base()
                {
                    Title = title;
                    Pages = pages;
                    this.discipline = discipline;
                }

                public void printInfo()
                {
                    Console.Write("Title: " + Title);
                    Console.Write("Colvo pages: " + Pages);
                    Console.Write("Genre: " + discipline);
                }

                public static List<TextBook> findByKeyWord(List<TextBook> collection, String keyWord)
                {
                    List<TextBook> ListWithKeyWord = new List<TextBook>();
                    foreach (TextBook element in collection)
                    {
                        if (keyWord == element.Title || keyWord == element.pages.ToString() || keyWord == element.discipline)
                        {
                            ListWithKeyWord.Add(element);
                        }
                    }
                    return ListWithKeyWord;
                }

            }

            delegate List<Magazine> DelMagazine(List<Magazine> list, String str);
            delegate List<Book> DelBook(List<Book> list, String str);
            delegate List<TextBook> DelTextBook(List<TextBook> list, String str);

            static void Main(string[] args)
            {
                Magazine magazine = new Magazine();
                Magazine magazine1 = new Magazine("First", 100, "haha");
                Magazine magazine2 = new Magazine("Second", 150, "haha");
                List<Magazine> magazines = new List<Magazine>();
                magazines.Add(magazine1);
                magazines.Add(magazine2);
                Magazine.findByKeyWord(magazines, "First");
                DelMagazine delMagazine = Magazine.findByKeyWord;
                DelBook delBook = Book.findByKeyWord;
                DelTextBook delTextBook = TextBook.findByKeyWord;
                delMagazine(magazines, "First");
            }
        
    }
}