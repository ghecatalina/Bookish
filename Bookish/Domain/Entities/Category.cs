﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
