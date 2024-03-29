﻿using Domain.Entities;

namespace Domain
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public string BookCoverImage { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<BookList> BookLists { get; set; } = new List<BookList>();
    }
}
