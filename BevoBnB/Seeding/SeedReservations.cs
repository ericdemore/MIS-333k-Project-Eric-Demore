using BevoBnB.DAL;
using BevoBnB.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BevoBnB.Seeding
{
    public static class SeedReservations
    {
        public static async Task SeedAllReservations(AppDbContext context)
        {
            // Check if reservations already exist
            if (await context.Reservations.AnyAsync())
            {
                throw new Exception("Reservations have already been seeded.");
            }

            // Create the list of reservations
            List<Reservation> Reservations = new List<Reservation>
            {
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 1),
                    CheckOut = new DateTime(2024, 11, 3),
                    NumOfGuests = 1,
                    WeekdayPrice = 134.72m,
                    WeekendPrice = 249.39m,
                    DiscountRate = 0.00m,
                    CleaningFee = 19.19m,
                    Tax = 28.23m,
                    ConfirmationNumber = 21900,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "sheff44@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3133)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 4),
                    CheckOut = new DateTime(2024, 11, 6),
                    NumOfGuests = 2,
                    WeekdayPrice = 204.67m,
                    WeekendPrice = 207.51m,
                    DiscountRate = 0.22m,
                    CleaningFee = 26.36m,
                    Tax = 30.50m,
                    ConfirmationNumber = 21901,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "luce_chuck@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3150)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 6),
                    CheckOut = new DateTime(2024, 11, 10),
                    NumOfGuests = 14,
                    WeekdayPrice = 163.30m,
                    WeekendPrice = 262.77m,
                    DiscountRate = 0.16m,
                    CleaningFee = 13.74m,
                    Tax = 65.08m,
                    ConfirmationNumber = 21901,
                    ReservationStatus = ReservationStatus.Cancelled,
                    User = context.Users.FirstOrDefault(u => u.Email == "luce_chuck@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3116)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 7),
                    CheckOut = new DateTime(2024, 11, 12),
                    NumOfGuests = 1,
                    WeekdayPrice = 134.72m,
                    WeekendPrice = 249.39m,
                    DiscountRate = 0.00m,
                    CleaningFee = 19.19m,
                    Tax = 64.55m,
                    ConfirmationNumber = 21902,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "lamemartin.Martin@aool.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3133)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 6),
                    CheckOut = new DateTime(2024, 11, 18),
                    NumOfGuests = 9,
                    WeekdayPrice = 163.68m,
                    WeekendPrice = 286.53m,
                    DiscountRate = 0.00m,
                    CleaningFee = 25.57m,
                    Tax = 173.68m,
                    ConfirmationNumber = 21903,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "tuck33@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3067)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 7),
                    CheckOut = new DateTime(2024, 11, 15),
                    NumOfGuests = 3,
                    WeekdayPrice = 147.55m,
                    WeekendPrice = 209.77m,
                    DiscountRate = 0.09m,
                    CleaningFee = 27.65m,
                    Tax = 93.27m,
                    ConfirmationNumber = 21904,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "liz@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3075)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 17),
                    CheckOut = new DateTime(2024, 11, 22),
                    NumOfGuests = 12,
                    WeekdayPrice = 224.98m,
                    WeekendPrice = 180.86m,
                    DiscountRate = 0.00m,
                    CleaningFee = 11.91m,
                    Tax = 76.49m,
                    ConfirmationNumber = 21905,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3127)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 20),
                    CheckOut = new DateTime(2024, 11, 27),
                    NumOfGuests = 1,
                    WeekdayPrice = 134.72m,
                    WeekendPrice = 249.39m,
                    DiscountRate = 0.00m,
                    CleaningFee = 19.19m,
                    Tax = 83.41m,
                    ConfirmationNumber = 21906,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3133)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 23),
                    CheckOut = new DateTime(2024, 12, 1),
                    NumOfGuests = 5,
                    WeekdayPrice = 93.35m,
                    WeekendPrice = 271.49m,
                    DiscountRate = 0.18m,
                    CleaningFee = 8.54m,
                    Tax = 90.28m,
                    ConfirmationNumber = 21907,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "elowe@netscrape.net"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3082)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 24),
                    CheckOut = new DateTime(2024, 12, 4),
                    NumOfGuests = 11,
                    WeekdayPrice = 174.87m,
                    WeekendPrice = 152.09m,
                    DiscountRate = 0.08m,
                    CleaningFee = 18.44m,
                    Tax = 118.92m,
                    ConfirmationNumber = 21908,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "victoria@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3172)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 29),
                    CheckOut = new DateTime(2024, 12, 18),
                    NumOfGuests = 10,
                    WeekdayPrice = 117.45m,
                    WeekendPrice = 167.53m,
                    DiscountRate = 0.17m,
                    CleaningFee = 24.75m,
                    Tax = 178.97m,
                    ConfirmationNumber = 21909,
                    ReservationStatus = ReservationStatus.Cancelled,
                    User = context.Users.FirstOrDefault(u => u.Email == "wjhearniii@umch.edu"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3056)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 28),
                    CheckOut = new DateTime(2024, 12, 1),
                    NumOfGuests = 13,
                    WeekdayPrice = 155.03m,
                    WeekendPrice = 139.83m,
                    DiscountRate = 0.09m,
                    CleaningFee = 21.05m,
                    Tax = 97.01m,
                    ConfirmationNumber = 21910,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "fd@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3065)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 1),
                    CheckOut = new DateTime(2024, 11, 5),
                    NumOfGuests = 9,
                    WeekdayPrice = 163.68m,
                    WeekendPrice = 286.53m,
                    DiscountRate = 0.00m,
                    CleaningFee = 25.57m,
                    Tax = 391.40m,
                    ConfirmationNumber = 21911,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "tfreeley@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3067)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 15),
                    CheckOut = new DateTime(2024, 12, 1),
                    NumOfGuests = 14,
                    WeekdayPrice = 215.38m,
                    WeekendPrice = 117.17m,
                    DiscountRate = 0.00m,
                    CleaningFee = 24.31m,
                    Tax = 208.55m,
                    ConfirmationNumber = 21912,
                    ReservationStatus = ReservationStatus.Cancelled,
                    User = context.Users.FirstOrDefault(u => u.Email == "wendy@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3094)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 5),
                    CheckOut = new DateTime(2024, 12, 3),
                    NumOfGuests = 7,
                    WeekdayPrice = 150.69m,
                    WeekendPrice = 109.87m,
                    DiscountRate = 0.00m,
                    CleaningFee = 13.30m,
                    Tax = 273.42m,
                    ConfirmationNumber = 21913,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "444444.Dave@aool.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3148)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 1),
                    CheckOut = new DateTime(2024, 11, 16),
                    NumOfGuests = 12,
                    WeekdayPrice = 224.98m,
                    WeekendPrice = 180.86m,
                    DiscountRate = 0.00m,
                    CleaningFee = 11.91m,
                    Tax = 313.02m,
                    ConfirmationNumber = 21914,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "father.Ingram@aool.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3127)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 8),
                    CheckOut = new DateTime(2024, 12, 10),
                    NumOfGuests = 11,
                    WeekdayPrice = 194.84m,
                    WeekendPrice = 278.17m,
                    DiscountRate = 0.00m,
                    CleaningFee = 5.88m,
                    Tax = 33.52m,
                    ConfirmationNumber = 21915,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3085)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 9),
                    CheckOut = new DateTime(2024, 12, 11),
                    NumOfGuests = 3,
                    WeekdayPrice = 140.93m,
                    WeekendPrice = 228.81m,
                    DiscountRate = 0.15m,
                    CleaningFee = 29.74m,
                    Tax = 21.81m,
                    ConfirmationNumber = 21916,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "hicks43@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3180)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 2),
                    CheckOut = new DateTime(2024, 12, 5),
                    NumOfGuests = 10,
                    WeekdayPrice = 126.25m,
                    WeekendPrice = 269.63m,
                    DiscountRate = 0.16m,
                    CleaningFee = 8.27m,
                    Tax = 45.97m,
                    ConfirmationNumber = 21917,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3161)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 1),
                    CheckOut = new DateTime(2024, 12, 4),
                    NumOfGuests = 11,
                    WeekdayPrice = 194.84m,
                    WeekendPrice = 278.17m,
                    DiscountRate = 0.00m,
                    CleaningFee = 5.88m,
                    Tax = 47.16m,
                    ConfirmationNumber = 21918,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "sheff44@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3085)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 8),
                    CheckOut = new DateTime(2024, 12, 9),
                    NumOfGuests = 12,
                    WeekdayPrice = 112.62m,
                    WeekendPrice = 165.32m,
                    DiscountRate = 0.00m,
                    CleaningFee = 24.26m,
                    Tax = 13.27m,
                    ConfirmationNumber = 21919,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "sheff44@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3021)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 10),
                    CheckOut = new DateTime(2024, 12, 11),
                    NumOfGuests = 10,
                    WeekdayPrice = 205.01m,
                    WeekendPrice = 108.24m,
                    DiscountRate = 0.00m,
                    CleaningFee = 6.56m,
                    Tax = 36.74m,
                    ConfirmationNumber = 21919,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "sheff44@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3174)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 9),
                    CheckOut = new DateTime(2024, 12, 10),
                    NumOfGuests = 12,
                    WeekdayPrice = 170.25m,
                    WeekendPrice = 100.37m,
                    DiscountRate = 0.00m,
                    CleaningFee = 18.64m,
                    Tax = 20.25m,
                    ConfirmationNumber = 21919,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "sheff44@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3005)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 22),
                    CheckOut = new DateTime(2024, 12, 1),
                    NumOfGuests = 10,
                    WeekdayPrice = 126.25m,
                    WeekendPrice = 269.63m,
                    DiscountRate = 0.16m,
                    CleaningFee = 8.27m,
                    Tax = 155.61m,
                    ConfirmationNumber = 21919,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "father.Ingram@aool.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3161)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 8),
                    CheckOut = new DateTime(2024, 12, 12),
                    NumOfGuests = 1,
                    WeekdayPrice = 127.97m,
                    WeekendPrice = 182.77m,
                    DiscountRate = 0.17m,
                    CleaningFee = 13.02m,
                    Tax = 40.58m,
                    ConfirmationNumber = 21920,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "fd@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3087)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 8),
                    CheckOut = new DateTime(2024, 12, 12),
                    NumOfGuests = 8,
                    WeekdayPrice = 83.34m,
                    WeekendPrice = 128.05m,
                    DiscountRate = 0.21m,
                    CleaningFee = 11.29m,
                    Tax = 27.26m,
                    ConfirmationNumber = 21921,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "father.Ingram@aool.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3107)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 12),
                    CheckOut = new DateTime(2024, 12, 15),
                    NumOfGuests = 10,
                    WeekdayPrice = 204.04m,
                    WeekendPrice = 204.28m,
                    DiscountRate = 0.00m,
                    CleaningFee = 11.07m,
                    Tax = 129.37m,
                    ConfirmationNumber = 21921,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "father.Ingram@aool.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3051)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 7),
                    CheckOut = new DateTime(2024, 12, 31),
                    NumOfGuests = 3,
                    WeekdayPrice = 130.47m,
                    WeekendPrice = 196.09m,
                    DiscountRate = 0.00m,
                    CleaningFee = 14.53m,
                    Tax = 256.95m,
                    ConfirmationNumber = 21923,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "jeff@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3073)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 11),
                    CheckOut = new DateTime(2024, 12, 24),
                    NumOfGuests = 13,
                    WeekdayPrice = 170.07m,
                    WeekendPrice = 176.37m,
                    DiscountRate = 0.09m,
                    CleaningFee = 8.54m,
                    Tax = 157.13m,
                    ConfirmationNumber = 21923,
                    ReservationStatus = ReservationStatus.Cancelled,
                    User = context.Users.FirstOrDefault(u => u.Email == "cmiller@mapster.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3097)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 22),
                    CheckOut = new DateTime(2024, 11, 29),
                    NumOfGuests = 1,
                    WeekdayPrice = 127.97m,
                    WeekendPrice = 182.77m,
                    DiscountRate = 0.17m,
                    CleaningFee = 13.02m,
                    Tax = 71.29m,
                    ConfirmationNumber = 21924,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "tuck33@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3087)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 16),
                    CheckOut = new DateTime(2024, 12, 22),
                    NumOfGuests = 5,
                    WeekdayPrice = 104.05m,
                    WeekendPrice = 158.42m,
                    DiscountRate = 0.23m,
                    CleaningFee = 5.36m,
                    Tax = 124.85m,
                    ConfirmationNumber = 21925,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "tfreeley@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3038)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 20),
                    CheckOut = new DateTime(2024, 12, 1),
                    NumOfGuests = 8,
                    WeekdayPrice = 83.34m,
                    WeekendPrice = 128.05m,
                    DiscountRate = 0.21m,
                    CleaningFee = 11.29m,
                    Tax = 215.64m,
                    ConfirmationNumber = 21925,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "tfreeley@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3107)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 22),
                    CheckOut = new DateTime(2024, 12, 28),
                    NumOfGuests = 4,
                    WeekdayPrice = 106.30m,
                    WeekendPrice = 192.46m,
                    DiscountRate = 0.00m,
                    CleaningFee = 17.59m,
                    Tax = 51.91m,
                    ConfirmationNumber = 21925,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "tfreeley@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3113)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 28),
                    CheckOut = new DateTime(2024, 12, 31),
                    NumOfGuests = 6,
                    WeekdayPrice = 199.68m,
                    WeekendPrice = 241.45m,
                    DiscountRate = 0.00m,
                    CleaningFee = 25.94m,
                    Tax = 105.51m,
                    ConfirmationNumber = 21925,
                    ReservationStatus = ReservationStatus.Cancelled,
                    User = context.Users.FirstOrDefault(u => u.Email == "tfreeley@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3142)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 14),
                    CheckOut = new DateTime(2024, 12, 16),
                    NumOfGuests = 1,
                    WeekdayPrice = 89.88m,
                    WeekendPrice = 123.04m,
                    DiscountRate = 0.00m,
                    CleaningFee = 19.14m,
                    Tax = 18.57m,
                    ConfirmationNumber = 21925,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "tfreeley@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3071)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 2),
                    CheckOut = new DateTime(2024, 12, 6),
                    NumOfGuests = 13,
                    WeekdayPrice = 155.03m,
                    WeekendPrice = 139.83m,
                    DiscountRate = 0.09m,
                    CleaningFee = 21.05m,
                    Tax = 54.67m,
                    ConfirmationNumber = 21926,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "tfreeley@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3065)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 15),
                    CheckOut = new DateTime(2024, 12, 24),
                    NumOfGuests = 9,
                    WeekdayPrice = 223.27m,
                    WeekendPrice = 269.55m,
                    DiscountRate = 0.00m,
                    CleaningFee = 11.35m,
                    Tax = 151.17m,
                    ConfirmationNumber = 21927,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "peterstump@hootmail.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3157)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 1),
                    CheckOut = new DateTime(2024, 12, 4),
                    NumOfGuests = 8,
                    WeekdayPrice = 83.34m,
                    WeekendPrice = 128.05m,
                    DiscountRate = 0.21m,
                    CleaningFee = 11.29m,
                    Tax = 21.42m,
                    ConfirmationNumber = 21928,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "ra@aoo.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3107)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 1),
                    CheckOut = new DateTime(2024, 12, 2),
                    NumOfGuests = 13,
                    WeekdayPrice = 155.03m,
                    WeekendPrice = 139.83m,
                    DiscountRate = 0.09m,
                    CleaningFee = 21.05m,
                    Tax = 11.26m,
                    ConfirmationNumber = 21929,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3065)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 28),
                    CheckOut = new DateTime(2025, 1, 3),
                    NumOfGuests = 14,
                    WeekdayPrice = 172.83m,
                    WeekendPrice = 229.98m,
                    DiscountRate = 0.00m,
                    CleaningFee = 23.55m,
                    Tax = 142.73m,
                    ConfirmationNumber = 21929,
                    ReservationStatus = ReservationStatus.Cancelled,
                    User = context.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3034)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 25),
                    CheckOut = new DateTime(2024, 12, 28),
                    NumOfGuests = 1,
                    WeekdayPrice = 111.73m,
                    WeekendPrice = 260.62m,
                    DiscountRate = 0.24m,
                    CleaningFee = 15.89m,
                    Tax = 24.58m,
                    ConfirmationNumber = 21929,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3099)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 29),
                    CheckOut = new DateTime(2024, 12, 31),
                    NumOfGuests = 1,
                    WeekdayPrice = 188.53m,
                    WeekendPrice = 157.96m,
                    DiscountRate = 0.00m,
                    CleaningFee = 6.69m,
                    Tax = 24.72m,
                    ConfirmationNumber = 21930,
                    ReservationStatus = ReservationStatus.Cancelled,
                    User = context.Users.FirstOrDefault(u => u.Email == "tanner@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3183)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 29),
                    CheckOut = new DateTime(2024, 12, 2),
                    NumOfGuests = 12,
                    WeekdayPrice = 224.98m,
                    WeekendPrice = 180.86m,
                    DiscountRate = 0.00m,
                    CleaningFee = 11.91m,
                    Tax = 41.90m,
                    ConfirmationNumber = 21931,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "tuck33@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3127)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 14),
                    CheckOut = new DateTime(2024, 12, 26),
                    NumOfGuests = 4,
                    WeekdayPrice = 70.24m,
                    WeekendPrice = 126.45m,
                    DiscountRate = 0.08m,
                    CleaningFee = 18.69m,
                    Tax = 76.05m,
                    ConfirmationNumber = 21932,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "fd@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3027)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 26),
                    CheckOut = new DateTime(2024, 12, 31),
                    NumOfGuests = 1,
                    WeekdayPrice = 189.98m,
                    WeekendPrice = 119.06m,
                    DiscountRate = 0.00m,
                    CleaningFee = 25.11m,
                    Tax = 189.71m,
                    ConfirmationNumber = 21932,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "fd@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3122)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 4),
                    CheckOut = new DateTime(2024, 12, 6),
                    NumOfGuests = 8,
                    WeekdayPrice = 83.34m,
                    WeekendPrice = 128.05m,
                    DiscountRate = 0.21m,
                    CleaningFee = 11.29m,
                    Tax = 24.13m,
                    ConfirmationNumber = 21932,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "fd@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3107)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 6),
                    CheckOut = new DateTime(2024, 12, 10),
                    NumOfGuests = 13,
                    WeekdayPrice = 155.03m,
                    WeekendPrice = 139.83m,
                    DiscountRate = 0.09m,
                    CleaningFee = 21.05m,
                    Tax = 53.61m,
                    ConfirmationNumber = 21933,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "ra@aoo.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3065)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 12, 26),
                    CheckOut = new DateTime(2025, 1, 5),
                    NumOfGuests = 1,
                    WeekdayPrice = 212.86m,
                    WeekendPrice = 212.70m,
                    DiscountRate = 0.00m,
                    CleaningFee = 6.82m,
                    Tax = 149.45m,
                    ConfirmationNumber = 21934,
                    ReservationStatus = ReservationStatus.Valid,
                    User = context.Users.FirstOrDefault(u => u.Email == "louielouie@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3105)
                },
                new Reservation
                {
                    CheckIn = new DateTime(2024, 11, 25),
                    CheckOut = new DateTime(2024, 11, 27),
                    NumOfGuests = 6,
                    WeekdayPrice = 106.87m,
                    WeekendPrice = 121.74m,
                    DiscountRate = 0.06m,
                    CleaningFee = 5.62m,
                    Tax = 15.36m,
                    ConfirmationNumber = 21935,
                    ReservationStatus = ReservationStatus.Cancelled,
                    User = context.Users.FirstOrDefault(u => u.Email == "rwood@voyager.net"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3053)
                }
            };

            // Add the reservations to the database
            await context.Reservations.AddRangeAsync(Reservations);

            // Save changes to the database
            await context.SaveChangesAsync();
        }
    }
}