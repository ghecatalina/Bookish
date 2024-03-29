﻿namespace Domain
{
    public class Review : BaseEntity
    {
        public string ReviewDescription { get; set; }
        public double Rating { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public  Book Book { get; set; }
    }
}
