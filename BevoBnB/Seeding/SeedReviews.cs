using BevoBnB.DAL;
using BevoBnB.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BevoBnB.Seeding
{
    public static class SeedReviews
    {
        public static async Task SeedAllReviews(AppDbContext context)
        {
            // Check if reservations already exist
            if (await context.Reviews.AnyAsync())
            {
                throw new Exception("Reservations have already been seeded.");
            }

            List<Review> Reviews = new List<Review>()
            {
                new Review
                {
                    Rating = 4,
                    ReviewText = null,
                    HostComments = null,
                    DisputeStatus = DisputeStatus.NoDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "father.Ingram@aool.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3127)
                },
                new Review
                {
                    Rating = 3,
                    ReviewText = "It was meh, ya know? It was really close to the coast, but the beaches were kinda trashed. The apartment was nice, but there wasn't an elevator.",
                    HostComments = null,
                    DisputeStatus = DisputeStatus.NoDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3085)
                },
                new Review
                {
                    Rating = 4,
                    ReviewText = null,
                    HostComments = "The customer did not provide a valid reason for this rating.",
                    DisputeStatus = DisputeStatus.Disputed,
                    User = context.Users.FirstOrDefault(u => u.Email == "father.Ingram@aool.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3161)
                },
                new Review
                {
                    Rating = 2,
                    ReviewText = null,
                    HostComments = null,
                    DisputeStatus = DisputeStatus.NoDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "tuck33@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3127)
                },
                new Review
                {
                    Rating = 3,
                    ReviewText = "Nebraska was... interesting",
                    HostComments = null,
                    DisputeStatus = DisputeStatus.NoDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "father.Ingram@aool.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3107)
                },
                new Review
                {
                    Rating = 1,
                    ReviewText = "There was corn EVERYWHERE! I looked left and BAM, CORN. Looked right, BAM, CORN",
                    HostComments = "It is not my fault there was corn. It was not my corn!",
                    DisputeStatus = DisputeStatus.Disputed,
                    User = context.Users.FirstOrDefault(u => u.Email == "tfreeley@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3107)
                },
                new Review
                {
                    Rating = 1,
                    ReviewText = "Worst. Stay. Ever. Never using BevoBnB again",
                    HostComments = "BevoBnB is the best",
                    DisputeStatus = DisputeStatus.ValidDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "ra@aoo.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3107)
                },
                new Review
                {
                    Rating = 5,
                    ReviewText = null,
                    HostComments = null,
                    DisputeStatus = DisputeStatus.NoDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3065)
                },
                new Review
                {
                    Rating = 2,
                    ReviewText = null,
                    HostComments = null,
                    DisputeStatus = DisputeStatus.NoDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3133)
                },
                new Review
                {
                    Rating = 1,
                    ReviewText = "It was SO hard to book this place. Who coded this site anyway? ;)",
                    HostComments = "The website was coded by students so the owner should not be penalized!",
                    DisputeStatus = DisputeStatus.InvalidDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "tfreeley@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3065)
                },
                new Review
                {
                    Rating = 4,
                    ReviewText = null,
                    HostComments = null,
                    DisputeStatus = DisputeStatus.NoDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "tuck33@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3067)
                },
                new Review
                {
                    Rating = 5,
                    ReviewText = "This place rocked!",
                    HostComments = null,
                    DisputeStatus = DisputeStatus.NoDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "ra@aoo.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3065)
                },
                new Review
                {
                    Rating = 4,
                    ReviewText = null,
                    HostComments = "I do not understand this.",
                    DisputeStatus = DisputeStatus.ValidDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "fd@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3065)
                },
                new Review
                {
                    Rating = 4,
                    ReviewText = null,
                    HostComments = null,
                    DisputeStatus = DisputeStatus.NoDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "lamemartin.Martin@aool.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3133)
                },
                new Review
                {
                    Rating = 1,
                    ReviewText = "There were 1...5...22 roaches? I lost count.",
                    HostComments = null,
                    DisputeStatus = DisputeStatus.NoDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "fd@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3107)
                },
                new Review
                {
                    Rating = 1,
                    ReviewText = null,
                    HostComments = null,
                    DisputeStatus = DisputeStatus.NoDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "sheff44@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3085)
                },
                new Review
                {
                    Rating = 4,
                    ReviewText = "I LOVED the place! Had a nice view of the mountains",
                    HostComments = null,
                    DisputeStatus = DisputeStatus.NoDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "fd@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3087)
                },
                new Review
                {
                    Rating = 5,
                    ReviewText = null,
                    HostComments = null,
                    DisputeStatus = DisputeStatus.NoDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "tuck33@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3087)
                },
                new Review
                {
                    Rating = 5,
                    ReviewText = "My stay was amazing! Saved my marriage",
                    HostComments = null,
                    DisputeStatus = DisputeStatus.NoDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3127)
                },
                new Review
                {
                    Rating = 2,
                    ReviewText = null,
                    HostComments = "Why??",
                    DisputeStatus = DisputeStatus.InvalidDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "sheff44@puppy.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3133)
                },
                new Review
                {
                    Rating = 2,
                    ReviewText = "My wife's attitude was the only thing rougher than the sand at the nearby beaches",
                    HostComments = null,
                    DisputeStatus = DisputeStatus.NoDispute,
                    User = context.Users.FirstOrDefault(u => u.Email == "orielly@foxnets.com"),
                    Property = context.Properties.FirstOrDefault(p => p.PropertyNumber == 3161)
                }
            };

            // Add the reviews to the database
            await context.Reviews.AddRangeAsync(Reviews);

            // Save changes to the database
            await context.SaveChangesAsync();
        }
    }
}