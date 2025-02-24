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
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Categories.Any())
                {
                    var categories = GetCategories();
                    _dbContext.Categories.AddRange(categories);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }

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
                    Password = "12345",
                    RoleId = 2 
                },
                new Users
                {
                    Email = "AnnaNowak@game4you.com",
                    FirstName = "Anna",
                    LastName = "Nowak",
                    Password = "12345", 
                    RoleId = 2 
                }
            };
        }

        private IEnumerable<Product> GetProducts()
        {
            var users = _dbContext.Users.ToList(); 
            var categories = _dbContext.Categories.ToList(); 

            return new List<Product>
            {
                new Product
                {
                    Name = "Sid Meier's Civilization VII (PC) - Klucz",
                    Description = "Sid Meier's Civilization VII to długo oczekiwana siódma główna odsłona ukochanej serii Civilization oraz następca Civilization VI z 2016 roku. Ta niesamowita gra strategiczna została stworzona przez Firaxis Games i wydana przez 2K Games. Data premiery Civ 7 została ustalona na 11 lutego 2025 roku. Bądź pierwsi, którzy doświadczą tej wspaniałej produkcji i zdobądź swój klucz do Civilization 7 już teraz!",
                    Price = 14.99f,
                    Quantity = 1,
                    UserId = 1,
                    Key = "ZRA-22445-ASZ",
                    ImagePath = "/images/Cyvilization.jpg",
                    CategoryId = 1
                },
                new Product
                {
                    Name = "The Witcher 4: A New Saga (PC) - Klucz",
                    Description = "The Witcher 4: A New Saga to długo oczekiwana kontynuacja serii Wiedźmin, opracowana przez CD Projekt Red. Ta epicka gra RPG przenosi graczy do nowego rozdziału w świecie Wiedźmina. Premiera została zaplanowana na 15 września 2025 roku. Zdobądź swoją kopię już teraz i wyrusz w niezapomnianą przygodę!",
                    Price = 49.99f,
                    Quantity = 5,
                    UserId = 2,
                    Key = "WCH-98765-PLR",
                    ImagePath = "/images/Witcher4.jpg",
                    CategoryId = 1
                },
                new Product
                {
                    Name = "Grand Theft Auto VI (PC) - Klucz",
                    Description = "Grand Theft Auto VI to najnowsza część kultowej serii gier akcji od Rockstar Games. Otwarty świat, niesamowita grafika i nowa fabuła sprawią, że GTA VI stanie się prawdziwym hitem. Premiera zaplanowana jest na 10 listopada 2025 roku. Zdobądź swoją kopię i wkrocz do świata pełnego akcji i przygód!",
                    Price = 59.99f,
                    Quantity = 3,
                    UserId = 1,
                    Key = "GTA-12345-VICE",
                    ImagePath = "/images/GTA6.jpg",
                    CategoryId = 1
                },
                 new Product
                {
                    Name = "CS2 (Steam) - Account",
                    Description = "Konto do gry Counter Strike 2. Zawiera rangę gold 3 oraz przegrane 800 godzin.",
                    Price = 17.95f,
                    Quantity = 1,
                    UserId = 1,
                    Key = "STM-19945-CS2",
                    ImagePath = "/images/CS2.jpg",
                    CategoryId = 4
                },
                new Product
                {
                    Name = "Steam Gift Card 5 USD",
                    Description = "Karty podarunkowe są łatwym sposobem doładowania twojego portfela Steam lub portfela innej osoby. Działają one w podobny sposób jak kupony upominkowe lub kody aktywacyjne do gier i mogą być świetnym prezentem dla Ciebie lub kogoś bliskiego. Zawarte w nich kwoty można wykorzystać na różnego rodzaju transakcje, takie jak zakup gier, dlc, aplikacji, programów i innych produktów ze Sklepu Steam.",
                    Price = 20.00f,
                    Quantity = 25,
                    UserId = 1,
                    Key = "GFA-76541-LUA",
                    ImagePath = "/images/SteamGift.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    Name = "Steam Gift Card 10 USD",
                    Description = "Karty podarunkowe są łatwym sposobem doładowania twojego portfela Steam lub portfela innej osoby. Działają one w podobny sposób jak kupony upominkowe lub kody aktywacyjne do gier i mogą być świetnym prezentem dla Ciebie lub kogoś bliskiego. Zawarte w nich kwoty można wykorzystać na różnego rodzaju transakcje, takie jak zakup gier, dlc, aplikacji, programów i innych produktów ze Sklepu Steam.",
                    Price = 40.00f,
                    Quantity = 25,
                    UserId = 1,
                    Key = "GFB-76541-LUA",
                    ImagePath = "/images/SteamGift.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    Name = "Steam Gift Card 15 USD",
                    Description = "Karty podarunkowe są łatwym sposobem doładowania twojego portfela Steam lub portfela innej osoby. Działają one w podobny sposób jak kupony upominkowe lub kody aktywacyjne do gier i mogą być świetnym prezentem dla Ciebie lub kogoś bliskiego. Zawarte w nich kwoty można wykorzystać na różnego rodzaju transakcje, takie jak zakup gier, dlc, aplikacji, programów i innych produktów ze Sklepu Steam.",
                    Price = 60.00f,
                    Quantity = 25,
                    UserId = 1,
                    Key = "GFC-76541-LUA",
                    ImagePath = "/images/SteamGift.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    Name = "Steam Gift Card 20 USD",
                    Description = "Karty podarunkowe są łatwym sposobem doładowania twojego portfela Steam lub portfela innej osoby. Działają one w podobny sposób jak kupony upominkowe lub kody aktywacyjne do gier i mogą być świetnym prezentem dla Ciebie lub kogoś bliskiego. Zawarte w nich kwoty można wykorzystać na różnego rodzaju transakcje, takie jak zakup gier, dlc, aplikacji, programów i innych produktów ze Sklepu Steam.",
                    Price = 80.00f,
                    Quantity = 25,
                    UserId = 1,
                    Key = "GFD-76541-LUA",
                    ImagePath = "/images/SteamGift.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    Name = "Steam Gift Card 25 USD",
                    Description = "Karty podarunkowe są łatwym sposobem doładowania twojego portfela Steam lub portfela innej osoby. Działają one w podobny sposób jak kupony upominkowe lub kody aktywacyjne do gier i mogą być świetnym prezentem dla Ciebie lub kogoś bliskiego. Zawarte w nich kwoty można wykorzystać na różnego rodzaju transakcje, takie jak zakup gier, dlc, aplikacji, programów i innych produktów ze Sklepu Steam.",
                    Price = 100.00f,
                    Quantity = 25,
                    UserId = 1,
                    Key = "GFE-76541-LUA",
                    ImagePath = "/images/SteamGift.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    Name = "Microsoft Windows 10 Home",
                    Description = "wersja Home systemu operacyjnego Windows 10.",
                    Price = 5.99f,
                    Quantity = 5,
                    UserId = 2,
                    Key = "GAF-12345-XYZ",
                    ImagePath = "/images/Windows10.jpg",
                    CategoryId = 3
                },
                new Product
                {
                    Name = "Microsoft Windows 11 Home",
                    Description = "wersja Home systemu operacyjnego Windows 11.",
                    Price = 13.99f,
                    Quantity = 5,
                    UserId = 2,
                    Key = "GAG-12345-XYZ",
                    ImagePath = "/images/Windows10.jpg",
                    CategoryId = 3
                },
                new Product
                {
                    Name = "Microsoft Windows 10 Pro",
                    Description = "wersja Home systemu operacyjnego Windows 10 pro.",
                    Price = 21.99f,
                    Quantity = 5,
                    UserId = 2,
                    Key = "GAH-12345-XYZ",
                    ImagePath = "/images/Windows10.jpg",
                    CategoryId = 3
                },
                new Product
                {
                    Name = "Microsoft Windows 11 Pro",
                    Description = "wersja Home systemu operacyjnego Windows 11 pro.",
                    Price = 35.99f,
                    Quantity = 5,
                    UserId = 2,
                    Key = "GAI-12345-XYZ",
                    ImagePath = "/images/Windows10.jpg",
                    CategoryId = 3
                },
                new Product
                {
                    Name = "Xbox Game Pass Ultimate 1 Month",
                    Description = "Karta podarunkowa z dostępem do Xbox Game Pass na 1 miesiąc.",
                    Price = 7.99f,
                    Quantity = 100,
                    UserId = 2,
                    Key = "GGJ-17667-AHJ",
                    ImagePath = "/images/XboxPass.jpg",
                    CategoryId = 5
                },
                  new Product
                {
                    Name = "Xbox Game Pass Ultimate 3 Month",
                    Description = "Karta podarunkowa z dostępem do Xbox Game Pass na 1 miesiąc.",
                    Price = 21.99f,
                    Quantity = 100,
                    UserId = 2,
                    Key = "GGK-17667-AHJ",
                    ImagePath = "/images/XboxPass.jpg",
                    CategoryId = 5
                },
                    new Product
                {
                    Name = "Xbox Game Pass Ultimate 6 Month",
                    Description = "Karta podarunkowa z dostępem do Xbox Game Pass na 1 miesiąc.",
                    Price = 42.99f,
                    Quantity = 100,
                    UserId = 2,
                    Key = "GGL-17667-AHJ",
                    ImagePath = "/images/XboxPass.jpg",
                    CategoryId = 5
                }
            };
        }
    }
}