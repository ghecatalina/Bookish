﻿namespace Api.Dto
{
    public class BookGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public string Genre { get; set; }
    }
}
