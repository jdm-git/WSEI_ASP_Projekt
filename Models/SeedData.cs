using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.MembershipTypes.Any())
                {
                    Console.WriteLine("Database already seeded");
                    return;
                }

                context.MembershipTypes.AddRange(
                    new MembershipType
                    {
                        Id = 1,
                        SignUpFee = 0,
                        DurationInMonths = 0,
                        DiscountRate = 0
                    },
                    new MembershipType
                    {
                        Id = 2,
                        SignUpFee = 30,
                        DurationInMonths = 1,
                        DiscountRate = 10
                    },
                    new MembershipType
                    {
                        Id = 3,
                        SignUpFee = 90,
                        DurationInMonths = 3,
                        DiscountRate = 15
                    },
                    new MembershipType
                    {
                        Id = 4,
                        SignUpFee = 300,
                        DurationInMonths = 12,
                        DiscountRate = 20
                    });
                context.Rentals.AddRange(
                new Rental
                {
                    Customer = new Customer
                    {
                        Birthdate = DateTime.Now.AddYears(-10),
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 1,
                        Name = "customer1"
                    },
                    Book = new Book
                    {
                        AuthorName = "author1",
                        DateAdded = DateTime.Now.AddDays(-1),
                        GenreId = 1,
                        Name = "name1",
                        NumberAvailable = 10,
                        NumberInStock = 10,
                        ReleaseDate = DateTime.Now.AddDays(-2)
                    },
                    DateRented = DateTime.Now.AddDays(-1)
                },
                new Rental
                {
                    Customer = new Customer
                    {
                        Birthdate = DateTime.Now.AddYears(-10),
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 1,
                        Name = "customer2"
                    },
                    Book = new Book
                    {
                        AuthorName = "author2",
                        DateAdded = DateTime.Now.AddDays(-1),
                        GenreId = 2,
                        Name = "name2",
                        NumberAvailable = 10,
                        NumberInStock = 10,
                        ReleaseDate = DateTime.Now.AddDays(-2)
                    },
                    DateRented = DateTime.Now.AddDays(-1)
                },
                new Rental
                {
                    Customer = new Customer
                    {
                        Birthdate = DateTime.Now.AddYears(-10),
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 3,
                        Name = "customer3"
                    },
                    Book = new Book
                    {
                        AuthorName = "author3",
                        DateAdded = DateTime.Now.AddDays(-1),
                        GenreId = 3,
                        Name = "name3",
                        NumberAvailable = 10,
                        NumberInStock = 10,
                        ReleaseDate = DateTime.Now.AddDays(-2)
                    },
                    DateRented = DateTime.Now.AddDays(-1)
                }
                );
                context.SaveChanges();
            }
        }
    }
}