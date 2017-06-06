using Infnet.AspNet.Tp3.Entities;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Infnet.AspNet.Tp3.Presentation
{
    class Program
    {
        private static RestClient client = new RestClient("http://localhost:52078");

        private static void PopulateDb()
        {
            var authors = new List<Author>
            {
                new Author
                {
                    Name = "Someone",
                    LastName = "Test",
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Isbn = "lol wat",
                            Title = "The art of hue"
                        },
                        new Book
                        {
                            Isbn = "lol watsss",
                            Title = "The art of this"
                        }
                    }
                },
                new Author
                {
                    Name = "Some",
                    LastName = "Test Again",
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Isbn = "lol waterson",
                            Title = "The art of huezis"
                        },
                        new Book
                        {
                            Isbn = "lol watson",
                            Title = "The art of brs"
                        }
                    }
                }
            };

            foreach (var author in authors)
            {
                MakeRequest("api/authors", Method.POST, author);
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Inserting Data");
                PopulateDb();
                Console.WriteLine("Getting Data from Authors");
                MakeRequest("api/authors", Method.GET);
                Console.WriteLine("Getting Data from Books");
                MakeRequest("api/books", Method.GET);
                Console.WriteLine("Updating Data from Author");
                var authorToUpdate = new Author
                {
                    Name = "Oliveira",
                    LastName = "Quatro",
                    Id = 4
                };
                MakeRequest($"api/authors/{authorToUpdate.Id}", Method.PUT, authorToUpdate);
                Console.WriteLine("Updating Data from Book");
                var bookToUpdate = new Book
                {
                    Isbn = "WAT IS THIS",
                    Title = "Kill me",
                    Id = 2
                };
                MakeRequest($"api/books/{bookToUpdate.Id}", Method.PUT, bookToUpdate);
                Console.WriteLine("Deleting Data from Author");
                MakeRequest("api/authors/2", Method.DELETE);
                Console.WriteLine("Deleting Data from Book");
                MakeRequest("api/books/1", Method.DELETE);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static void MakeRequest(string uri, Method method, object body = null)
        {
            var request = new RestRequest(uri, Method.POST);
            request.AddHeader("Content-Type", "application/json");

            if (body != null) { request.AddJsonBody(body); }

            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
