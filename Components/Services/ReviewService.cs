using System;
using System.Collections.Generic;

namespace blazor_final_pro.Services
{
    public class ReviewModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "";
        public int Stars { get; set; } = 5;
        public string Comment { get; set; } = "";
        public string UserEmail { get; set; } = ""; // Tracks WHO wrote it
    }

    public class ReviewService
    {
        // Initial mock reviews matching your screenshot layout
        public List<ReviewModel> CoreReviews { get; set; } = new()
        {
            new ReviewModel { Name = "Ali", Stars = 5, Comment = "The logic flow is incredibly smooth.", UserEmail = "ali@au.edu.pk" },
            new ReviewModel { Name = "Sarah", Stars = 5, Comment = "Best way to learn Visual Programming!", UserEmail = "sarah@au.edu.pk" },
            new ReviewModel { Name = "Hamza", Stars = 4, Comment = "Great row-based movement mechanics.", UserEmail = "hamza@au.edu.pk" }
        };

        public void AddReview(ReviewModel review)
        {
            CoreReviews.Add(review);
        }

        public void DeleteReview(string id)
        {
            CoreReviews.RemoveAll(r => r.Id == id);
        }
    }
}