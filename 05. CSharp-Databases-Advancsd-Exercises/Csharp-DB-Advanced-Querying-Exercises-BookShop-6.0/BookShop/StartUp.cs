namespace BookShop;

using BookShop.Models;
using BookShop.Models.Enums;
using Data;
using Initializer;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        DbInitializer.ResetDatabase(db);

    }

    // 02. Age Restriction
    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {

        try
        {
            AgeRestriction ageRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);

            var result = context.Books
                .Where(a => a.AgeRestriction == ageRestriction)
                .OrderBy(t => t.Title)
                .Select(t => t.Title)
                .ToList();


            return string.Join(Environment.NewLine, result);
        }
        catch (Exception)
        {

            return null;
        }
    }

    // 03. Golden Books
    public static string GetGoldenBooks(BookShopContext context)
    {
        var result = context.Books
            .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToList();

        return string.Join(Environment.NewLine, result);
    }

    // 04. Books by Price
    public static string GetBooksByPrice(BookShopContext context)
    {
        var result = context.Books
            .Where(b => b.Price > 40)
            .OrderByDescending(b => b.Price)
            .Select(b => $"{b.Title} - ${b.Price:f2}")
            .ToList();

        return string.Join(Environment.NewLine, result);
    }

    // 05. Not Released In
    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        var result = context.Books
            .Where(b => b.ReleaseDate.Value.Year != year && b.ReleaseDate != null)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToList();

        return string.Join(Environment.NewLine, result);
    }

    // 06. Book Titles by Category
    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        var inCategories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.ToLower())
            .ToList();

        var boockTitles = context.BooksCategories
            .Where(x => inCategories.Contains(x.Category.Name.ToLower()))
            .Select(x => x.Book.Title)
            .OrderBy(x => x)
            .ToList();

        return string.Join(Environment.NewLine, boockTitles);
    }

    // 07. Released Before Date
    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        var format = "dd-MM-yyyy";
        DateTime inputDate = DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);


        var result = context.Books
            .Where(x => x.ReleaseDate < inputDate)
            .OrderByDescending(x => x.ReleaseDate)
            .Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:f2}")
            .ToList();

        return string.Join(Environment.NewLine, result).Trim();
    }


    // 08. Author Search
    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        var result = context.Authors
            .Where(x => x.FirstName.EndsWith(input))
            .OrderBy(x => x.FirstName)
            .ThenBy(x => x.LastName)
            .Select(x => $"{x.FirstName} {x.LastName}")
            .ToList();

        return string.Join(Environment.NewLine, result);
    }

    // 09. Book Search
    public static string GetBookTitlesContaining(BookShopContext context, string input)
    {
        var result = context.Books
            .Where(x => x.Title.ToLower().Contains(input.ToLower()))
            .OrderBy(x => x.Title)
            .Select(x => x.Title)
            .ToList();

        return string.Join(Environment.NewLine, result);
    }

    // 10. Book Search by Author
    public static string GetBooksByAuthor(BookShopContext context, string input)
    {
        var result = context.Books
            .Where(x => x.Author.LastName
                          .ToLower()
                          .StartsWith(input.ToLower()))
            .OrderBy(x => x.BookId)
            .Select(x => $"{x.Title} ({x.Author.FirstName} {x.Author.LastName})")
            .ToList();


        return string.Join(Environment.NewLine, result);
    }


    // 11. Count Books
    public static int CountBooks(BookShopContext context, int lengthCheck)
    {

        return context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();
    }


    // 12. Total Book Copies
    public static string CountCopiesByAuthor(BookShopContext context)
    {
        var result = context.Authors
            .Select(x => new
            {
                Fulname = $"{x.FirstName} {x.LastName}",
                Count = x.Books.Sum(x => x.Copies),
            })
            .OrderByDescending(x => x.Count)
            .Select(x => $"{x.Fulname} - {x.Count}")
            .ToList();

        return string.Join(Environment.NewLine, result);
    }

    // 13. Profit by Category
    public static string GetTotalProfitByCategory(BookShopContext context)
    {

        var result = context.Categories
        .Select(g => new
        {
            g.Name,
            Profit = g.CategoryBooks.Sum(s => s.Book.Price * s.Book.Copies)
        })
        .OrderByDescending(x => x.Profit)
        .ThenBy(x => x.Name)
        .Select(x => $"{x.Name} ${x.Profit:f2}")
        .ToList();

        return string.Join(Environment.NewLine, result).Trim();
    }

    // 14. Most Recent Books
    public static string GetMostRecentBooks(BookShopContext context)
    {
        var sb = new StringBuilder();

        var result = context.Categories
            .Select(x => new
            {
                x.Name,
                topBoocks = x.CategoryBooks
                    .OrderByDescending(b => b.Book.ReleaseDate)
                    .Select(b => $"{b.Book.Title} ({b.Book.ReleaseDate.Value.Year})")
                    .Take(3)
                    .ToList()
            })
            .OrderBy(x => x.Name)
            .ToList();

        foreach (var c in result)
        {
            sb.AppendLine($"--{c.Name}");
            sb.AppendLine(string.Join(Environment.NewLine, c.topBoocks));
        }
        return sb.ToString().TrimEnd();
    }

    // 15. Increase Prices
    public static void IncreasePrices(BookShopContext context)
    {
        foreach (var c in context.Books)
        {
            c.Price += 5;
        }

        context.SaveChanges();

        //context.Database.ExecuteSqlRaw("UPDATE Books SET Price = Price + 5");
    }

    // 16. Remove Books
    public static int RemoveBooks(BookShopContext context)
    {
        var boocks = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();
        var number = boocks.Count();

        context.Books.RemoveRange(boocks);
        context.SaveChanges();

        return number;
    }

}


