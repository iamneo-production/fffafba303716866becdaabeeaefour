using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domaindriven.Models;

namespace domaindriven
{
    public class ConsoleApp
    {
        private List<Movie> movies;

        public ConsoleApp()
        {
            movies = new List<Movie>();
        }

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. List Movies");
                Console.WriteLine("2. Find Movie");
                Console.WriteLine("3. Add Movie");
                Console.WriteLine("4. Edit Movie");
                Console.WriteLine("5. Delete Movie");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice (1-6): ");

                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        ListMovies();
                        break;
                    case '2':
                        FindMovie();
                        break;
                    case '3':
                        AddMovie();
                        break;
                    case '4':
                        EditMovie();
                        break;
                    case '5':
                        DeleteMovie();
                        break;
                    case '6':
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private void ListMovies()
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("No movies found.");
            }
            else
            {
                Console.WriteLine("Movies:");
                foreach (var movie in movies)
                {
                    Console.WriteLine($"Id: {movie.Id}, Name: {movie.Name}, Year: {movie.Year}, Rating: {movie.Rating}");
                }
            }
        }

        private void FindMovie()
        {
            Console.Write("Enter the Movie Id to find: ");
            int id = int.Parse(Console.ReadLine());

            var movie = movies.Find(m => m.Id == id);

            if (movie == null)
            {
                Console.WriteLine("Movie not found.");
            }
            else
            {
                Console.WriteLine($"Id: {movie.Id}, Name: {movie.Name}, Year: {movie.Year}, Rating: {movie.Rating}");
            }
        }

        private void AddMovie()
        {
            Console.Write("Enter Movie Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Movie Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter Movie Rating: ");
            double rating = double.Parse(Console.ReadLine());

            int newId = movies.Count > 0 ? movies[movies.Count - 1].Id + 1 : 1;

            Movie newMovie = new Movie
            {
                Id = newId,
                Name = name,
                Year = year,
                Rating = rating
            };

            movies.Add(newMovie);

            Console.WriteLine("Movie added successfully.");
        }

        private void EditMovie()
        {
            Console.Write("Enter the Movie Id to edit: ");
            int id = int.Parse(Console.ReadLine());

            var movie = movies.Find(m => m.Id == id);

            if (movie == null)
            {
                Console.WriteLine("Movie not found.");
            }
            else
            {
                Console.Write("Enter Movie Name: ");
                movie.Name = Console.ReadLine();

                Console.Write("Enter Movie Year: ");
                movie.Year = int.Parse(Console.ReadLine());

                Console.Write("Enter Movie Rating: ");
                movie.Rating = double.Parse(Console.ReadLine());

                Console.WriteLine("Movie edited successfully.");
            }
        }

        private void DeleteMovie()
        {
            Console.Write("Enter the Movie Id to delete: ");
            int id = int.Parse(Console.ReadLine());

            var movie = movies.Find(m => m.Id == id);

            if (movie == null)
            {
                Console.WriteLine("Movie not found.");
            }
            else
            {
                movies.Remove(movie);
                Console.WriteLine("Movie deleted successfully.");
            }
        }
    }
}
