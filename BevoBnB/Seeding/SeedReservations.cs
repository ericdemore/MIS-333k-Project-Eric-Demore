
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

    public static class SeedReservations
    {
        public static void SeedAllReservations(AppDbContext db)
        {
            List<Reservation> AllReservations = new List<Reservation>();

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-01 00:00:00"),
                CheckOut = DateTime.Parse("2024-11-03 00:00:00"),
                NumOfGuests = 1,
                WeekdayPrice = 134.72m,
                WeekendPrice = 249.39m,
                DiscountRate = 0.00m,
                Tax = 31.69m,
                ConfirmationNumber = 21900,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "sheff44@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3133)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-04 00:00:00"),
                CheckOut = DateTime.Parse("2024-11-06 00:00:00"),
                NumOfGuests = 2,
                WeekdayPrice = 204.67m,
                WeekendPrice = 207.51m,
                DiscountRate = 0.22m,
                Tax = 34.00m,
                ConfirmationNumber = 21901,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "luce_chuck@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3150)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-05 00:00:00"),
                CheckOut = DateTime.Parse("2024-11-10 00:00:00"),
                NumOfGuests = 14,
                WeekdayPrice = 163.30m,
                WeekendPrice = 262.77m,
                DiscountRate = 0.16m,
                Tax = 35.15m,
                ConfirmationNumber = 21901,
                ReservationStatus = ReservationStatus.Cancelled,
                User = db.Users.FirstOrDefault(u => u.Email == "luce_chuck@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3116)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-07 00:00:00"),
                CheckOut = DateTime.Parse("2024-11-12 00:00:00"),
                NumOfGuests = 1,
                WeekdayPrice = 134.72m,
                WeekendPrice = 249.39m,
                DiscountRate = 0.00m,
                Tax = 31.69m,
                ConfirmationNumber = 21902,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "lamemartin.Martin@aool.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3133)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-06 00:00:00"),
                CheckOut = DateTime.Parse("2024-11-18 00:00:00"),
                NumOfGuests = 9,
                WeekdayPrice = 163.68m,
                WeekendPrice = 286.53m,
                DiscountRate = 0.00m,
                Tax = 37.14m,
                ConfirmationNumber = 21903,
                ReservationStatus = ReservationStatus.Cancelled,
                User = db.Users.FirstOrDefault(u => u.Email == "tuck33@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3067)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-07 00:00:00"),
                CheckOut = DateTime.Parse("2024-11-15 00:00:00"),
                NumOfGuests = 3,
                WeekdayPrice = 147.55m,
                WeekendPrice = 209.77m,
                DiscountRate = 0.09m,
                Tax = 29.48m,
                ConfirmationNumber = 21904,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "liz@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3075)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-17 00:00:00"),
                CheckOut = DateTime.Parse("2024-11-22 00:00:00"),
                NumOfGuests = 12,
                WeekdayPrice = 224.98m,
                WeekendPrice = 180.86m,
                DiscountRate = 0.00m,
                Tax = 33.48m,
                ConfirmationNumber = 21905,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3127)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-20 00:00:00"),
                CheckOut = DateTime.Parse("2024-11-27 00:00:00"),
                NumOfGuests = 1,
                WeekdayPrice = 134.72m,
                WeekendPrice = 249.39m,
                DiscountRate = 0.00m,
                Tax = 31.69m,
                ConfirmationNumber = 21906,
                ReservationStatus = ReservationStatus.Cancelled,
                User = db.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3133)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-23 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-01 00:00:00"),
                NumOfGuests = 5,
                WeekdayPrice = 93.35m,
                WeekendPrice = 271.49m,
                DiscountRate = 0.18m,
                Tax = 30.10m,
                ConfirmationNumber = 21907,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "elowe@netscrape.net"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3082)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-24 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-04 00:00:00"),
                NumOfGuests = 11,
                WeekdayPrice = 174.87m,
                WeekendPrice = 152.09m,
                DiscountRate = 0.08m,
                Tax = 26.97m,
                ConfirmationNumber = 21908,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "victoria@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3172)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-29 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-18 00:00:00"),
                NumOfGuests = 10,
                WeekdayPrice = 117.45m,
                WeekendPrice = 167.53m,
                DiscountRate = 0.17m,
                Tax = 23.51m,
                ConfirmationNumber = 21909,
                ReservationStatus = ReservationStatus.Cancelled,
                User = db.Users.FirstOrDefault(u => u.Email == "wjhearniii@umch.edu"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3056)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-28 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-07 00:00:00"),
                NumOfGuests = 13,
                WeekdayPrice = 155.03m,
                WeekendPrice = 139.83m,
                DiscountRate = 0.09m,
                Tax = 24.33m,
                ConfirmationNumber = 21910,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "fd@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3065)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-01 00:00:00"),
                CheckOut = DateTime.Parse("2024-11-29 00:00:00"),
                NumOfGuests = 9,
                WeekdayPrice = 163.68m,
                WeekendPrice = 286.53m,
                DiscountRate = 0.00m,
                Tax = 37.14m,
                ConfirmationNumber = 21911,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "tfreeley@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3067)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-15 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-01 00:00:00"),
                NumOfGuests = 14,
                WeekdayPrice = 215.38m,
                WeekendPrice = 117.17m,
                DiscountRate = 0.00m,
                Tax = 27.44m,
                ConfirmationNumber = 21912,
                ReservationStatus = ReservationStatus.Cancelled,
                User = db.Users.FirstOrDefault(u => u.Email == "wendy@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3094)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-05 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-03 00:00:00"),
                NumOfGuests = 7,
                WeekdayPrice = 150.69m,
                WeekendPrice = 109.87m,
                DiscountRate = 0.00m,
                Tax = 21.50m,
                ConfirmationNumber = 21913,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "444444.Dave@aool.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3148)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-01 00:00:00"),
                CheckOut = DateTime.Parse("2024-11-22 00:00:00"),
                NumOfGuests = 12,
                WeekdayPrice = 224.98m,
                WeekendPrice = 180.86m,
                DiscountRate = 0.00m,
                Tax = 33.48m,
                ConfirmationNumber = 21914,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "father.Ingram@aool.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3127)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-08 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-10 00:00:00"),
                NumOfGuests = 11,
                WeekdayPrice = 194.84m,
                WeekendPrice = 278.17m,
                DiscountRate = 0.00m,
                Tax = 39.02m,
                ConfirmationNumber = 21915,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3085)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-09 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-11 00:00:00"),
                NumOfGuests = 3,
                WeekdayPrice = 140.93m,
                WeekendPrice = 228.81m,
                DiscountRate = 0.15m,
                Tax = 30.50m,
                ConfirmationNumber = 21916,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "hicks43@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3180)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-01 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-05 00:00:00"),
                NumOfGuests = 10,
                WeekdayPrice = 126.25m,
                WeekendPrice = 269.63m,
                DiscountRate = 0.16m,
                Tax = 32.66m,
                ConfirmationNumber = 21917,
                ReservationStatus = ReservationStatus.Cancelled,
                User = db.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3161)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-01 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-04 00:00:00"),
                NumOfGuests = 11,
                WeekdayPrice = 194.84m,
                WeekendPrice = 278.17m,
                DiscountRate = 0.00m,
                Tax = 39.02m,
                ConfirmationNumber = 21918,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "sheff44@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3085)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-08 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-09 00:00:00"),
                NumOfGuests = 12,
                WeekdayPrice = 112.62m,
                WeekendPrice = 165.32m,
                DiscountRate = 0.00m,
                Tax = 22.93m,
                ConfirmationNumber = 21919,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "sheff44@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3021)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-08 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-11 00:00:00"),
                NumOfGuests = 10,
                WeekdayPrice = 205.01m,
                WeekendPrice = 108.24m,
                DiscountRate = 0.00m,
                Tax = 25.84m,
                ConfirmationNumber = 21919,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "sheff44@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3174)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-08 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-10 00:00:00"),
                NumOfGuests = 12,
                WeekdayPrice = 170.25m,
                WeekendPrice = 100.37m,
                DiscountRate = 0.00m,
                Tax = 22.33m,
                ConfirmationNumber = 21919,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "sheff44@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3005)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-22 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-05 00:00:00"),
                NumOfGuests = 10,
                WeekdayPrice = 126.25m,
                WeekendPrice = 269.63m,
                DiscountRate = 0.16m,
                Tax = 32.66m,
                ConfirmationNumber = 21919,
                ReservationStatus = ReservationStatus.Cancelled,
                User = db.Users.FirstOrDefault(u => u.Email == "father.Ingram@aool.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3161)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-08 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-12 00:00:00"),
                NumOfGuests = 1,
                WeekdayPrice = 127.97m,
                WeekendPrice = 182.77m,
                DiscountRate = 0.17m,
                Tax = 25.64m,
                ConfirmationNumber = 21920,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "fd@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3087)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-08 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-12 00:00:00"),
                NumOfGuests = 8,
                WeekdayPrice = 83.34m,
                WeekendPrice = 128.05m,
                DiscountRate = 0.21m,
                Tax = 17.44m,
                ConfirmationNumber = 21921,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "father.Ingram@aool.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3107)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-06 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-15 00:00:00"),
                NumOfGuests = 10,
                WeekdayPrice = 204.04m,
                WeekendPrice = 204.28m,
                DiscountRate = 0.00m,
                Tax = 33.69m,
                ConfirmationNumber = 21921,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "father.Ingram@aool.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3051)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-07 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-31 00:00:00"),
                NumOfGuests = 3,
                WeekdayPrice = 130.47m,
                WeekendPrice = 196.09m,
                DiscountRate = 0.00m,
                Tax = 26.94m,
                ConfirmationNumber = 21923,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "jeff@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3073)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-11 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-24 00:00:00"),
                NumOfGuests = 13,
                WeekdayPrice = 170.07m,
                WeekendPrice = 176.37m,
                DiscountRate = 0.09m,
                Tax = 28.58m,
                ConfirmationNumber = 21923,
                ReservationStatus = ReservationStatus.Cancelled,
                User = db.Users.FirstOrDefault(u => u.Email == "cmiller@mapster.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3097)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-22 00:00:00"),
                CheckOut = DateTime.Parse("2024-11-29 00:00:00"),
                NumOfGuests = 1,
                WeekdayPrice = 127.97m,
                WeekendPrice = 182.77m,
                DiscountRate = 0.17m,
                Tax = 25.64m,
                ConfirmationNumber = 21924,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "tuck33@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3087)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-16 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-31 00:00:00"),
                NumOfGuests = 5,
                WeekdayPrice = 104.05m,
                WeekendPrice = 158.42m,
                DiscountRate = 0.23m,
                Tax = 21.65m,
                ConfirmationNumber = 21925,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "tfreeley@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3038)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-20 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-22 00:00:00"),
                NumOfGuests = 8,
                WeekdayPrice = 83.34m,
                WeekendPrice = 128.05m,
                DiscountRate = 0.21m,
                Tax = 17.44m,
                ConfirmationNumber = 21925,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "tfreeley@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3107)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-22 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-28 00:00:00"),
                NumOfGuests = 4,
                WeekdayPrice = 106.30m,
                WeekendPrice = 192.46m,
                DiscountRate = 0.00m,
                Tax = 24.65m,
                ConfirmationNumber = 21925,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "tfreeley@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3113)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-24 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-31 00:00:00"),
                NumOfGuests = 6,
                WeekdayPrice = 199.68m,
                WeekendPrice = 241.45m,
                DiscountRate = 0.00m,
                Tax = 36.39m,
                ConfirmationNumber = 21925,
                ReservationStatus = ReservationStatus.Cancelled,
                User = db.Users.FirstOrDefault(u => u.Email == "tfreeley@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3142)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-14 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-16 00:00:00"),
                NumOfGuests = 1,
                WeekdayPrice = 89.88m,
                WeekendPrice = 123.04m,
                DiscountRate = 0.00m,
                Tax = 17.57m,
                ConfirmationNumber = 21925,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "tfreeley@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3071)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-01 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-06 00:00:00"),
                NumOfGuests = 13,
                WeekdayPrice = 155.03m,
                WeekendPrice = 139.83m,
                DiscountRate = 0.09m,
                Tax = 24.33m,
                ConfirmationNumber = 21926,
                ReservationStatus = ReservationStatus.Cancelled,
                User = db.Users.FirstOrDefault(u => u.Email == "tfreeley@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3065)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-15 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-24 00:00:00"),
                NumOfGuests = 9,
                WeekdayPrice = 223.27m,
                WeekendPrice = 269.55m,
                DiscountRate = 0.00m,
                Tax = 40.66m,
                ConfirmationNumber = 21927,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "peterstump@hootmail.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3157)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-01 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-04 00:00:00"),
                NumOfGuests = 8,
                WeekdayPrice = 83.34m,
                WeekendPrice = 128.05m,
                DiscountRate = 0.21m,
                Tax = 17.44m,
                ConfirmationNumber = 21928,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "ra@aoo.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3107)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-01 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-02 00:00:00"),
                NumOfGuests = 13,
                WeekdayPrice = 155.03m,
                WeekendPrice = 139.83m,
                DiscountRate = 0.09m,
                Tax = 24.33m,
                ConfirmationNumber = 21929,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3065)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-23 00:00:00"),
                CheckOut = DateTime.Parse("2025-01-03 00:00:00"),
                NumOfGuests = 14,
                WeekdayPrice = 172.83m,
                WeekendPrice = 229.98m,
                DiscountRate = 0.00m,
                Tax = 33.23m,
                ConfirmationNumber = 21929,
                ReservationStatus = ReservationStatus.Cancelled,
                User = db.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3034)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-25 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-28 00:00:00"),
                NumOfGuests = 1,
                WeekdayPrice = 111.73m,
                WeekendPrice = 260.62m,
                DiscountRate = 0.24m,
                Tax = 30.72m,
                ConfirmationNumber = 21929,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3099)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-29 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-31 00:00:00"),
                NumOfGuests = 1,
                WeekdayPrice = 188.53m,
                WeekendPrice = 157.96m,
                DiscountRate = 0.00m,
                Tax = 28.59m,
                ConfirmationNumber = 21930,
                ReservationStatus = ReservationStatus.Cancelled,
                User = db.Users.FirstOrDefault(u => u.Email == "tanner@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3183)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-29 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-02 00:00:00"),
                NumOfGuests = 12,
                WeekdayPrice = 224.98m,
                WeekendPrice = 180.86m,
                DiscountRate = 0.00m,
                Tax = 33.48m,
                ConfirmationNumber = 21931,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "tuck33@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3127)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-14 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-26 00:00:00"),
                NumOfGuests = 4,
                WeekdayPrice = 70.24m,
                WeekendPrice = 126.45m,
                DiscountRate = 0.08m,
                Tax = 16.23m,
                ConfirmationNumber = 21932,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "fd@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3027)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-15 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-31 00:00:00"),
                NumOfGuests = 1,
                WeekdayPrice = 189.98m,
                WeekendPrice = 119.06m,
                DiscountRate = 0.00m,
                Tax = 25.50m,
                ConfirmationNumber = 21932,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "fd@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3122)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-02 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-06 00:00:00"),
                NumOfGuests = 8,
                WeekdayPrice = 83.34m,
                WeekendPrice = 128.05m,
                DiscountRate = 0.21m,
                Tax = 17.44m,
                ConfirmationNumber = 21932,
                ReservationStatus = ReservationStatus.Cancelled,
                User = db.Users.FirstOrDefault(u => u.Email == "fd@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3107)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-05 00:00:00"),
                CheckOut = DateTime.Parse("2024-12-10 00:00:00"),
                NumOfGuests = 13,
                WeekdayPrice = 155.03m,
                WeekendPrice = 139.83m,
                DiscountRate = 0.09m,
                Tax = 24.33m,
                ConfirmationNumber = 21933,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "ra@aoo.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3065)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-12-26 00:00:00"),
                CheckOut = DateTime.Parse("2025-01-05 00:00:00"),
                NumOfGuests = 1,
                WeekdayPrice = 212.86m,
                WeekendPrice = 212.70m,
                DiscountRate = 0.00m,
                Tax = 35.11m,
                ConfirmationNumber = 21934,
                ReservationStatus = ReservationStatus.Valid,
                User = db.Users.FirstOrDefault(u => u.Email == "louielouie@puppy.com"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3105)
            });

            AllReservations.Add(new Reservation
            {
                CheckIn = DateTime.Parse("2024-11-25 00:00:00"),
                CheckOut = DateTime.Parse("2024-11-27 00:00:00"),
                NumOfGuests = 6,
                WeekdayPrice = 106.87m,
                WeekendPrice = 121.74m,
                DiscountRate = 0.06m,
                Tax = 18.86m,
                ConfirmationNumber = 21935,
                ReservationStatus = ReservationStatus.Cancelled,
                User = db.Users.FirstOrDefault(u => u.Email == "rwood@voyager.net"),
                Property = db.Properties.FirstOrDefault(p => p.PropertyNumber == 3053)
            });

            // Save each reservation to the database
            foreach (Reservation seedReservation in AllReservations)
            {
                Reservation dbReservation = db.Reservations.FirstOrDefault(r => 
                    r.ConfirmationNumber == seedReservation.ConfirmationNumber);
                
                if (dbReservation == null)
                {
                    db.Reservations.Add(seedReservation);
                    db.SaveChanges();
                }
            }
        }
    }
}
