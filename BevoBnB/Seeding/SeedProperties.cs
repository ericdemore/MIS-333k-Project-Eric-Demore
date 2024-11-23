
using BevoBnB.DAL;
using BevoBnB.Models;
using BevoBnB.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BevoBnB.Seeding
{

    public static class SeedProperties
    {
        public static void SeedAllProperties(AppDbContext db)
        {
            List<Property> AllProperties = new List<Property>();

            AllProperties.Add(new Property
            {
                PropertyNumber = 3001,
                LineAddress1 = "8714 Mann Plaza",
                City = "Lisaside",
                State = States.PA,
                ZipCode = "72227",
                Bedrooms = 5,
                Bathrooms = 6,
                GuestsAllowed = 9,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 152.68m,
                WeekendPricing = 171.57m,
                CleaningFee = 8.88m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "gonzalez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3002,
                LineAddress1 = "96593 White View Apt. 094",
                City = "Jonesberg",
                State = States.FL,
                ZipCode = "5565",
                Bedrooms = 7,
                Bathrooms = 8,
                GuestsAllowed = 8,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 120.81m,
                WeekendPricing = 148.15m,
                CleaningFee = 8.02m,
                DiscountRate = 0.14m,
                MinNightsforDiscount = 4,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "gonzalez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3003,
                LineAddress1 = "848 Melissa Springs Suite 947",
                City = "Kellerstad",
                State = States.MD,
                ZipCode = "80819",
                Bedrooms = 5,
                Bathrooms = 7,
                GuestsAllowed = 8,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 127.96m,
                WeekendPricing = 132.99m,
                CleaningFee = 13.37m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Unapproved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "rankin@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3004,
                LineAddress1 = "30413 Norton Isle Suite 012",
                City = "North Lisa",
                State = States.ND,
                ZipCode = "79428",
                Bedrooms = 1,
                Bathrooms = 3,
                GuestsAllowed = 14,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 80.20m,
                WeekendPricing = 185.35m,
                CleaningFee = 5.57m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "rankin@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3005,
                LineAddress1 = "39916 Mitchell Crescent",
                City = "New Andrewburgh",
                State = States.DE,
                ZipCode = "63315",
                Bedrooms = 2,
                Bathrooms = 3,
                GuestsAllowed = 12,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 170.25m,
                WeekendPricing = 100.37m,
                CleaningFee = 18.64m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3006,
                LineAddress1 = "086 Mary Cliff",
                City = "North Deborah",
                State = States.NE,
                ZipCode = "24135",
                Bedrooms = 7,
                Bathrooms = 9,
                GuestsAllowed = 2,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 220.24m,
                WeekendPricing = 162.60m,
                CleaningFee = 10.83m,
                DiscountRate = 0.24m,
                MinNightsforDiscount = 10,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3007,
                LineAddress1 = "91634 Strong Mountains Apt. 302",
                City = "West Alyssa",
                State = States.PA,
                ZipCode = "58475",
                Bedrooms = 1,
                Bathrooms = 2,
                GuestsAllowed = 9,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 213.37m,
                WeekendPricing = 204.87m,
                CleaningFee = 25.04m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3008,
                LineAddress1 = "6984 Price Shoals",
                City = "Erictown",
                State = States.WA,
                ZipCode = "10865",
                Bedrooms = 2,
                Bathrooms = 3,
                GuestsAllowed = 8,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 159.69m,
                WeekendPricing = 140.89m,
                CleaningFee = 27.13m,
                DiscountRate = 0.05m,
                MinNightsforDiscount = 7,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3009,
                LineAddress1 = "423 Bell Heights",
                City = "Brittanyberg",
                State = States.ME,
                ZipCode = "51359",
                Bedrooms = 3,
                Bathrooms = 3,
                GuestsAllowed = 4,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 200.73m,
                WeekendPricing = 295.39m,
                CleaningFee = 14.91m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime> { DateTime.Parse("2024-12-04"), DateTime.Parse("2024-12-05") }
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3010,
                LineAddress1 = "93523 Dana Lane",
                City = "Johnsonshire",
                State = States.WI,
                ZipCode = "87296",
                Bedrooms = 6,
                Bathrooms = 6,
                GuestsAllowed = 3,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 170.39m,
                WeekendPricing = 110.80m,
                CleaningFee = 8.67m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3011,
                LineAddress1 = "1427 Odonnell Rapids",
                City = "North Troyport",
                State = States.NH,
                ZipCode = "7035",
                Bedrooms = 3,
                Bathrooms = 3,
                GuestsAllowed = 14,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 217.15m,
                WeekendPricing = 126.29m,
                CleaningFee = 26.48m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3012,
                LineAddress1 = "81206 Stewart Forest Apt. 089",
                City = "East Davidborough",
                State = States.ME,
                ZipCode = "37198",
                Bedrooms = 3,
                Bathrooms = 5,
                GuestsAllowed = 8,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 205.21m,
                WeekendPricing = 293.26m,
                CleaningFee = 28.74m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "martinez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3013,
                LineAddress1 = "76104 Marsh Crescent",
                City = "Dennishaven",
                State = States.SD,
                ZipCode = "85034",
                Bedrooms = 7,
                Bathrooms = 7,
                GuestsAllowed = 4,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 123.13m,
                WeekendPricing = 126.99m,
                CleaningFee = 18.73m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3014,
                LineAddress1 = "0003 Grant Lakes",
                City = "Port Karafort",
                State = States.SD,
                ZipCode = "60619",
                Bedrooms = 3,
                Bathrooms = 5,
                GuestsAllowed = 14,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 89.19m,
                WeekendPricing = 188.81m,
                CleaningFee = 11.98m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Unapproved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3015,
                LineAddress1 = "236 Smith Drive Suite 555",
                City = "West Kimberlyton",
                State = States.KY,
                ZipCode = "21978",
                Bedrooms = 1,
                Bathrooms = 3,
                GuestsAllowed = 11,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 198.30m,
                WeekendPricing = 132.96m,
                CleaningFee = 13.96m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3016,
                LineAddress1 = "6824 Timothy Garden Apt. 428",
                City = "West Richardmouth",
                State = States.MT,
                ZipCode = "14742",
                Bedrooms = 6,
                Bathrooms = 6,
                GuestsAllowed = 10,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 181.50m,
                WeekendPricing = 297.31m,
                CleaningFee = 10.09m,
                DiscountRate = 0.13m,
                MinNightsforDiscount = 22,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "rankin@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3017,
                LineAddress1 = "5517 Holly Meadow Apt. 452",
                City = "Lake Anne",
                State = States.SC,
                ZipCode = "11894",
                Bedrooms = 1,
                Bathrooms = 3,
                GuestsAllowed = 1,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 134.09m,
                WeekendPricing = 139.22m,
                CleaningFee = 9.75m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "gonzalez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3018,
                LineAddress1 = "30601 Hawkins Highway",
                City = "Morashire",
                State = States.TX,
                ZipCode = "28976",
                Bedrooms = 6,
                Bathrooms = 5,
                GuestsAllowed = 9,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 187.65m,
                WeekendPricing = 160.61m,
                CleaningFee = 7.50m,
                DiscountRate = 0.11m,
                MinNightsforDiscount = 30,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "martinez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3019,
                LineAddress1 = "49263 Wilson View Apt. 873",
                City = "South Raymondborough",
                State = States.AZ,
                ZipCode = "28798",
                Bedrooms = 1,
                Bathrooms = 3,
                GuestsAllowed = 5,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 206.95m,
                WeekendPricing = 133.25m,
                CleaningFee = 14.04m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3020,
                LineAddress1 = "76582 Vanessa Oval",
                City = "New Richard",
                State = States.NE,
                ZipCode = "68819",
                Bedrooms = 5,
                Bathrooms = 4,
                GuestsAllowed = 12,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 99.54m,
                WeekendPricing = 242.89m,
                CleaningFee = 6.61m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3021,
                LineAddress1 = "7389 Alec Squares Suite 508",
                City = "Port Jonathan",
                State = States.FL,
                ZipCode = "50177",
                Bedrooms = 7,
                Bathrooms = 7,
                GuestsAllowed = 12,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 112.62m,
                WeekendPricing = 165.32m,
                CleaningFee = 24.26m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3022,
                LineAddress1 = "18013 Billy Bridge Suite 522",
                City = "Schmitthaven",
                State = States.NC,
                ZipCode = "66355",
                Bedrooms = 3,
                Bathrooms = 4,
                GuestsAllowed = 2,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 199.21m,
                WeekendPricing = 119.02m,
                CleaningFee = 11.63m,
                DiscountRate = 0.13m,
                MinNightsforDiscount = 21,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "martinez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3023,
                LineAddress1 = "891 Bullock Ford",
                City = "Amandachester",
                State = States.NJ,
                ZipCode = "51431",
                Bedrooms = 5,
                Bathrooms = 6,
                GuestsAllowed = 11,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 179.05m,
                WeekendPricing = 244.93m,
                CleaningFee = 21.78m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "gonzalez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3024,
                LineAddress1 = "02489 Cook Park",
                City = "Sherriport",
                State = States.MT,
                ZipCode = "50853",
                Bedrooms = 4,
                Bathrooms = 3,
                GuestsAllowed = 6,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 207.24m,
                WeekendPricing = 227.35m,
                CleaningFee = 5.50m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3025,
                LineAddress1 = "23450 Timothy Divide",
                City = "Wuland",
                State = States.UT,
                ZipCode = "20341",
                Bedrooms = 3,
                Bathrooms = 4,
                GuestsAllowed = 11,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 116.01m,
                WeekendPricing = 278.36m,
                CleaningFee = 24.73m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3026,
                LineAddress1 = "0976 Williams Mountains Apt. 009",
                City = "Lake Mario",
                State = States.OH,
                ZipCode = "85565",
                Bedrooms = 6,
                Bathrooms = 7,
                GuestsAllowed = 7,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 225.14m,
                WeekendPricing = 293.42m,
                CleaningFee = 10.42m,
                DiscountRate = 0.06m,
                MinNightsforDiscount = 28,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3027,
                LineAddress1 = "1097 Santos Springs Suite 264",
                City = "New Michelleborough",
                State = States.WY,
                ZipCode = "51884",
                Bedrooms = 2,
                Bathrooms = 2,
                GuestsAllowed = 4,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 70.24m,
                WeekendPricing = 126.45m,
                CleaningFee = 18.69m,
                DiscountRate = 0.08m,
                MinNightsforDiscount = 3,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3028,
                LineAddress1 = "5100 Scott Burg",
                City = "East Clayton",
                State = States.SC,
                ZipCode = "66353",
                Bedrooms = 4,
                Bathrooms = 3,
                GuestsAllowed = 3,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 186.38m,
                WeekendPricing = 224.07m,
                CleaningFee = 28.24m,
                DiscountRate = 0.06m,
                MinNightsforDiscount = 20,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "morales@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3029,
                LineAddress1 = "412 Snow Manors Apt. 161",
                City = "South Kimtown",
                State = States.NV,
                ZipCode = "57004",
                Bedrooms = 5,
                Bathrooms = 7,
                GuestsAllowed = 9,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 112.47m,
                WeekendPricing = 120.93m,
                CleaningFee = 23.28m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "morales@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3030,
                LineAddress1 = "5415 David Square",
                City = "West Michaeltown",
                State = States.IN,
                ZipCode = "48447",
                Bedrooms = 7,
                Bathrooms = 9,
                GuestsAllowed = 1,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 214.81m,
                WeekendPricing = 100.02m,
                CleaningFee = 17.78m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "gonzalez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3031,
                LineAddress1 = "03104 Norris Rapids",
                City = "Port Donald",
                State = States.DE,
                ZipCode = "62982",
                Bedrooms = 1,
                Bathrooms = 2,
                GuestsAllowed = 11,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 159.87m,
                WeekendPricing = 161.60m,
                CleaningFee = 10.34m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3032,
                LineAddress1 = "03557 Phillips Wells Suite 291",
                City = "New Beverlyburgh",
                State = States.FL,
                ZipCode = "16915",
                Bedrooms = 7,
                Bathrooms = 6,
                GuestsAllowed = 4,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 70.55m,
                WeekendPricing = 203.60m,
                CleaningFee = 5.09m,
                DiscountRate = 0.23m,
                MinNightsforDiscount = 30,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3033,
                LineAddress1 = "332 Watson Shore Apt. 290",
                City = "Millerland",
                State = States.MT,
                ZipCode = "39742",
                Bedrooms = 3,
                Bathrooms = 3,
                GuestsAllowed = 2,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 176.37m,
                WeekendPricing = 299.34m,
                CleaningFee = 17.38m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3034,
                LineAddress1 = "645 John Roads",
                City = "Danahaven",
                State = States.MS,
                ZipCode = "54060",
                Bedrooms = 7,
                Bathrooms = 6,
                GuestsAllowed = 14,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 172.83m,
                WeekendPricing = 229.98m,
                CleaningFee = 23.55m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "morales@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3035,
                LineAddress1 = "3547 Stephanie Underpass Apt. 418",
                City = "Port Jacqueline",
                State = States.HI,
                ZipCode = "55774",
                Bedrooms = 1,
                Bathrooms = 1,
                GuestsAllowed = 5,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 177.08m,
                WeekendPricing = 143.71m,
                CleaningFee = 19.21m,
                DiscountRate = 0.13m,
                MinNightsforDiscount = 42,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3036,
                LineAddress1 = "5825 Welch Corners",
                City = "Fischerport",
                State = States.UT,
                ZipCode = "59363",
                Bedrooms = 3,
                Bathrooms = 4,
                GuestsAllowed = 10,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 76.66m,
                WeekendPricing = 113.86m,
                CleaningFee = 27.87m,
                DiscountRate = 0.11m,
                MinNightsforDiscount = 7,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3037,
                LineAddress1 = "41489 Roger Terrace",
                City = "Davisfort",
                State = States.IN,
                ZipCode = "71770",
                Bedrooms = 6,
                Bathrooms = 8,
                GuestsAllowed = 6,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 177.37m,
                WeekendPricing = 299.09m,
                CleaningFee = 23.78m,
                DiscountRate = 0.09m,
                MinNightsforDiscount = 19,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3038,
                LineAddress1 = "014 Aaron Locks Suite 714",
                City = "Justinborough",
                State = States.CO,
                ZipCode = "5147",
                Bedrooms = 2,
                Bathrooms = 2,
                GuestsAllowed = 5,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 104.05m,
                WeekendPricing = 158.42m,
                CleaningFee = 5.36m,
                DiscountRate = 0.23m,
                MinNightsforDiscount = 30,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "rankin@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3039,
                LineAddress1 = "8518 Pamela Track Apt. 164",
                City = "Aprilshire",
                State = States.SC,
                ZipCode = "28062",
                Bedrooms = 3,
                Bathrooms = 2,
                GuestsAllowed = 1,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 199.37m,
                WeekendPricing = 210.59m,
                CleaningFee = 8.83m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3040,
                LineAddress1 = "864 Ramos Port Apt. 211",
                City = "Moralesmouth",
                State = States.OH,
                ZipCode = "88090",
                Bedrooms = 3,
                Bathrooms = 5,
                GuestsAllowed = 9,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 94.48m,
                WeekendPricing = 153.69m,
                CleaningFee = 16.85m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3041,
                LineAddress1 = "637 Neal Island Suite 074",
                City = "Lake Tyler",
                State = States.RI,
                ZipCode = "28775",
                Bedrooms = 3,
                Bathrooms = 3,
                GuestsAllowed = 14,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 88.82m,
                WeekendPricing = 196.14m,
                CleaningFee = 6.97m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3042,
                LineAddress1 = "0811 Smith Canyon Apt. 904",
                City = "Jessicabury",
                State = States.WV,
                ZipCode = "75585",
                Bedrooms = 3,
                Bathrooms = 5,
                GuestsAllowed = 2,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 119.58m,
                WeekendPricing = 123.22m,
                CleaningFee = 18.45m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "rankin@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3043,
                LineAddress1 = "7562 Fisher Spur",
                City = "Hernandezberg",
                State = States.MD,
                ZipCode = "17438",
                Bedrooms = 1,
                Bathrooms = 2,
                GuestsAllowed = 2,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 218.87m,
                WeekendPricing = 283.77m,
                CleaningFee = 19.07m,
                DiscountRate = 0.09m,
                MinNightsforDiscount = 4,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3044,
                LineAddress1 = "5667 Blair Underpass",
                City = "South Shelby",
                State = States.VT,
                ZipCode = "7027",
                Bedrooms = 2,
                Bathrooms = 4,
                GuestsAllowed = 13,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 76.19m,
                WeekendPricing = 239.76m,
                CleaningFee = 11.37m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "morales@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3045,
                LineAddress1 = "6708 Carpenter Overpass Suite 735",
                City = "Bobbyton",
                State = States.MI,
                ZipCode = "1008",
                Bedrooms = 7,
                Bathrooms = 7,
                GuestsAllowed = 7,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 161.17m,
                WeekendPricing = 229.04m,
                CleaningFee = 25.01m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3046,
                LineAddress1 = "16396 Shawn Junction",
                City = "New Nicolemouth",
                State = States.ND,
                ZipCode = "60236",
                Bedrooms = 4,
                Bathrooms = 4,
                GuestsAllowed = 6,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 106.06m,
                WeekendPricing = 220.69m,
                CleaningFee = 11.82m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3047,
                LineAddress1 = "4486 Olson Well",
                City = "North Kevin",
                State = States.CA,
                ZipCode = "1707",
                Bedrooms = 7,
                Bathrooms = 7,
                GuestsAllowed = 10,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 151.44m,
                WeekendPricing = 138.96m,
                CleaningFee = 6.72m,
                DiscountRate = 0.18m,
                MinNightsforDiscount = 2,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "martinez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3048,
                LineAddress1 = "67771 Christopher Courts Apt. 637",
                City = "Port Ronaldfurt",
                State = States.HI,
                ZipCode = "33233",
                Bedrooms = 5,
                Bathrooms = 5,
                GuestsAllowed = 2,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 102.43m,
                WeekendPricing = 134.28m,
                CleaningFee = 19.81m,
                DiscountRate = 0.15m,
                MinNightsforDiscount = 1,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3049,
                LineAddress1 = "5561 Bishop Turnpike",
                City = "Lake Kenneth",
                State = States.NY,
                ZipCode = "79756",
                Bedrooms = 5,
                Bathrooms = 7,
                GuestsAllowed = 11,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 94.31m,
                WeekendPricing = 259.87m,
                CleaningFee = 22.33m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "gonzalez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3050,
                LineAddress1 = "3019 Gerald Mall Apt. 340",
                City = "Trevinoville",
                State = States.SD,
                ZipCode = "36216",
                Bedrooms = 5,
                Bathrooms = 5,
                GuestsAllowed = 1,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 151.69m,
                WeekendPricing = 263.32m,
                CleaningFee = 13.27m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3051,
                LineAddress1 = "84331 Leonard Fort Suite 749",
                City = "East Lisa",
                State = States.NY,
                ZipCode = "43477",
                Bedrooms = 7,
                Bathrooms = 8,
                GuestsAllowed = 10,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 204.04m,
                WeekendPricing = 204.28m,
                CleaningFee = 11.07m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3052,
                LineAddress1 = "62281 Kathy Tunnel",
                City = "Hudsonborough",
                State = States.VA,
                ZipCode = "17819",
                Bedrooms = 1,
                Bathrooms = 1,
                GuestsAllowed = 9,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 165.51m,
                WeekendPricing = 224.19m,
                CleaningFee = 24.26m,
                DiscountRate = 0.12m,
                MinNightsforDiscount = 5,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3053,
                LineAddress1 = "9927 Christina Burg Suite 774",
                City = "East Angelaburgh",
                State = States.NM,
                ZipCode = "97149",
                Bedrooms = 7,
                Bathrooms = 9,
                GuestsAllowed = 6,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 106.87m,
                WeekendPricing = 121.74m,
                CleaningFee = 5.62m,
                DiscountRate = 0.06m,
                MinNightsforDiscount = 5,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3054,
                LineAddress1 = "142 Warner View Suite 460",
                City = "North Leslie",
                State = States.IA,
                ZipCode = "45480",
                Bedrooms = 5,
                Bathrooms = 7,
                GuestsAllowed = 9,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 212.32m,
                WeekendPricing = 148.76m,
                CleaningFee = 20.20m,
                DiscountRate = 0.12m,
                MinNightsforDiscount = 41,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3055,
                LineAddress1 = "5240 Berry Centers",
                City = "West Andrew",
                State = States.AR,
                ZipCode = "3720",
                Bedrooms = 7,
                Bathrooms = 6,
                GuestsAllowed = 12,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 164.02m,
                WeekendPricing = 111.01m,
                CleaningFee = 26.21m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Unapproved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "rankin@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3056,
                LineAddress1 = "51056 Patricia Forge",
                City = "Grahamstad",
                State = States.HI,
                ZipCode = "85576",
                Bedrooms = 7,
                Bathrooms = 9,
                GuestsAllowed = 10,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 117.45m,
                WeekendPricing = 167.53m,
                CleaningFee = 24.75m,
                DiscountRate = 0.17m,
                MinNightsforDiscount = 8,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3057,
                LineAddress1 = "0648 Malone Port Apt. 662",
                City = "New Devonhaven",
                State = States.VA,
                ZipCode = "92199",
                Bedrooms = 6,
                Bathrooms = 5,
                GuestsAllowed = 12,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 209.47m,
                WeekendPricing = 176.53m,
                CleaningFee = 5.83m,
                DiscountRate = 0.05m,
                MinNightsforDiscount = 3,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "gonzalez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3058,
                LineAddress1 = "23028 Jennifer Meadow Apt. 972",
                City = "West Matthewfurt",
                State = States.SC,
                ZipCode = "5261",
                Bedrooms = 1,
                Bathrooms = 2,
                GuestsAllowed = 14,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 153.04m,
                WeekendPricing = 199.10m,
                CleaningFee = 18.62m,
                DiscountRate = 0.13m,
                MinNightsforDiscount = 19,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3059,
                LineAddress1 = "2738 Martin Terrace Suite 547",
                City = "Smithhaven",
                State = States.LA,
                ZipCode = "72649",
                Bedrooms = 1,
                Bathrooms = 1,
                GuestsAllowed = 11,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 196.56m,
                WeekendPricing = 199.22m,
                CleaningFee = 20.71m,
                DiscountRate = 0.14m,
                MinNightsforDiscount = 4,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3060,
                LineAddress1 = "984 Stephen Stravenue",
                City = "South Michaelton",
                State = States.KY,
                ZipCode = "97488",
                Bedrooms = 4,
                Bathrooms = 6,
                GuestsAllowed = 3,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 117.03m,
                WeekendPricing = 178.29m,
                CleaningFee = 6.47m,
                DiscountRate = 0.05m,
                MinNightsforDiscount = 4,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3061,
                LineAddress1 = "98522 Mathis Viaduct Apt. 909",
                City = "West Michael",
                State = States.LA,
                ZipCode = "42837",
                Bedrooms = 4,
                Bathrooms = 4,
                GuestsAllowed = 1,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 133.35m,
                WeekendPricing = 252.79m,
                CleaningFee = 9.15m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3062,
                LineAddress1 = "620 Ashley Mills Apt. 507",
                City = "Julieborough",
                State = States.OH,
                ZipCode = "56059",
                Bedrooms = 1,
                Bathrooms = 3,
                GuestsAllowed = 9,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 171.15m,
                WeekendPricing = 296.05m,
                CleaningFee = 18.26m,
                DiscountRate = 0.21m,
                MinNightsforDiscount = 4,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3063,
                LineAddress1 = "212 Shelly Roads",
                City = "Fischerview",
                State = States.LA,
                ZipCode = "2288",
                Bedrooms = 5,
                Bathrooms = 7,
                GuestsAllowed = 10,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 132.81m,
                WeekendPricing = 163.88m,
                CleaningFee = 7.46m,
                DiscountRate = 0.17m,
                MinNightsforDiscount = 6,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3064,
                LineAddress1 = "8885 Lee Tunnel Suite 208",
                City = "Port Donna",
                State = States.OK,
                ZipCode = "50851",
                Bedrooms = 7,
                Bathrooms = 7,
                GuestsAllowed = 7,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 228.84m,
                WeekendPricing = 140.73m,
                CleaningFee = 17.13m,
                DiscountRate = 0.23m,
                MinNightsforDiscount = 22,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3065,
                LineAddress1 = "693 Michael Estate",
                City = "Lake Michael",
                State = States.NM,
                ZipCode = "3009",
                Bedrooms = 4,
                Bathrooms = 5,
                GuestsAllowed = 13,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 155.03m,
                WeekendPricing = 139.83m,
                CleaningFee = 21.05m,
                DiscountRate = 0.09m,
                MinNightsforDiscount = 21,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3066,
                LineAddress1 = "342 Miller Mission",
                City = "Lake Jennifer",
                State = States.NY,
                ZipCode = "92905",
                Bedrooms = 4,
                Bathrooms = 5,
                GuestsAllowed = 1,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 128.41m,
                WeekendPricing = 249.24m,
                CleaningFee = 6.63m,
                DiscountRate = 0.07m,
                MinNightsforDiscount = 8,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "martinez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3067,
                LineAddress1 = "71664 Kim Throughway",
                City = "Chelsealand",
                State = States.AK,
                ZipCode = "65056",
                Bedrooms = 6,
                Bathrooms = 8,
                GuestsAllowed = 9,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 163.68m,
                WeekendPricing = 286.53m,
                CleaningFee = 25.57m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "rankin@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3068,
                LineAddress1 = "66660 Gomez Port Apt. 945",
                City = "South Thomashaven",
                State = States.AZ,
                ZipCode = "11181",
                Bedrooms = 4,
                Bathrooms = 3,
                GuestsAllowed = 2,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 93.86m,
                WeekendPricing = 137.17m,
                CleaningFee = 28.18m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3069,
                LineAddress1 = "0131 Williams Ville Apt. 562",
                City = "Richardberg",
                State = States.FL,
                ZipCode = "53480",
                Bedrooms = 6,
                Bathrooms = 5,
                GuestsAllowed = 13,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 86.25m,
                WeekendPricing = 120.61m,
                CleaningFee = 11.39m,
                DiscountRate = 0.17m,
                MinNightsforDiscount = 10,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3070,
                LineAddress1 = "22708 Madison Spurs",
                City = "Herringstad",
                State = States.OR,
                ZipCode = "11353",
                Bedrooms = 6,
                Bathrooms = 7,
                GuestsAllowed = 2,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 182.46m,
                WeekendPricing = 241.25m,
                CleaningFee = 18.29m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "morales@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3071,
                LineAddress1 = "3454 Holmes Motorway",
                City = "Port Rachel",
                State = States.FL,
                ZipCode = "5560",
                Bedrooms = 3,
                Bathrooms = 3,
                GuestsAllowed = 1,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 89.88m,
                WeekendPricing = 123.04m,
                CleaningFee = 19.14m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3072,
                LineAddress1 = "805 James Turnpike",
                City = "Carrmouth",
                State = States.GA,
                ZipCode = "93500",
                Bedrooms = 6,
                Bathrooms = 5,
                GuestsAllowed = 12,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 81.55m,
                WeekendPricing = 219.86m,
                CleaningFee = 13.38m,
                DiscountRate = 0.22m,
                MinNightsforDiscount = 2,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "martinez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3073,
                LineAddress1 = "8081 Smith Trail",
                City = "North Ronaldstad",
                State = States.NV,
                ZipCode = "44515",
                Bedrooms = 7,
                Bathrooms = 7,
                GuestsAllowed = 3,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 130.47m,
                WeekendPricing = 196.09m,
                CleaningFee = 14.53m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3074,
                LineAddress1 = "125 Ian Crossroad Apt. 593",
                City = "South Deannaport",
                State = States.MS,
                ZipCode = "7347",
                Bedrooms = 2,
                Bathrooms = 1,
                GuestsAllowed = 4,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 148.10m,
                WeekendPricing = 136.82m,
                CleaningFee = 15.57m,
                DiscountRate = 0.22m,
                MinNightsforDiscount = 22,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "morales@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3075,
                LineAddress1 = "1607 Munoz River",
                City = "Emilyshire",
                State = States.NH,
                ZipCode = "54532",
                Bedrooms = 6,
                Bathrooms = 7,
                GuestsAllowed = 3,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 147.55m,
                WeekendPricing = 209.77m,
                CleaningFee = 27.65m,
                DiscountRate = 0.09m,
                MinNightsforDiscount = 6,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3076,
                LineAddress1 = "3615 David Keys Apt. 269",
                City = "West Stephenside",
                State = States.UT,
                ZipCode = "65516",
                Bedrooms = 2,
                Bathrooms = 4,
                GuestsAllowed = 3,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 86.80m,
                WeekendPricing = 126.47m,
                CleaningFee = 17.60m,
                DiscountRate = 0.06m,
                MinNightsforDiscount = 21,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "gonzalez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3077,
                LineAddress1 = "640 Mary Common",
                City = "Michaelville",
                State = States.AZ,
                ZipCode = "20721",
                Bedrooms = 3,
                Bathrooms = 4,
                GuestsAllowed = 7,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 121.75m,
                WeekendPricing = 173.01m,
                CleaningFee = 12.53m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3078,
                LineAddress1 = "395 Timothy Road",
                City = "Williamsbury",
                State = States.LA,
                ZipCode = "43567",
                Bedrooms = 5,
                Bathrooms = 7,
                GuestsAllowed = 5,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 160.23m,
                WeekendPricing = 198.10m,
                CleaningFee = 10.82m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3079,
                LineAddress1 = "3267 Walter Dam",
                City = "Cunninghamtown",
                State = States.OR,
                ZipCode = "1239",
                Bedrooms = 1,
                Bathrooms = 2,
                GuestsAllowed = 7,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 110.64m,
                WeekendPricing = 127.70m,
                CleaningFee = 26.67m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3080,
                LineAddress1 = "00580 Brandon Creek",
                City = "Port Eric",
                State = States.MS,
                ZipCode = "3966",
                Bedrooms = 3,
                Bathrooms = 5,
                GuestsAllowed = 2,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 227.60m,
                WeekendPricing = 236.71m,
                CleaningFee = 20.22m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3081,
                LineAddress1 = "325 Amanda Cliffs Apt. 695",
                City = "South Paulabury",
                State = States.MS,
                ZipCode = "29996",
                Bedrooms = 6,
                Bathrooms = 6,
                GuestsAllowed = 13,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 115.37m,
                WeekendPricing = 135.59m,
                CleaningFee = 29.80m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3082,
                LineAddress1 = "40956 Amanda Walk Apt. 260",
                City = "Simonfurt",
                State = States.CT,
                ZipCode = "93980",
                Bedrooms = 4,
                Bathrooms = 4,
                GuestsAllowed = 5,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 93.35m,
                WeekendPricing = 271.49m,
                CleaningFee = 8.54m,
                DiscountRate = 0.18m,
                MinNightsforDiscount = 6,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3083,
                LineAddress1 = "25762 Gill Creek Suite 525",
                City = "Mccoyton",
                State = States.KS,
                ZipCode = "23687",
                Bedrooms = 1,
                Bathrooms = 3,
                GuestsAllowed = 5,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 171.37m,
                WeekendPricing = 247.15m,
                CleaningFee = 17.22m,
                DiscountRate = 0.21m,
                MinNightsforDiscount = 8,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3084,
                LineAddress1 = "6048 Johnson Loop Suite 635",
                City = "East Daniel",
                State = States.GA,
                ZipCode = "4593",
                Bedrooms = 1,
                Bathrooms = 3,
                GuestsAllowed = 8,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 95.59m,
                WeekendPricing = 299.60m,
                CleaningFee = 24.30m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "rankin@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3085,
                LineAddress1 = "1168 Gary Fords Apt. 308",
                City = "Port Trevor",
                State = States.RI,
                ZipCode = "96954",
                Bedrooms = 1,
                Bathrooms = 2,
                GuestsAllowed = 11,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 194.84m,
                WeekendPricing = 278.17m,
                CleaningFee = 5.88m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "martinez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3086,
                LineAddress1 = "164 Matthew Parkway Suite 826",
                City = "Jimmyfurt",
                State = States.MS,
                ZipCode = "62271",
                Bedrooms = 6,
                Bathrooms = 8,
                GuestsAllowed = 8,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 112.03m,
                WeekendPricing = 100.08m,
                CleaningFee = 28.82m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3087,
                LineAddress1 = "1220 Heidi Rue Apt. 998",
                City = "West Haleyburgh",
                State = States.CO,
                ZipCode = "5222",
                Bedrooms = 5,
                Bathrooms = 4,
                GuestsAllowed = 1,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 127.97m,
                WeekendPricing = 182.77m,
                CleaningFee = 13.02m,
                DiscountRate = 0.17m,
                MinNightsforDiscount = 37,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3088,
                LineAddress1 = "751 Wood Square Suite 732",
                City = "Port Melissaburgh",
                State = States.SD,
                ZipCode = "22365",
                Bedrooms = 7,
                Bathrooms = 7,
                GuestsAllowed = 13,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 120.07m,
                WeekendPricing = 186.01m,
                CleaningFee = 26.71m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3089,
                LineAddress1 = "376 Smith Dale Suite 279",
                City = "South Sarahland",
                State = States.OR,
                ZipCode = "53609",
                Bedrooms = 2,
                Bathrooms = 2,
                GuestsAllowed = 9,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 137.96m,
                WeekendPricing = 122.31m,
                CleaningFee = 26.29m,
                DiscountRate = 0.10m,
                MinNightsforDiscount = 29,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3090,
                LineAddress1 = "79148 Pierce Lock Suite 423",
                City = "Erikberg",
                State = States.CA,
                ZipCode = "9478",
                Bedrooms = 3,
                Bathrooms = 5,
                GuestsAllowed = 6,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 226.57m,
                WeekendPricing = 234.61m,
                CleaningFee = 16.41m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3091,
                LineAddress1 = "147 Lisa Hill Apt. 512",
                City = "Port Elizabethshire",
                State = States.ID,
                ZipCode = "1425",
                Bedrooms = 4,
                Bathrooms = 6,
                GuestsAllowed = 10,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 95.73m,
                WeekendPricing = 145.15m,
                CleaningFee = 9.93m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "gonzalez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3092,
                LineAddress1 = "971 Hansen Well Suite 103",
                City = "South Mary",
                State = States.KY,
                ZipCode = "29941",
                Bedrooms = 6,
                Bathrooms = 8,
                GuestsAllowed = 4,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 161.68m,
                WeekendPricing = 145.72m,
                CleaningFee = 24.36m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "morales@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3093,
                LineAddress1 = "511 Berry Fork Suite 623",
                City = "Sharonfort",
                State = States.WY,
                ZipCode = "47577",
                Bedrooms = 4,
                Bathrooms = 5,
                GuestsAllowed = 3,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 183.81m,
                WeekendPricing = 260.18m,
                CleaningFee = 7.46m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Unapproved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "morales@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3094,
                LineAddress1 = "65873 Chen Knolls",
                City = "Ramirezfurt",
                State = States.WI,
                ZipCode = "94134",
                Bedrooms = 4,
                Bathrooms = 3,
                GuestsAllowed = 14,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 215.38m,
                WeekendPricing = 117.17m,
                CleaningFee = 24.31m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "morales@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3095,
                LineAddress1 = "8799 Emma Parkway Suite 735",
                City = "North Thomasfurt",
                State = States.IN,
                ZipCode = "57039",
                Bedrooms = 3,
                Bathrooms = 5,
                GuestsAllowed = 11,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 145.51m,
                WeekendPricing = 242.21m,
                CleaningFee = 11.89m,
                DiscountRate = 0.10m,
                MinNightsforDiscount = 41,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3096,
                LineAddress1 = "30068 David View Apt. 173",
                City = "New Peggychester",
                State = States.ND,
                ZipCode = "23718",
                Bedrooms = 4,
                Bathrooms = 6,
                GuestsAllowed = 7,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 142.76m,
                WeekendPricing = 161.21m,
                CleaningFee = 20.92m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "martinez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3097,
                LineAddress1 = "298 Johnathan Cove Apt. 402",
                City = "South Jamie",
                State = States.MD,
                ZipCode = "26932",
                Bedrooms = 6,
                Bathrooms = 7,
                GuestsAllowed = 13,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 170.07m,
                WeekendPricing = 176.37m,
                CleaningFee = 8.54m,
                DiscountRate = 0.09m,
                MinNightsforDiscount = 17,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3098,
                LineAddress1 = "171 Harrison Motorway",
                City = "Davidview",
                State = States.CO,
                ZipCode = "74554",
                Bedrooms = 6,
                Bathrooms = 8,
                GuestsAllowed = 10,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 145.08m,
                WeekendPricing = 234.81m,
                CleaningFee = 26.14m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3099,
                LineAddress1 = "3576 Sergio Avenue",
                City = "Benjaminmouth",
                State = States.NE,
                ZipCode = "32097",
                Bedrooms = 1,
                Bathrooms = 1,
                GuestsAllowed = 1,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 111.73m,
                WeekendPricing = 260.62m,
                CleaningFee = 15.89m,
                DiscountRate = 0.24m,
                MinNightsforDiscount = 9,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "morales@aol.com"),
                UnavailableDates = new List<DateTime> { DateTime.Parse("2024-12-29"), DateTime.Parse("2024-12-30"), DateTime.Parse("2024-12-31"), DateTime.Parse("2025-01-01") }
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3100,
                LineAddress1 = "37457 Tanya Pike Apt. 348",
                City = "North Ericton",
                State = States.RI,
                ZipCode = "21519",
                Bedrooms = 2,
                Bathrooms = 1,
                GuestsAllowed = 13,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 70.63m,
                WeekendPricing = 214.62m,
                CleaningFee = 5.29m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime> { DateTime.Parse("2024-12-31") }
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3101,
                LineAddress1 = "3673 Peter Turnpike Suite 835",
                City = "New Sandra",
                State = States.PA,
                ZipCode = "76875",
                Bedrooms = 4,
                Bathrooms = 4,
                GuestsAllowed = 6,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 229.03m,
                WeekendPricing = 172.79m,
                CleaningFee = 14.05m,
                DiscountRate = 0.14m,
                MinNightsforDiscount = 12,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3102,
                LineAddress1 = "939 Johnson Oval Suite 830",
                City = "North Dennismouth",
                State = States.TX,
                ZipCode = "80451",
                Bedrooms = 3,
                Bathrooms = 5,
                GuestsAllowed = 6,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 169.34m,
                WeekendPricing = 133.53m,
                CleaningFee = 18.06m,
                DiscountRate = 0.25m,
                MinNightsforDiscount = 28,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "gonzalez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3103,
                LineAddress1 = "645 Jennings Estates",
                City = "Angelastad",
                State = States.NV,
                ZipCode = "51726",
                Bedrooms = 2,
                Bathrooms = 3,
                GuestsAllowed = 4,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 155.52m,
                WeekendPricing = 109.44m,
                CleaningFee = 8.28m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3104,
                LineAddress1 = "1231 Stephanie Lock Suite 835",
                City = "North Richardland",
                State = States.MT,
                ZipCode = "77240",
                Bedrooms = 5,
                Bathrooms = 7,
                GuestsAllowed = 5,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 180.20m,
                WeekendPricing = 182.33m,
                CleaningFee = 17.78m,
                DiscountRate = 0.13m,
                MinNightsforDiscount = 13,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "martinez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3105,
                LineAddress1 = "302 Parker Plains Apt. 197",
                City = "East Robertstad",
                State = States.CO,
                ZipCode = "98152",
                Bedrooms = 3,
                Bathrooms = 2,
                GuestsAllowed = 1,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 212.86m,
                WeekendPricing = 212.70m,
                CleaningFee = 6.82m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "morales@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3106,
                LineAddress1 = "098 Hernandez Green",
                City = "New Sergiobury",
                State = States.MS,
                ZipCode = "98277",
                Bedrooms = 4,
                Bathrooms = 6,
                GuestsAllowed = 8,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 188.71m,
                WeekendPricing = 262.30m,
                CleaningFee = 21.88m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "morales@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3107,
                LineAddress1 = "94102 Sims Port Suite 187",
                City = "Florestown",
                State = States.NE,
                ZipCode = "80082",
                Bedrooms = 4,
                Bathrooms = 4,
                GuestsAllowed = 8,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 83.34m,
                WeekendPricing = 128.05m,
                CleaningFee = 11.29m,
                DiscountRate = 0.21m,
                MinNightsforDiscount = 8,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3108,
                LineAddress1 = "01630 Baker Crescent",
                City = "Kellyborough",
                State = States.ND,
                ZipCode = "71531",
                Bedrooms = 1,
                Bathrooms = 1,
                GuestsAllowed = 4,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 204.02m,
                WeekendPricing = 125.27m,
                CleaningFee = 21.15m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "gonzalez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3109,
                LineAddress1 = "70452 Forbes Courts",
                City = "Mosesland",
                State = States.OK,
                ZipCode = "14157",
                Bedrooms = 4,
                Bathrooms = 3,
                GuestsAllowed = 9,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 90.98m,
                WeekendPricing = 172.10m,
                CleaningFee = 18.09m,
                DiscountRate = 0.22m,
                MinNightsforDiscount = 11,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "morales@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3110,
                LineAddress1 = "0835 Angela Station",
                City = "East Heather",
                State = States.MO,
                ZipCode = "26899",
                Bedrooms = 5,
                Bathrooms = 7,
                GuestsAllowed = 9,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 158.64m,
                WeekendPricing = 299.91m,
                CleaningFee = 23.09m,
                DiscountRate = 0.12m,
                MinNightsforDiscount = 22,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3111,
                LineAddress1 = "2458 Jason Village Suite 248",
                City = "North Donnamouth",
                State = States.VT,
                ZipCode = "42872",
                Bedrooms = 2,
                Bathrooms = 4,
                GuestsAllowed = 4,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 107.97m,
                WeekendPricing = 189.30m,
                CleaningFee = 9.05m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3112,
                LineAddress1 = "1243 Grimes Corners",
                City = "Shawchester",
                State = States.CO,
                ZipCode = "78301",
                Bedrooms = 4,
                Bathrooms = 3,
                GuestsAllowed = 2,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 214.14m,
                WeekendPricing = 193.24m,
                CleaningFee = 26.10m,
                DiscountRate = 0.06m,
                MinNightsforDiscount = 21,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "martinez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3113,
                LineAddress1 = "558 Williams Station",
                City = "Port Pamela",
                State = States.DC,
                ZipCode = "34523",
                Bedrooms = 6,
                Bathrooms = 7,
                GuestsAllowed = 4,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 106.30m,
                WeekendPricing = 192.46m,
                CleaningFee = 17.59m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "rankin@yahoo.com"),
                UnavailableDates = new List<DateTime> { DateTime.Parse("2024-12-05"), DateTime.Parse("2024-12-06"), DateTime.Parse("2024-12-07") }
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3114,
                LineAddress1 = "4934 Lozano Place Suite 716",
                City = "Gavinton",
                State = States.VT,
                ZipCode = "63064",
                Bedrooms = 5,
                Bathrooms = 6,
                GuestsAllowed = 6,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 116.99m,
                WeekendPricing = 257.37m,
                CleaningFee = 5.63m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3115,
                LineAddress1 = "41227 Patricia Lake",
                City = "Martinezbury",
                State = States.LA,
                ZipCode = "35700",
                Bedrooms = 2,
                Bathrooms = 1,
                GuestsAllowed = 3,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 203.03m,
                WeekendPricing = 108.28m,
                CleaningFee = 11.35m,
                DiscountRate = 0.10m,
                MinNightsforDiscount = 4,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "gonzalez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3116,
                LineAddress1 = "028 Harris Drive Apt. 422",
                City = "Amyburgh",
                State = States.VA,
                ZipCode = "55206",
                Bedrooms = 2,
                Bathrooms = 2,
                GuestsAllowed = 14,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 163.30m,
                WeekendPricing = 262.77m,
                CleaningFee = 13.74m,
                DiscountRate = 0.16m,
                MinNightsforDiscount = 12,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "martinez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3117,
                LineAddress1 = "06268 Lewis Place Suite 121",
                City = "Port Patriciatown",
                State = States.IA,
                ZipCode = "98240",
                Bedrooms = 3,
                Bathrooms = 2,
                GuestsAllowed = 4,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 156.25m,
                WeekendPricing = 108.52m,
                CleaningFee = 23.66m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "gonzalez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3118,
                LineAddress1 = "5641 Brenda Streets Apt. 008",
                City = "Lake Seanmouth",
                State = States.WI,
                ZipCode = "87205",
                Bedrooms = 5,
                Bathrooms = 6,
                GuestsAllowed = 12,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 178.27m,
                WeekendPricing = 153.42m,
                CleaningFee = 24.69m,
                DiscountRate = 0.06m,
                MinNightsforDiscount = 23,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "rankin@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3119,
                LineAddress1 = "92555 Shaw Spurs Suite 207",
                City = "New Randy",
                State = States.ME,
                ZipCode = "58221",
                Bedrooms = 7,
                Bathrooms = 8,
                GuestsAllowed = 13,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 92.51m,
                WeekendPricing = 184.92m,
                CleaningFee = 12.82m,
                DiscountRate = 0.12m,
                MinNightsforDiscount = 3,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3120,
                LineAddress1 = "559 Foster Locks Suite 933",
                City = "Robinsonhaven",
                State = States.NY,
                ZipCode = "18885",
                Bedrooms = 6,
                Bathrooms = 6,
                GuestsAllowed = 6,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 224.62m,
                WeekendPricing = 225.85m,
                CleaningFee = 17.90m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3121,
                LineAddress1 = "4647 Kristine Fields Suite 710",
                City = "New Dakota",
                State = States.WY,
                ZipCode = "638",
                Bedrooms = 1,
                Bathrooms = 2,
                GuestsAllowed = 10,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 112.61m,
                WeekendPricing = 174.02m,
                CleaningFee = 17.48m,
                DiscountRate = 0.08m,
                MinNightsforDiscount = 5,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "morales@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3122,
                LineAddress1 = "92594 Emily Shoals",
                City = "North Cathyburgh",
                State = States.ME,
                ZipCode = "31451",
                Bedrooms = 6,
                Bathrooms = 5,
                GuestsAllowed = 1,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 189.98m,
                WeekendPricing = 119.06m,
                CleaningFee = 25.11m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "rankin@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3123,
                LineAddress1 = "551 Casey Squares Apt. 209",
                City = "Michaelborough",
                State = States.MS,
                ZipCode = "26297",
                Bedrooms = 1,
                Bathrooms = 1,
                GuestsAllowed = 6,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 72.03m,
                WeekendPricing = 114.73m,
                CleaningFee = 18.38m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "martinez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3124,
                LineAddress1 = "2998 Willis Wall",
                City = "North Brian",
                State = States.PA,
                ZipCode = "4610",
                Bedrooms = 3,
                Bathrooms = 4,
                GuestsAllowed = 3,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 216.21m,
                WeekendPricing = 144.51m,
                CleaningFee = 10.81m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3125,
                LineAddress1 = "164 Schultz Road",
                City = "Lake Bryan",
                State = States.MD,
                ZipCode = "86618",
                Bedrooms = 5,
                Bathrooms = 7,
                GuestsAllowed = 13,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 132.69m,
                WeekendPricing = 233.90m,
                CleaningFee = 15.80m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3126,
                LineAddress1 = "9541 Brock Estate Apt. 848",
                City = "Franklinchester",
                State = States.GA,
                ZipCode = "80124",
                Bedrooms = 2,
                Bathrooms = 1,
                GuestsAllowed = 9,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 220.97m,
                WeekendPricing = 285.05m,
                CleaningFee = 20.98m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3127,
                LineAddress1 = "588 Alan Rest",
                City = "Port Stephanieville",
                State = States.MS,
                ZipCode = "63590",
                Bedrooms = 6,
                Bathrooms = 6,
                GuestsAllowed = 12,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 224.98m,
                WeekendPricing = 180.86m,
                CleaningFee = 11.91m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3128,
                LineAddress1 = "216 Brandon Loop Apt. 096",
                City = "New Jessica",
                State = States.MT,
                ZipCode = "53548",
                Bedrooms = 5,
                Bathrooms = 7,
                GuestsAllowed = 12,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 221.98m,
                WeekendPricing = 239.97m,
                CleaningFee = 9.24m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3129,
                LineAddress1 = "782 Dawn Radial",
                City = "Port Christopher",
                State = States.LA,
                ZipCode = "35611",
                Bedrooms = 1,
                Bathrooms = 3,
                GuestsAllowed = 1,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 76.56m,
                WeekendPricing = 297.25m,
                CleaningFee = 20.42m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3130,
                LineAddress1 = "008 Nancy Route Suite 228",
                City = "North Stephanie",
                State = States.WA,
                ZipCode = "42879",
                Bedrooms = 2,
                Bathrooms = 3,
                GuestsAllowed = 3,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 128.71m,
                WeekendPricing = 129.36m,
                CleaningFee = 23.76m,
                DiscountRate = 0.08m,
                MinNightsforDiscount = 3,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "morales@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3131,
                LineAddress1 = "115 Jon Isle Suite 788",
                City = "North Lesliefurt",
                State = States.MO,
                ZipCode = "71569",
                Bedrooms = 1,
                Bathrooms = 2,
                GuestsAllowed = 9,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 114.21m,
                WeekendPricing = 210.63m,
                CleaningFee = 21.08m,
                DiscountRate = 0.21m,
                MinNightsforDiscount = 42,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3132,
                LineAddress1 = "132 Poole Pass Suite 212",
                City = "North Patrick",
                State = States.DE,
                ZipCode = "87566",
                Bedrooms = 5,
                Bathrooms = 6,
                GuestsAllowed = 11,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 146.82m,
                WeekendPricing = 280.37m,
                CleaningFee = 26.78m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3133,
                LineAddress1 = "457 Vargas Island Suite 853",
                City = "Lake Patrickstad",
                State = States.WY,
                ZipCode = "67652",
                Bedrooms = 4,
                Bathrooms = 3,
                GuestsAllowed = 1,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 134.72m,
                WeekendPricing = 249.39m,
                CleaningFee = 19.19m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3134,
                LineAddress1 = "1569 Amy Path",
                City = "North Ashleyton",
                State = States.HI,
                ZipCode = "45184",
                Bedrooms = 7,
                Bathrooms = 8,
                GuestsAllowed = 7,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 111.60m,
                WeekendPricing = 111.23m,
                CleaningFee = 13.48m,
                DiscountRate = 0.21m,
                MinNightsforDiscount = 5,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3135,
                LineAddress1 = "0375 Sandra Trace Suite 826",
                City = "Gailshire",
                State = States.IL,
                ZipCode = "4078",
                Bedrooms = 5,
                Bathrooms = 6,
                GuestsAllowed = 3,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 89.00m,
                WeekendPricing = 168.47m,
                CleaningFee = 14.93m,
                DiscountRate = 0.21m,
                MinNightsforDiscount = 36,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3136,
                LineAddress1 = "759 Good Port",
                City = "New Russell",
                State = States.MN,
                ZipCode = "50437",
                Bedrooms = 5,
                Bathrooms = 5,
                GuestsAllowed = 6,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 208.64m,
                WeekendPricing = 208.35m,
                CleaningFee = 7.09m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3137,
                LineAddress1 = "3895 Allen Junction",
                City = "West John",
                State = States.WV,
                ZipCode = "34147",
                Bedrooms = 5,
                Bathrooms = 7,
                GuestsAllowed = 3,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 172.51m,
                WeekendPricing = 195.41m,
                CleaningFee = 21.53m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3138,
                LineAddress1 = "7329 Jacobs Station",
                City = "New Tylerborough",
                State = States.MS,
                ZipCode = "36340",
                Bedrooms = 1,
                Bathrooms = 3,
                GuestsAllowed = 8,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 163.15m,
                WeekendPricing = 146.12m,
                CleaningFee = 18.98m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3139,
                LineAddress1 = "5003 Cassandra Estates Suite 148",
                City = "Haleychester",
                State = States.MD,
                ZipCode = "88806",
                Bedrooms = 7,
                Bathrooms = 7,
                GuestsAllowed = 9,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 81.50m,
                WeekendPricing = 161.49m,
                CleaningFee = 16.41m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3140,
                LineAddress1 = "10524 Parker Mall Suite 531",
                City = "Port Courtneyhaven",
                State = States.TN,
                ZipCode = "76853",
                Bedrooms = 5,
                Bathrooms = 7,
                GuestsAllowed = 13,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 177.94m,
                WeekendPricing = 120.73m,
                CleaningFee = 9.50m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Hotel"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3141,
                LineAddress1 = "300 Madison Stream",
                City = "Christophershire",
                State = States.MO,
                ZipCode = "93533",
                Bedrooms = 3,
                Bathrooms = 4,
                GuestsAllowed = 6,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 121.01m,
                WeekendPricing = 187.08m,
                CleaningFee = 16.48m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3142,
                LineAddress1 = "4229 Derrick Wells",
                City = "West Tyler",
                State = States.FL,
                ZipCode = "96763",
                Bedrooms = 2,
                Bathrooms = 4,
                GuestsAllowed = 6,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 199.68m,
                WeekendPricing = 241.45m,
                CleaningFee = 25.94m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "martinez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3143,
                LineAddress1 = "26239 Michael Shoals",
                City = "Gregoryview",
                State = States.VA,
                ZipCode = "92174",
                Bedrooms = 1,
                Bathrooms = 2,
                GuestsAllowed = 9,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 162.01m,
                WeekendPricing = 111.91m,
                CleaningFee = 14.35m,
                DiscountRate = 0.10m,
                MinNightsforDiscount = 29,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "morales@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3144,
                LineAddress1 = "302 Joy Spring Apt. 622",
                City = "Ryanhaven",
                State = States.IN,
                ZipCode = "88294",
                Bedrooms = 1,
                Bathrooms = 3,
                GuestsAllowed = 12,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 173.36m,
                WeekendPricing = 163.73m,
                CleaningFee = 25.35m,
                DiscountRate = 0.06m,
                MinNightsforDiscount = 32,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3145,
                LineAddress1 = "734 Craig Overpass Suite 589",
                City = "Jefferyside",
                State = States.CA,
                ZipCode = "23464",
                Bedrooms = 1,
                Bathrooms = 3,
                GuestsAllowed = 8,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 216.10m,
                WeekendPricing = 287.28m,
                CleaningFee = 22.20m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "martinez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3146,
                LineAddress1 = "272 Green Street",
                City = "Port Lacey",
                State = States.CA,
                ZipCode = "35243",
                Bedrooms = 4,
                Bathrooms = 3,
                GuestsAllowed = 7,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 211.51m,
                WeekendPricing = 247.34m,
                CleaningFee = 11.73m,
                DiscountRate = 0.13m,
                MinNightsforDiscount = 6,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "martinez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3147,
                LineAddress1 = "8056 Dunn Trail Apt. 049",
                City = "Blackshire",
                State = States.IL,
                ZipCode = "61935",
                Bedrooms = 5,
                Bathrooms = 6,
                GuestsAllowed = 2,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 111.40m,
                WeekendPricing = 189.08m,
                CleaningFee = 19.58m,
                DiscountRate = 0.07m,
                MinNightsforDiscount = 9,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3148,
                LineAddress1 = "86187 Antonio Fort",
                City = "North Carmen",
                State = States.CA,
                ZipCode = "72324",
                Bedrooms = 7,
                Bathrooms = 9,
                GuestsAllowed = 7,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 150.69m,
                WeekendPricing = 109.87m,
                CleaningFee = 13.30m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3149,
                LineAddress1 = "71318 Cassandra Plaza",
                City = "Burkeview",
                State = States.NJ,
                ZipCode = "84393",
                Bedrooms = 7,
                Bathrooms = 7,
                GuestsAllowed = 10,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 184.21m,
                WeekendPricing = 227.55m,
                CleaningFee = 19.52m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3150,
                LineAddress1 = "5303 Lewis Springs",
                City = "Port Adrian",
                State = States.NH,
                ZipCode = "62346",
                Bedrooms = 2,
                Bathrooms = 1,
                GuestsAllowed = 2,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 204.67m,
                WeekendPricing = 207.51m,
                CleaningFee = 26.36m,
                DiscountRate = 0.22m,
                MinNightsforDiscount = 44,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3151,
                LineAddress1 = "465 Wiley Corners Apt. 759",
                City = "East Michellechester",
                State = States.IA,
                ZipCode = "2837",
                Bedrooms = 6,
                Bathrooms = 5,
                GuestsAllowed = 11,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 129.14m,
                WeekendPricing = 213.84m,
                CleaningFee = 12.81m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "gonzalez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3152,
                LineAddress1 = "521 Flores Stream",
                City = "West Rebeccaborough",
                State = States.LA,
                ZipCode = "68847",
                Bedrooms = 3,
                Bathrooms = 5,
                GuestsAllowed = 3,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 77.06m,
                WeekendPricing = 254.37m,
                CleaningFee = 6.03m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "rankin@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3153,
                LineAddress1 = "0271 Soto Drives Apt. 975",
                City = "New Edgar",
                State = States.NE,
                ZipCode = "35218",
                Bedrooms = 4,
                Bathrooms = 5,
                GuestsAllowed = 9,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 179.91m,
                WeekendPricing = 233.17m,
                CleaningFee = 11.04m,
                DiscountRate = 0.18m,
                MinNightsforDiscount = 32,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3154,
                LineAddress1 = "27862 Kent Mountains",
                City = "Lake Michaelville",
                State = States.NM,
                ZipCode = "32697",
                Bedrooms = 6,
                Bathrooms = 5,
                GuestsAllowed = 14,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 90.54m,
                WeekendPricing = 153.38m,
                CleaningFee = 6.91m,
                DiscountRate = 0.18m,
                MinNightsforDiscount = 30,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3155,
                LineAddress1 = "917 Mclaughlin Glens",
                City = "Martinville",
                State = States.OR,
                ZipCode = "95889",
                Bedrooms = 7,
                Bathrooms = 6,
                GuestsAllowed = 2,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 225.59m,
                WeekendPricing = 226.89m,
                CleaningFee = 28.99m,
                DiscountRate = 0.12m,
                MinNightsforDiscount = 15,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "rankin@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3156,
                LineAddress1 = "3032 Michelle Drives",
                City = "North Daniel",
                State = States.KY,
                ZipCode = "82153",
                Bedrooms = 3,
                Bathrooms = 4,
                GuestsAllowed = 13,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 203.25m,
                WeekendPricing = 157.15m,
                CleaningFee = 15.68m,
                DiscountRate = 0.23m,
                MinNightsforDiscount = 9,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "rankin@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3157,
                LineAddress1 = "601 Maria Mission Apt. 554",
                City = "Myerstown",
                State = States.SD,
                ZipCode = "32202",
                Bedrooms = 7,
                Bathrooms = 9,
                GuestsAllowed = 9,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 223.27m,
                WeekendPricing = 269.55m,
                CleaningFee = 11.35m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3158,
                LineAddress1 = "238 Shawn Well",
                City = "Port Johnshire",
                State = States.OH,
                ZipCode = "17431",
                Bedrooms = 7,
                Bathrooms = 8,
                GuestsAllowed = 14,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 173.63m,
                WeekendPricing = 112.64m,
                CleaningFee = 6.38m,
                DiscountRate = 0.06m,
                MinNightsforDiscount = 13,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3159,
                LineAddress1 = "41743 Berger Inlet Apt. 527",
                City = "South Tammymouth",
                State = States.SC,
                ZipCode = "37901",
                Bedrooms = 7,
                Bathrooms = 9,
                GuestsAllowed = 9,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 176.23m,
                WeekendPricing = 163.20m,
                CleaningFee = 14.77m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3160,
                LineAddress1 = "9983 Mary Grove Apt. 643",
                City = "Beardview",
                State = States.MO,
                ZipCode = "17895",
                Bedrooms = 7,
                Bathrooms = 6,
                GuestsAllowed = 9,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 219.53m,
                WeekendPricing = 209.33m,
                CleaningFee = 24.51m,
                DiscountRate = 0.10m,
                MinNightsforDiscount = 16,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3161,
                LineAddress1 = "03541 Ryan Islands Apt. 562",
                City = "East Michaelfort",
                State = States.HI,
                ZipCode = "90576",
                Bedrooms = 1,
                Bathrooms = 2,
                GuestsAllowed = 10,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 126.25m,
                WeekendPricing = 269.63m,
                CleaningFee = 8.27m,
                DiscountRate = 0.16m,
                MinNightsforDiscount = 8,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3162,
                LineAddress1 = "6591 Angela Mission Apt. 108",
                City = "Penabury",
                State = States.SC,
                ZipCode = "94980",
                Bedrooms = 5,
                Bathrooms = 6,
                GuestsAllowed = 14,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 143.98m,
                WeekendPricing = 286.86m,
                CleaningFee = 20.48m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3163,
                LineAddress1 = "492 Ramirez Crossing",
                City = "Aaronberg",
                State = States.CO,
                ZipCode = "44974",
                Bedrooms = 1,
                Bathrooms = 2,
                GuestsAllowed = 10,
                PetsAllowed = false,
                FreeParking = true,
                WeekdayPricing = 121.91m,
                WeekendPricing = 144.60m,
                CleaningFee = 10.12m,
                DiscountRate = 0.22m,
                MinNightsforDiscount = 8,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3164,
                LineAddress1 = "35974 Sharon Locks Apt. 101",
                City = "Jennyport",
                State = States.DE,
                ZipCode = "66170",
                Bedrooms = 7,
                Bathrooms = 9,
                GuestsAllowed = 1,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 137.80m,
                WeekendPricing = 114.46m,
                CleaningFee = 17.74m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "martinez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3165,
                LineAddress1 = "89403 Gabriella Mills",
                City = "East Steven",
                State = States.UT,
                ZipCode = "22495",
                Bedrooms = 3,
                Bathrooms = 4,
                GuestsAllowed = 11,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 128.63m,
                WeekendPricing = 155.10m,
                CleaningFee = 23.05m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "gonzalez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3166,
                LineAddress1 = "601 Kyle Roads",
                City = "Clarkfurt",
                State = States.NH,
                ZipCode = "85059",
                Bedrooms = 4,
                Bathrooms = 5,
                GuestsAllowed = 4,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 209.11m,
                WeekendPricing = 284.39m,
                CleaningFee = 6.25m,
                DiscountRate = 0.14m,
                MinNightsforDiscount = 6,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3167,
                LineAddress1 = "60969 Justin Passage Suite 774",
                City = "Joshuaburgh",
                State = States.IN,
                ZipCode = "61092",
                Bedrooms = 1,
                Bathrooms = 1,
                GuestsAllowed = 7,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 128.59m,
                WeekendPricing = 121.00m,
                CleaningFee = 19.36m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3168,
                LineAddress1 = "7943 Tina Mount",
                City = "East Lisa",
                State = States.PA,
                ZipCode = "43986",
                Bedrooms = 4,
                Bathrooms = 3,
                GuestsAllowed = 14,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 122.88m,
                WeekendPricing = 104.47m,
                CleaningFee = 25.31m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "gonzalez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3169,
                LineAddress1 = "6775 James Ford",
                City = "South Victorialand",
                State = States.NC,
                ZipCode = "91397",
                Bedrooms = 1,
                Bathrooms = 3,
                GuestsAllowed = 9,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 211.24m,
                WeekendPricing = 275.50m,
                CleaningFee = 15.74m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3170,
                LineAddress1 = "431 Johnson Neck Suite 039",
                City = "Mariechester",
                State = States.VT,
                ZipCode = "67849",
                Bedrooms = 1,
                Bathrooms = 1,
                GuestsAllowed = 9,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 124.65m,
                WeekendPricing = 126.24m,
                CleaningFee = 24.30m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "rice@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3171,
                LineAddress1 = "15666 Justin Locks",
                City = "Lake Ryanport",
                State = States.NM,
                ZipCode = "20687",
                Bedrooms = 6,
                Bathrooms = 6,
                GuestsAllowed = 3,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 70.11m,
                WeekendPricing = 112.05m,
                CleaningFee = 27.45m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3172,
                LineAddress1 = "9947 Torres Viaduct Apt. 506",
                City = "Benjaminport",
                State = States.TX,
                ZipCode = "30222",
                Bedrooms = 1,
                Bathrooms = 2,
                GuestsAllowed = 11,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 174.87m,
                WeekendPricing = 152.09m,
                CleaningFee = 18.44m,
                DiscountRate = 0.08m,
                MinNightsforDiscount = 8,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Apartment"),
                User = db.Users.FirstOrDefault(u => u.Email == "ingram@gmail.com"),
                UnavailableDates = new List<DateTime> { DateTime.Parse("2024-12-30"), DateTime.Parse("2024-12-31"), DateTime.Parse("2025-01-01") }
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3173,
                LineAddress1 = "20866 Keith Mill",
                City = "Susanton",
                State = States.NJ,
                ZipCode = "21190",
                Bedrooms = 2,
                Bathrooms = 4,
                GuestsAllowed = 10,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 96.80m,
                WeekendPricing = 174.06m,
                CleaningFee = 28.15m,
                DiscountRate = 0.10m,
                MinNightsforDiscount = 21,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3174,
                LineAddress1 = "04374 Nicholas Cliff Suite 001",
                City = "Adrianport",
                State = States.AL,
                ZipCode = "4838",
                Bedrooms = 1,
                Bathrooms = 1,
                GuestsAllowed = 10,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 205.01m,
                WeekendPricing = 108.24m,
                CleaningFee = 6.56m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Condo"),
                User = db.Users.FirstOrDefault(u => u.Email == "jacobs@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3175,
                LineAddress1 = "271 Andrew Summit",
                City = "Port Craig",
                State = States.CA,
                ZipCode = "80130",
                Bedrooms = 7,
                Bathrooms = 6,
                GuestsAllowed = 7,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 197.52m,
                WeekendPricing = 148.39m,
                CleaningFee = 20.55m,
                DiscountRate = 0.14m,
                MinNightsforDiscount = 27,
                PropertyStatus = PropertyStatus.Unapproved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "gonzalez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3176,
                LineAddress1 = "17611 Robbins Mission",
                City = "New Curtis",
                State = States.MN,
                ZipCode = "96166",
                Bedrooms = 3,
                Bathrooms = 3,
                GuestsAllowed = 9,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 219.69m,
                WeekendPricing = 286.13m,
                CleaningFee = 10.64m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3177,
                LineAddress1 = "80831 Kemp Pines",
                City = "Annashire",
                State = States.MO,
                ZipCode = "40702",
                Bedrooms = 1,
                Bathrooms = 2,
                GuestsAllowed = 7,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 91.26m,
                WeekendPricing = 123.93m,
                CleaningFee = 19.36m,
                DiscountRate = 0.23m,
                MinNightsforDiscount = 19,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3178,
                LineAddress1 = "96545 Smith Alley",
                City = "West Joy",
                State = States.IL,
                ZipCode = "86023",
                Bedrooms = 6,
                Bathrooms = 8,
                GuestsAllowed = 7,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 132.54m,
                WeekendPricing = 254.38m,
                CleaningFee = 14.83m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "martinez@aol.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3179,
                LineAddress1 = "6146 Johnson Isle",
                City = "South Arthur",
                State = States.MT,
                ZipCode = "70897",
                Bedrooms = 2,
                Bathrooms = 4,
                GuestsAllowed = 1,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 227.96m,
                WeekendPricing = 228.04m,
                CleaningFee = 6.99m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3180,
                LineAddress1 = "0415 Smith Springs",
                City = "Jeremyburgh",
                State = States.MN,
                ZipCode = "69154",
                Bedrooms = 4,
                Bathrooms = 4,
                GuestsAllowed = 3,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 140.93m,
                WeekendPricing = 228.81m,
                CleaningFee = 29.74m,
                DiscountRate = 0.15m,
                MinNightsforDiscount = 21,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "loter@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3181,
                LineAddress1 = "3999 Ricky Via",
                City = "West Adamburgh",
                State = States.HI,
                ZipCode = "53524",
                Bedrooms = 7,
                Bathrooms = 6,
                GuestsAllowed = 6,
                PetsAllowed = true,
                FreeParking = true,
                WeekdayPricing = 137.35m,
                WeekendPricing = 255.43m,
                CleaningFee = 16.62m,
                DiscountRate = 0.14m,
                MinNightsforDiscount = 21,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "House"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3182,
                LineAddress1 = "83787 Stuart Key",
                City = "Davetown",
                State = States.MN,
                ZipCode = "24886",
                Bedrooms = 7,
                Bathrooms = 6,
                GuestsAllowed = 4,
                PetsAllowed = true,
                FreeParking = false,
                WeekdayPricing = 172.99m,
                WeekendPricing = 146.75m,
                CleaningFee = 26.24m,
                DiscountRate = 0.23m,
                MinNightsforDiscount = 6,
                PropertyStatus = PropertyStatus.Unapproved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "chung@yahoo.com"),
                UnavailableDates = new List<DateTime>()
            });

            AllProperties.Add(new Property
            {
                PropertyNumber = 3183,
                LineAddress1 = "690 Christina Park",
                City = "Toddburgh",
                State = States.TX,
                ZipCode = "56713",
                Bedrooms = 3,
                Bathrooms = 5,
                GuestsAllowed = 1,
                PetsAllowed = false,
                FreeParking = false,
                WeekdayPricing = 188.53m,
                WeekendPricing = 157.96m,
                CleaningFee = 6.69m,
                DiscountRate = 0.00m,
                MinNightsforDiscount = 0,
                PropertyStatus = PropertyStatus.Approved,
                Category = db.Categories.FirstOrDefault(c => c.CategoryName == "Cabin"),
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@utexas.edu"),
                UnavailableDates = new List<DateTime>()
            });

            // Save each property to the database
            foreach (Property seedProperty in AllProperties)
            {
                Property dbProperty = db.Properties.FirstOrDefault(p => 
                    p.PropertyNumber == seedProperty.PropertyNumber);
                
                if (dbProperty == null)
                {
                    db.Properties.Add(seedProperty);
                    db.SaveChanges();
                }
            }
        }
    }
}
