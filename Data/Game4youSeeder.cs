using GAME4YOU.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GAME4YOU.Data
{
    public class Game4youSeeder
    {
        private readonly Game4youDbContext _dbContext;

        public Game4youSeeder(Game4youDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                // Upewnij się, że role istnieją w tabeli 'Roles'
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                // Upewnij się, że kategorie istnieją w tabeli 'Categories'
                if (!_dbContext.Categories.Any())
                {
                    var categories = GetCategories();
                    _dbContext.Categories.AddRange(categories);
                    _dbContext.SaveChanges();
                }

                // Upewnij się, że użytkownicy są w bazie
                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }

                // Teraz, gdy użytkownicy, role i kategorie są w bazie, możesz dodać produkty
                if (!_dbContext.Products.Any())
                {
                    var products = GetProducts();
                    _dbContext.Products.AddRange(products);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role { Name = "Admin" },
                new Role { Name = "User" }
            };
        }

        private IEnumerable<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Name = "Gra" },
                new Category { Name = "Karta podarunkowa" },
                new Category { Name = "Oprogramowanie" },
                new Category { Name = "Konto" },
                new Category { Name = "Subskrypcja" },
                new Category { Name = "Wszystkie kategorie" }
            };
        }

        private IEnumerable<Users> GetUsers()
        {
            return new List<Users>
            {
                new Users
                {
                    Email = "JanKowalski@game4you.com",
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    PasswordHash = "hashed_password1", // Upewnij się, że masz właściwy sposób hashowania haseł
                    RoleId = 2 // User
                },
                new Users
                {
                    Email = "AnnaNowak@game4you.com",
                    FirstName = "Anna",
                    LastName = "Nowak",
                    PasswordHash = "hashed_password2", // Hasło hashowane
                    RoleId = 2 // User
                }
            };
        }

        private IEnumerable<Product> GetProducts()
        {
            var users = _dbContext.Users.ToList(); // Pobieramy użytkowników z bazy danych
            var categories = _dbContext.Categories.ToList(); // Pobieramy kategorie z bazy danych

            return new List<Product>
            {
                new Product
                {
                    Name = "Sid Meier's Civilization VII (PC) - Steam Key - EUROPE",
                    Description = "Sid Meier's Civilization VII to długo oczekiwana siódma główna odsłona ukochanej serii Civilization oraz następca Civilization VI z 2016 roku. Ta niesamowita gra strategiczna została stworzona przez Firaxis Games i wydana przez 2K Games. Data premiery Civ 7 została ustalona na 11 lutego 2025 roku. Bądź pierwsi, którzy doświadczą tej wspaniałej produkcji i zdobądź swój klucz do Civilization 7 już teraz!",
                    Price = 14.99f,
                    Quantity = 1,
                    UserId = 1,
                    Balance = 100,
                    Key = "ZRA-22445-ASZ",
                    ImagePath = "/images/Cyvilization.jpg",
                    CategoryId = 1 
                },
                new Product
                {
                    Name = "Steam Gift Card 5 USD - Steam Key - For USD Currency Only",
                    Description = "Karty podarunkowe są łatwym sposobem doładowania twojego portfela Steam lub portfela innej osoby. Działają one w podobny sposób jak kupony upominkowe lub kody aktywacyjne do gier i mogą być świetnym prezentem dla Ciebie lub kogoś bliskiego. Zawarte w nich kwoty można wykorzystać na różnego rodzaju transakcje, takie jak zakup gier, dlc, aplikacji, programów i innych produktów ze Sklepu Steam.",
                    Price = 5f,
                    Quantity = 25,
                    UserId = 1,
                    Balance = 100,
                    Key = "GFF-76541-LUA",
                    ImagePath = "/images/SteamGift5.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    Name = "Microsoft Windows 10 Home - Microsoft Key - GLOBAL",
                    Description = "wersja Home systemu operacyjnego Windows 10.",
                    Price = 5.99f,
                    Quantity = 5,
                    UserId = 2, // Przypisanie sprzedawcy
                    Balance = 100,
                    Key = "GAM-12345-XYZ", // Klucz aktywacyjny
                    ImagePath = "/images/Windows10.jpg",
                    CategoryId = 3
                },
                new Product
                {
                    Name = "Xbox Game Pass Ultimate 1 Month Non-Stackable",
                    Description = "Karta podarunkowa z dostępem do Xbox Game Pass na 1 miesiąc.",
                    Price = 7.00f,
                    Quantity = 100,
                    UserId = 2, // Przypisanie sprzedawcy
                    Balance = 100,
                    Key = "GGG-17667-AHJ", 
                    ImagePath = "/images/XboxPass.jpg",
                    CategoryId = 5
                }
            };
        }
    }
}