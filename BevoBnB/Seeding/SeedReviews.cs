using System;
using Microsoft.EntityFrameworkCore;
using BevoBnB.Models;

public static class SeedData
{
    public static void SeedReviews(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Review>().HasData(
            
        new Review {
            ReviewID = 1,  // Assuming Unnamed: 0 is ReviewID
            Rating = 4,
            ReviewText = " ",
            HostComments = null,
            DisputeStatus = DisputeStatus.NoDispute
        }
    ,
        new Review {
            ReviewID = 2,  // Assuming Unnamed: 0 is ReviewID
            Rating = 3,
            ReviewText = "It was meh, ya know? It was really close to the coast, but the beaches were kinda trashed. The apartment was nice, but there wasn't an elevator.",
            HostComments = null,
            DisputeStatus = DisputeStatus.NoDispute
        }
    ,
        new Review {
            ReviewID = 3,  // Assuming Unnamed: 0 is ReviewID
            Rating = 4,
            ReviewText = null,
            HostComments = "The customer did not provide a valid reason for this rating.",
            DisputeStatus = DisputeStatus.Disputed
        }
    ,
        new Review {
            ReviewID = 4,  // Assuming Unnamed: 0 is ReviewID
            Rating = 2,
            ReviewText = " ",
            HostComments = null,
            DisputeStatus = DisputeStatus.NoDispute
        }
    ,
        new Review {
            ReviewID = 5,  // Assuming Unnamed: 0 is ReviewID
            Rating = 3,
            ReviewText = "Nebraska was... interesting",
            HostComments = null,
            DisputeStatus = DisputeStatus.NoDispute
        }
    ,
        new Review {
            ReviewID = 6,  // Assuming Unnamed: 0 is ReviewID
            Rating = 1,
            ReviewText = "There was corn EVERYWHERE! I looked left and BAM, CORN. Looked right, BAM, CORN",
            HostComments = "It is not my fault there was corn. It was not my corn!",
            DisputeStatus = DisputeStatus.Disputed
        }
    ,
        new Review {
            ReviewID = 7,  // Assuming Unnamed: 0 is ReviewID
            Rating = 1,
            ReviewText = "Worst. Stay. Ever. Never using BevoBnB again",
            HostComments = "BevoBnB is the best",
            DisputeStatus = null
        }
    ,
        new Review {
            ReviewID = 8,  // Assuming Unnamed: 0 is ReviewID
            Rating = 5,
            ReviewText = " ",
            HostComments = null,
            DisputeStatus = DisputeStatus.NoDispute
        }
    ,
        new Review {
            ReviewID = 9,  // Assuming Unnamed: 0 is ReviewID
            Rating = 2,
            ReviewText = " ",
            HostComments = null,
            DisputeStatus = DisputeStatus.NoDispute
        }
    ,
        new Review {
            ReviewID = 10,  // Assuming Unnamed: 0 is ReviewID
            Rating = 1,
            ReviewText = "It was SO hard to book this place. Who coded this site anyway? ;)",
            HostComments = "The website was coded by students so the owner should not be penalized!",
            DisputeStatus = DisputeStatus.InvalidDispute
        }
    ,
        new Review {
            ReviewID = 11,  // Assuming Unnamed: 0 is ReviewID
            Rating = 4,
            ReviewText = " ",
            HostComments = null,
            DisputeStatus = DisputeStatus.NoDispute
        }
    ,
        new Review {
            ReviewID = 12,  // Assuming Unnamed: 0 is ReviewID
            Rating = 5,
            ReviewText = "This place rocked!",
            HostComments = null,
            DisputeStatus = DisputeStatus.NoDispute
        }
    ,
        new Review {
            ReviewID = 13,  // Assuming Unnamed: 0 is ReviewID
            Rating = 4,
            ReviewText = " ",
            HostComments = "I do not understand this.",
            DisputeStatus = null
        }
    ,
        new Review {
            ReviewID = 14,  // Assuming Unnamed: 0 is ReviewID
            Rating = 4,
            ReviewText = " ",
            HostComments = null,
            DisputeStatus = DisputeStatus.NoDispute
        }
    ,
        new Review {
            ReviewID = 15,  // Assuming Unnamed: 0 is ReviewID
            Rating = 1,
            ReviewText = "There were 1...5...22 roaches? I lost count.",
            HostComments = null,
            DisputeStatus = DisputeStatus.NoDispute
        }
    ,
        new Review {
            ReviewID = 16,  // Assuming Unnamed: 0 is ReviewID
            Rating = 1,
            ReviewText = " ",
            HostComments = null,
            DisputeStatus = DisputeStatus.NoDispute
        }
    ,
        new Review {
            ReviewID = 17,  // Assuming Unnamed: 0 is ReviewID
            Rating = 4,
            ReviewText = "I LOVED the place! Had a nice view of the mountains",
            HostComments = null,
            DisputeStatus = DisputeStatus.NoDispute
        }
    ,
        new Review {
            ReviewID = 18,  // Assuming Unnamed: 0 is ReviewID
            Rating = 5,
            ReviewText = " ",
            HostComments = null,
            DisputeStatus = DisputeStatus.NoDispute
        }
    ,
        new Review {
            ReviewID = 19,  // Assuming Unnamed: 0 is ReviewID
            Rating = 5,
            ReviewText = "My stay was amazing! Saved my marriage",
            HostComments = null,
            DisputeStatus = DisputeStatus.NoDispute
        }
    ,
        new Review {
            ReviewID = 20,  // Assuming Unnamed: 0 is ReviewID
            Rating = 2,
            ReviewText = " ",
            HostComments = "Why??",
            DisputeStatus = DisputeStatus.InvalidDispute
        }
    ,
        new Review {
            ReviewID = 21,  // Assuming Unnamed: 0 is ReviewID
            Rating = 2,
            ReviewText = "My wife's attitude was the only thing rougher than the sand at the nearby beaches",
            HostComments = null,
            DisputeStatus = DisputeStatus.NoDispute
        }
    
        );
    }
}
